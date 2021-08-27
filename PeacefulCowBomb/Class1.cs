using BepInEx;
using HarmonyLib;
using Oc;
using Oc.Em;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PeacefulCowBomb
{
    [BepInPlugin(PluginGuid, PluginName, PluginVersion)]
    public class ExamplePlugin : BaseUnityPlugin
    {
        private const string PluginGuid = "me.rin_jugatla.craftopia.mod.PeacefulCowBomb";
        private const string PluginName = "PeacefulCowBomb";
        private const string PluginVersion = "0.0.2";

        void Awake()
        {
            var harmony = new Harmony(PluginGuid);
            harmony.PatchAll();
        }
    }

    /// <summary>
    /// 自爆牛
    /// </summary>
    [HarmonyPatch(typeof(OcEm_CowBomb))]
    internal class OcEm_CowBomb_Hook
    {
        /// <summary>
        /// 火を無効化
        /// </summary>
        /// <param name="__instance"></param>
        [HarmonyPatch("makeActionTable"), HarmonyPrefix]
        static void MakeActionTable(OcEm_CowBomb __instance)
        {
            Traverse.Create(__instance.Condition).Field("IgnoreFire").SetValue(true);
        }

        /// <summary>
        /// 爆発ダメージ
        /// </summary>
        /// <param name="__result"></param>
        /// <returns></returns>
        [HarmonyPatch("deathExplosionDmg"), HarmonyPrefix]
        static bool DeathExplosionDmg(ref float __result)
        {
            __result = 0;
            return false;
        }

        /// <summary>
        /// 爆発サイズ
        /// </summary>
        /// <param name="__result"></param>
        /// <returns></returns>
        [HarmonyPatch("deathExplosionScale"), HarmonyPrefix]
        static bool DeathExplosionScale(ref float __result)
        {
            __result = 0;
            return false;
        }
    }
}
