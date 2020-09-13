using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BepInEx;
using HarmonyLib;
using MapMagic;
using Oc.Item;
using Oc.Missions;

namespace AnyListLogger
{
    [BepInPlugin(PluginGuid, PluginName, PluginVersion)]
    public class ExamplePlugin : BaseUnityPlugin
    {
        private const string PluginGuid = "2AA56D88-A06D-4790-89E7-5192585E1A41";
        private const string PluginName = "AnyListLogger";
        private const string PluginVersion = "0.0.1";

        private const string ItemLogFilepath = @"E:\SteamLibrary\steamapps\common\Craftopia\Log\ItemList.csv";
        private const string MissionLogFilepath = @"E:\SteamLibrary\steamapps\common\Craftopia\Log\MissionList.csv";

        void Awake()
        {
            UnityEngine.Debug.Log($"{PluginName} : {PluginVersion}");
            Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly());
        }

        /// <summary>
        /// アイテムリストをログファイルに出力
        /// </summary>
        [HarmonyPatch(typeof(OcItemDataMng), "SetupCraftableItems")]
        public class CraftableItemLogger
        {
            static bool Prefix(OcItemDataMng __instance, ref ItemData[] ___validItemDataList)
            {
                using (StreamWriter sw = new StreamWriter(ItemLogFilepath, false, Encoding.UTF8))
                {
                    foreach (var item in ___validItemDataList)
                    {
                        sw.WriteLine($"{item.Id},{item.DisplayName}");
                    }
                }
                // trueを返すとそのまま通常の処理を継続、falseで継続処理を中止
                return true;
            }
        }


        [HarmonyPatch(typeof(OcMissionManager), "LoadData")]
        public class OcMissionManagerLogger
        {
            static void Postfix(OcMissionManager __instance)
            {
                Mission[] missions = Traverse.Create(__instance).Field("validMissionList").GetValue<Mission[]>();

                using (StreamWriter sw = new StreamWriter(MissionLogFilepath, false, Encoding.UTF8))
                {
                    foreach (var mission in missions)
                    {
                        sw.WriteLine($"{mission.ID},{mission.Category},{mission.Title},{mission.Desc},{mission.IsRewardTaken}");
                    }
                }
            }
        }
    }
}
