using BepInEx;
using HarmonyLib;
using Oc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace DamageFormatter
{
    [BepInPlugin(PluginGuid, PluginName, PluginVersion)]
    public class ExamplePlugin : BaseUnityPlugin
    {
        public const string PluginGuid = "FE365CC2-53B6-4DE3-936E-2483174AF5CA";
        public const string PluginName = "DamageFormatter";
        public const string PluginVersion = "0.0.1";

        private void Awake()
        {
            UnityEngine.Debug.Log($"{PluginName} : {PluginVersion}");
            new Harmony(PluginGuid).PatchAll();
        }

        [HarmonyPatch(typeof(OcUI_Damage.PopDamage))]
        private class OcUI_Damage_Hook
        {
            [HarmonyPatch("reqDmg"), HarmonyPostfix]
            private static void reqDmg(OcUI_Damage __instance, OcUI_Damage.PopDamageType type, Transform trans, Vector3 pos, float dmg)
            {
                UnityEngine.Debug.Log($"{dmg}");
            }
        }
    }
}
