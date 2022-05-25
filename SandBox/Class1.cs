using BepInEx;
using HarmonyLib;
using Oc;
using Oc.Network;
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
            new Harmony(PluginGuid).PatchAll();
            //Harmony harmony = new Harmony(PluginGuid);
            //MethodInfo original = AccessTools.Method(typeof(OcItemStack), "DoSwap");
            //MethodInfo patch = AccessTools.Method(typeof(OcItemStackDoSwap), "Prefix");
            //harmony.Patch(original, new HarmonyMethod(patch));
        }
    }

    /// <summary>
    /// 転移門画面表示にフック
    /// </summary>
    [HarmonyPatch(typeof(OcBldg_AltarOfWorld), "OpenWindow")]
    public class MyOcBldg_AltarOfWorld
    {
        [HarmonyPostfix]
        static void Postfix()
        {
            UnityEngine.Debug.Log($"OpenWindow");
        }
    }

    ///// <summary>
    ///// 釣りを行った際に1/2の確率で残り回数を消費しない
    ///// </summary>
    ///// <remarks>
    ///// https://discordapp.com/channels/505994577942151180/752946152160231534/753652553753034802
    ///// </remarks>
    //[HarmonyPatch(typeof(OcGimmick_FishingPoint), "doOpen")]
    //public class FishingPoint
    //{
    //    static void Prefix(OcGimmick_FishingPoint __instance)
    //    {
    //        int activatedCount = __instance.ActivateCount;
    //        System.Random r = new System.Random();

    //        if (r.Next(0, 2) == 0)
    //        {
    //            Traverse.Create(__instance).Field("_IsActivateCount").SetValue(activatedCount + 1);
    //            UnityEngine.Debug.Log("消費数を+1");
    //        }
    //    }
    //}

    ///// <summary>
    ///// キャラクタのジャンプにフック
    ///// </summary>
    //[HarmonyPatch(typeof(OcCharacter), "jumped")]
    //public class MyOcCharacter
    //{
    //    static void Postfix()
    //    {
    //        UnityEngine.Debug.Log($"jumped!!!!");
    //    }
    //}

    ///// <summary>
    ///// 剣を振るタイミングにフック(連続攻撃には非対応)
    ///// </summary>
    //[HarmonyPatch(typeof(AsPl_AttackSword0), "enter")]
    //public class AsPl_AttackSword0_enter
    //{
    //    static void Postfix()
    //    {
    //        UnityEngine.Debug.Log($"Sword!!!!");
    //    }
    //}

    //[HarmonyPatch(typeof(OcItemStack), "DoSwap", typeof(OcItemStack))]
    //public class OcItemStackDoSwap
    //{
    //    public static void Prefix(OcItemStack __instance, OcItemStack other)
    //    {
    //        //UnityEngine.Debug.Log($"From: {__instance.ItemName} : To{other.ItemName}");
    //    }
    //}

    [HarmonyPatch(typeof(OcNetRpc_Chat), "Send")]
    public class OcNetRpc_Chat_Hook1
    {
        [HarmonyPostfix]
        static void OcNetRpc_Chat_Send(OcNetRpc_Chat __instance, string msg)
        {
            Debug.Log($"OcNetRpc_Chat Send: {msg}");
        }

        //[HarmonyPatch("Receive"), HarmonyPostfix]
        //static void OcNetRpc_Chat_Receive(OcNetRpc_Chat __instance, IncomingChatMessageComponent state)
        //{
        //    Debug.Log($"OcNetRpc_Chat Receive: ID{state.FromNetPlId}, Message: {state.Message}");
        //}

        //[HarmonyPatch("ReceiveBroadcast"), HarmonyPostfix]
        //static void OcNetRpc_Chat_ReceiveBroadcast(OcNetRpc_Chat __instance, IncomingChatMessageComponent state)
        //{
        //    Debug.Log($"OcNetRpc_Chat ReceiveBroadcast: ID{state.FromNetPlId}, Message: {state.Message}");
        //}
    }

    [HarmonyPatch(typeof(OcNetRpc_Chat), "Receive")]
    public class OcNetRpc_Chat_Hook2
    {
        [HarmonyPostfix]
        static void OcNetRpc_Chat_Receive(OcNetRpc_Chat __instance, IncomingChatMessageComponent state)
        {
            Debug.Log($"OcNetRpc_Chat Receive: ID{state.FromNetPlId}, Message: {state.Message}");
        }
    }

    [HarmonyPatch(typeof(OcNetRpc_Chat), "ReceiveBroadcast")]
    public class OcNetRpc_Chat_Hook3
    {
        [HarmonyPostfix]
        static void OcNetRpc_Chat_ReceiveBroadcast(OcNetRpc_Chat __instance, IncomingChatMessageComponent state)
        {
            Debug.Log($"OcNetRpc_Chat ReceiveBroadcast: ID{state.FromNetPlId}, Message: {state.Message}");
        }
    }
}
