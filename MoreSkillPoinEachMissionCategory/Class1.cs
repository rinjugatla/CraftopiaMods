using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx;
using HarmonyLib;
using Assembly_CSharp;
using UnityEngine;
using Oc.Missions;
using Oc;
using System.Reflection;
using Oc.Skills;

namespace MoreSkillPoinEachMissionCategory
{
    [BepInPlugin(PluginGuid, PluginName, PluginVersion)]
    public class ExamplePlugin : BaseUnityPlugin
    {
        public const string PluginGuid = "me.rin_jugatla.craftopia.mod.MoreSkillPoinEachMissionCategory";
        public const string PluginName = "MoreSkillPoinEachMissionCategory";
        public const string PluginVersion = "0.0.1";

        void Awake()
        {
            UnityEngine.Debug.Log($"{PluginName} : {PluginVersion}");
            Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly());
        }
    }

    [HarmonyPatch(typeof(OcMissionManager), "Start")]
    public class OcMissionManager_Start
    {
        internal static OcMissionManager OcMissionManager;
        internal static int[] MissionCategories;

        static void Postfix(OcMissionManager __instance)
        {
            OcMissionManager = __instance;
            Mission[] missions = Traverse.Create(__instance).Field("validMissionList").GetValue<Mission[]>();
        }
    }

    /// <summary>
    /// 同一カテゴリのミッションを達成した際にスキルポイントを1付与
    /// </summary>
    [HarmonyPatch(typeof(Mission), "TryGetReward")]
    public class MissionTryGetReward
    {
        static void Postfix(Mission __instance)
        {
            if (!__instance.IsRewardTaken)
                return;

            UnityEngine.Debug.Log($"達成したミッション: {__instance.ID} {__instance.Title} {__instance.IsRewardTaken}");
            //// 同じカテゴリのミッション
            Mission[] missionsInCategory = OcMissionManager_Start.OcMissionManager.GetCategoryMissions(__instance.Category);
            foreach (var mission in missionsInCategory.Where(n => n.IsRewardTaken == false && n != __instance))
                UnityEngine.Debug.Log($"同カテゴリの未達成ミッション: {mission.ID} {mission.Title} {mission.IsRewardTaken}");

            // 同一カテゴリの未達成ミッション数
            int notCleardMissionCount = missionsInCategory.Where(n => n.IsRewardTaken == false && n != __instance).Count();
            if (notCleardMissionCount == 0)
            {
                //UnityEngine.Debug.Log("同カテゴリのミッションをすべて達成");
                OcPlMaster.Inst.SkillCtrl.AddSkillPoint(1);
            }
        }
    }

    /// <summary>
    /// スキルリセットした際にミッションカテゴリのクリア数分スキルポイントを付与
    /// </summary>
    //[HarmonyPatch(typeof(OcUI_NewSkillTree), "ResetAllSkills")]
    //public class OcUI_NewSkillTree_ResetAllSkills
    //{
    //    static void Postfix(OcUI_NewSkillTree __instance)
    //    {
    //        // ミッションカテゴリIDを取得
    //        IEnumerable<int> categoriesIds = OcMissionManager.Inst.AllCategory().Select(n => n.ID);
    //        // カテゴリごとにクリ状況を調べる
    //        int cleardCategory = 0;
    //        Mission[] missions;
    //        int notCleardMissionCount;
    //        foreach (var categoryId in categoriesIds)
    //        {
    //            missions = OcMissionManager.Inst.GetCategoryMissions(categoryId);
    //            notCleardMissionCount = missions.Where(n => n.IsRewardTaken == false).Count();
    //            if (notCleardMissionCount == 0)
    //                cleardCategory += 1;
    //        }
    //        // クリア済みカテゴリ分ポイントを付与
    //        OcPlMaster.Inst.SkillCtrl.AddSkillPoint(cleardCategory);

    //    }
    //}
}
