using BepInEx;
using HarmonyLib;
using Oc.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SandBoxServerSide
{
    [BepInPlugin(PluginGuid, PluginName, PluginVersion)]
    public class ExamplePlugin : BaseUnityPlugin
    {
        public const string PluginGuid = "AAAAAAAA-2E0C-4C70-ABBA-C1t516E6377DD";
        public const string PluginName = "SandBoxServerSide";
        public const string PluginVersion = "0.0.1";

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

    [HarmonyPatch(typeof(OcNetRpc_AccountData))]
    internal class OcNetRpc_AccountData_Hook
    {
        /// <summary>
        /// キャラクタのジャンプ(NPC, MOBも含む
        /// </summary>
        [HarmonyPatch("Receive"), HarmonyPostfix]
        static void ReceivePre(OcNetRpc_AccountData __instance, int netPlId, OcAccountData accountData, int tgtNetPlId, int ignoreTgtNtPlId)
        {
            UnityEngine.Debug.Log($"OcNetRpc_AccountData Receive Pre");
            UnityEngine.Debug.Log($"AccountData ID: {accountData.AccountId}, Name: {accountData.PlayerName}");
        }

        [HarmonyPatch("Receive"), HarmonyPostfix]
        static void ReceivePost(OcNetRpc_AccountData __instance, int netPlId, OcAccountData accountData, int tgtNetPlId, int ignoreTgtNtPlId)
        {
            UnityEngine.Debug.Log($"OcNetRpc_AccountData Receive Post");
        }

    }
}
