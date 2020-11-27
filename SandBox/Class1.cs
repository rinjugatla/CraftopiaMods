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
using Oc.Item;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

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
            //Harmony harmony = new Harmony(PluginGuid);
            //MethodInfo original = AccessTools.Method(typeof(OcItemStack), "DoSwap");
            //MethodInfo patch = AccessTools.Method(typeof(OcItemStackDoSwap), "Prefix");
            //harmony.Patch(original, new HarmonyMethod(patch));
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

    /// <summary>
    /// キャラクタのジャンプにフック
    /// </summary>
    [HarmonyPatch(typeof(OcCharacter), "jumped")]
    public class MyOcCharacter
    {
        static void Postfix()
        {
            UnityEngine.Debug.Log($"jumped!!!!");
        }
    }

    /// <summary>
    /// 剣を振るタイミングにフック(連続攻撃には非対応)
    /// </summary>
    [HarmonyPatch(typeof(AsPl_AttackSword0), "enter")]
    public class AsPl_AttackSword0_enter
    {
        static void Postfix()
        {
            UnityEngine.Debug.Log($"Sword!!!!");
        }
    }

    [HarmonyPatch(typeof(OcItemStack), "DoSwap", typeof(OcItemStack))]
    public class OcItemStackDoSwap
    {
        public static void Prefix(OcItemStack __instance, OcItemStack other)
        {
            //UnityEngine.Debug.Log($"From: {__instance.ItemName} : To{other.ItemName}");
        }
    }
}
