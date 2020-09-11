using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BepInEx;
using HarmonyLib;
using Oc;
using Oc.Em;

namespace SandBox
{
    [BepInPlugin(PluginGuid, PluginName, PluginVersion)]
    public class ExamplePlugin : BaseUnityPlugin
    {
        public const string PluginGuid = "E90CEB4C-2E0C-4C70-ABBA-C1t516E6377DD";
        public const string PluginName = "SandBox";
        public const string PluginVersion = "0.0.2";

        void Awake()
        {
            UnityEngine.Debug.Log($"{PluginName} : {PluginVersion}");
            Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly());
        }
    }

    /// <summary>
    /// 釣りを行った際に1/2の確率で残り回数を消費しない
    /// </summary>
    /// <remarks>
    /// https://discordapp.com/channels/505994577942151180/752946152160231534/753652553753034802
    /// </remarks>
    [HarmonyPatch(typeof(OcGimmick_FishingPoint), "doOpen")]
    public class FishingPoint
    {
        static void Prefix(OcGimmick_FishingPoint __instance)
        {
            int activatedCount = __instance.ActivateCount;
            System.Random r = new System.Random();

            if (r.Next(0, 2) == 0)
            {
                Traverse.Create(__instance).Field("_IsActivateCount").SetValue(activatedCount + 1);
                UnityEngine.Debug.Log("消費数を+1");
            }

        }
    }
}
