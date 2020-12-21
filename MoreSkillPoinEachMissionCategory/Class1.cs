using BepInEx;
using HarmonyLib;
using Oc;
using Oc.Missions;
using Oc.Skills;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ミッションカテゴリ毎にスキルポイントを1獲得
/// </summary>
namespace MoreSkillPointEachMissionCategory
{
    [BepInPlugin(PluginGuid, PluginName, PluginVersion)]
    public class ExamplePlugin : BaseUnityPlugin
    {
        public const string PluginGuid = "me.rin_jugatla.craftopia.mod.MoreSkillPointEachMissionCategory";
        public const string PluginName = "MoreSkillPointEachMissionCategory";
        public const string PluginVersion = "1.1.1";

        void Awake()
        {
            UnityEngine.Debug.Log($"{PluginName} : {PluginVersion}");
            Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly());
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

            //UnityEngine.Debug.Log($"達成したミッション: {__instance.ID} {__instance.Title} {__instance.IsRewardTaken}");
            //// 同じカテゴリのミッション
            Mission[] missionsInCategory = OcMissionManager.Inst.GetCategoryMissions(__instance.Category);
            //foreach (var mission in missionsInCategory.Where(n => n.IsRewardTaken == false && n != __instance))
            //    UnityEngine.Debug.Log($"同カテゴリの未達成ミッション: {mission.ID} {mission.Title} {mission.IsRewardTaken}");

            // 同一カテゴリの未達成ミッション数
            if (MyUtility.IsCompleatMissionCategory(__instance.Category))
            {
                //UnityEngine.Debug.Log("同カテゴリのミッションをすべて達成");
                OcPlMaster.Inst.SkillCtrl.AddSkillPoint(1);
            }
        }
    }

    /// <summary>
    /// スキル画面のスキルリセットボタンの処理
    /// </summary>
    [HarmonyPatch(typeof(OcUI_NewSkillTree), "TryOpenSkillResetPopup")]
    public class OcUI_NewSkillTree_TryOpenSkillResetPopup
    {
        static bool Prefix(OcUI_NewSkillTree __instance)
        {
            GameObject skillResetPopup = Traverse.Create(__instance).Field("skillResetPopup").GetValue<GameObject>();
            skillResetPopup.SetActive(true);
            // 使用済みポイントと取得済みポイントの計算
            int levelPoint = (int)(OcPlMaster.Inst.PlLevelCtrl.Level.Value - 1) * OcDefine.INCREASE_SKILLPOINT_BY_LEVEL_UP;
            int missionPoint = MyUtility.GetCleardMissionInAllCategory();
            int currentAssignedSP = SingletonMonoBehaviour<OcSkillManager>.Inst.CurrentAssignedSP;
            int skillPoint = OcPlMaster.Inst.SkillCtrl.SkillPoint;
            int num2 = (levelPoint + missionPoint) - (currentAssignedSP + skillPoint);

            // リセットにかかる費用
            ref int _GoldCost = ref AccessTools.FieldRefAccess<OcUI_NewSkillTree, int>(__instance, "_GoldCost");
            _GoldCost = (OcPlMaster.Inst.CanFreeResetSkill ? 0 : 100000);
            ref TextMeshProUGUI goldCostText = ref AccessTools.FieldRefAccess<OcUI_NewSkillTree, TextMeshProUGUI>(__instance, "goldCostText");
            goldCostText.text = string.Format("{0}", _GoldCost.ToString("n0"));
            // リセットで得られるポイント
            ref int _GainSkillPoint = ref AccessTools.FieldRefAccess<OcUI_NewSkillTree, int>(__instance, "_GainSkillPoint");
            _GainSkillPoint = currentAssignedSP + num2;
            ref TextMeshProUGUI gainSkillPointText = ref AccessTools.FieldRefAccess<OcUI_NewSkillTree, TextMeshProUGUI>(__instance, "gainSkillPointText");
            gainSkillPointText.text = string.Format("{0}", _GainSkillPoint);

            bool flag = OcPlMaster.Inst.HealthPl.Money >= (long)_GoldCost;
            ref Button skillResetButton = ref AccessTools.FieldRefAccess<OcUI_NewSkillTree, Button>(__instance, "skillResetButton");
            skillResetButton.SetInteractable(flag && OcPlMaster.Inst.SkillCtrl.ResettableAllSkills());
            OcUI_NewSkillTree.Inst.TryGamepadSelect();

            return false;
        }
    }

    internal class MyUtility
    {
        /// <summary>
        /// すべてのミッションカテゴリのクリア数を取得
        /// </summary>
        /// <returns></returns>
        internal static int GetCleardMissionInAllCategory()
        {
            IEnumerable<int> categoryIds = OcMissionManager.Inst.AllCategory().Select(n => n.ID);
            int result = 0;
            foreach (var id in categoryIds)
            {
                if (IsCompleatMissionCategory(id))
                    result += 1;
            }
            return result;
        }

        /// <summary>
        /// 同一カテゴリの未クリアミッション数を取得
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        internal static bool IsCompleatMissionCategory(int categoryId)
        {
            Mission[] missions = OcMissionManager.Inst.GetCategoryMissions(categoryId);
            if (missions == null)
                return false;
            // 未クリア数が0ならばすべてクリア済み
            bool result = missions.Where(n => n.IsRewardTaken == false).Count() == 0;

            return result;
        }
    }
}
