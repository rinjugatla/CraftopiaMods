using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using Oc;
using Oc.Em;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace AnyHook
{
    [BepInPlugin(PluginGuid, PluginName, PluginVersion)]
    public class ExamplePlugin : BaseUnityPlugin
    {
        private const string PluginGuid = "me.rin_jugatla.craftopia.mod.AnyHook";
        private const string PluginName = "AnyHook";
        private const string PluginVersion = "0.0.1";

        void Awake()
        {
            new Harmony(PluginGuid).PatchAll();
        }
    }

    
    [HarmonyPatch(typeof(AsPl_AttackSword0))]
    internal class AsPl_AttackSword0_Hook
    {
        /// <summary>
        /// 剣を振るタイミング
        /// </summary>
        [HarmonyPatch("enter"), HarmonyPostfix]
        static void Enter()
        {

            UnityEngine.Debug.Log($"AsPl_AttackSword0 enter");
        }
    }

    
    [HarmonyPatch(typeof(AsPl_AttackSword1))]
    internal class AsPl_AttackSword1_Hook
    {
        /// <summary>
        /// 剣を振るタイミング
        /// </summary>
        [HarmonyPatch("enter"), HarmonyPostfix]
        static void Enter()
        {
            UnityEngine.Debug.Log($"AsPl_AttackSword1 enter");
        }
    }

    
    [HarmonyPatch(typeof(AsPl_AttackSword2))]
    internal class AsPl_AttackSword2_Hook
    {
        /// <summary>
        /// 剣を振るタイミング
        /// </summary>
        [HarmonyPatch("enter"), HarmonyPostfix]
        static void Enter()
        {
            UnityEngine.Debug.Log($"AsPl_AttackSword2 enter");
        }
    }

    
    [HarmonyPatch(typeof(OcCharacter))]
    internal class OcCharacter_Hook
    {
        /// <summary>
        /// キャラクタのジャンプ(NPC, MOBも含む
        /// </summary>
        [HarmonyPatch("jumped"), HarmonyPostfix]
        static void jumped()
        {
            UnityEngine.Debug.Log($"OcCharacter jumped");
        }
    }

    [HarmonyPatch(typeof(AsPl_AttackPickel))]
    internal class AsPl_AttackPickel_Hook
    {
        /// <summary>
        /// 
        /// </summary>
        [HarmonyPatch("enter"), HarmonyPostfix]
        static void Enter()
        {
            UnityEngine.Debug.Log($"AsPl_AttackPickel enter");
        }
    }

    [HarmonyPatch(typeof(AsPl_AttackShield))]
    internal class AsPl_AttackShield_Hook
    {
        /// <summary>
        /// 
        /// </summary>
        [HarmonyPatch("enter"), HarmonyPostfix]
        static void Enter()
        {
            UnityEngine.Debug.Log($"AsPl_AttackShield enter");
        }
    }

    [HarmonyPatch(typeof(AsPl_AttackHammer))]
    internal class AsPl_AttackHammer_Hook
    {
        /// <summary>
        /// 
        /// </summary>
        [HarmonyPatch("enter"), HarmonyPostfix]
        static void Enter()
        {
            UnityEngine.Debug.Log($"AsPl_AttackHammer enter");
        }
    }

    [HarmonyPatch(typeof(AsPl_AttackDashShield))]
    internal class AsPl_AttackDashShield_Hook
    {
        /// <summary>
        /// 
        /// </summary>
        [HarmonyPatch("enter"), HarmonyPostfix]
        static void Enter()
        {
            UnityEngine.Debug.Log($"AsPl_AttackDashShield enter");
        }
    }

    [HarmonyPatch(typeof(AsPl_AttackBucketEmpty))]
    internal class AsPl_AttackBucketEmpty_Hook
    {
        /// <summary>
        /// 
        /// </summary>
        [HarmonyPatch("enter"), HarmonyPostfix]
        static void Enter()
        {
            UnityEngine.Debug.Log($"AsPl_AttackBucketEmpty enter");
        }
    }

    [HarmonyPatch(typeof(AsPl_AttackAxe))]
    internal class AsPl_AttackAxe_Hook
    {
        /// <summary>
        /// 
        /// </summary>
        [HarmonyPatch("enter"), HarmonyPostfix]
        static void Enter()
        {
            UnityEngine.Debug.Log($"AsPl_AttackAxe enter");
        }
    }

    [HarmonyPatch(typeof(AsPl_AirJumpBow))]
    internal class AsPl_AirJumpBow_Hook
    {
        /// <summary>
        /// 
        /// </summary>
        [HarmonyPatch("enter"), HarmonyPostfix]
        static void Enter()
        {
            UnityEngine.Debug.Log($"AsPl_AirJumpBow enter");
        }
    }

    [HarmonyPatch(typeof(AsPl_AirJump))]
    internal class AsPl_AirJump_Hook
    {
        /// <summary>
        /// 
        /// </summary>
        [HarmonyPatch("enter"), HarmonyPostfix]
        static void Enter()
        {
            UnityEngine.Debug.Log($"AsPl_AirJump enter");
        }
    }

    [HarmonyPatch(typeof(AsPl_AirDash))]
    internal class AsPl_AirDash_Hook
    {
        /// <summary>
        /// 
        /// </summary>
        [HarmonyPatch("enter"), HarmonyPostfix]
        static void Enter()
        {
            UnityEngine.Debug.Log($"AsPl_AirDash enter");
        }
    }

    [HarmonyPatch(typeof(AsPl_Bow))]
    internal class AsPl_Bow_Hook
    {
        /// <summary>
        /// 
        /// </summary>
        [HarmonyPatch("enter"), HarmonyPostfix]
        static void Enter()
        {
            UnityEngine.Debug.Log($"AsPl_Bow enter");
        }

        /// <summary>
        /// 
        /// </summary>
        [HarmonyPatch("move"), HarmonyPostfix]
        static void Move()
        {
            UnityEngine.Debug.Log($"AsPl_Bow move");
        }
    }

    [HarmonyPatch(typeof(AsPl_Fall))]
    internal class AsPl_Fall_Hook
    {
        /// <summary>
        /// 
        /// </summary>
        [HarmonyPatch("enter"), HarmonyPostfix]
        static void Enter()
        {
            UnityEngine.Debug.Log($"AsPl_Fall enter");
        }

        /// <summary>
        /// 
        /// </summary>
        [HarmonyPatch("move"), HarmonyPostfix]
        static void Move()
        {
            UnityEngine.Debug.Log($"AsPl_Fall move");
        }

        /// <summary>
        /// 
        /// </summary>
        [HarmonyPatch("exit"), HarmonyPostfix]
        static void Exit()
        {
            UnityEngine.Debug.Log($"AsPl_Fall exit");
        }
    }

    [HarmonyPatch(typeof(AsPl_Eat))]
    internal class AsPl_Eat_Hook
    {
        /// <summary>
        /// 
        /// </summary>
        [HarmonyPatch("enterPlayAnim"), HarmonyPostfix]
        static void EnterPlayAnim()
        {
            UnityEngine.Debug.Log($"AsPl_Eat enterPlayAnim");
        }

        [HarmonyPatch("exit"), HarmonyPostfix]
        static void Exit()
        {
            UnityEngine.Debug.Log($"AsPl_Eat exit");
        }
    }

    [HarmonyPatch(typeof(AsPl_Skill_Heal))]
    internal class AsPl_Skill_Heal_Hook
    {
        [HarmonyPatch("enter"), HarmonyPostfix]
        static void Enter()
        {
            UnityEngine.Debug.Log($"AsPl_Skill_Heal enter");
        }

        [HarmonyPatch("move"), HarmonyPostfix]
        static void Move()
        {
            UnityEngine.Debug.Log($"AsPl_Skill_Heal move");
        }
    }

    /// <summary>
    /// チャットの決定にフック
    /// </summary>
    /// <param name="__instance"></param>
    /// <param name="message"></param>
    /// <returns></returns>
    [HarmonyPatch(typeof(OcUI_ChatHandler))]
    internal class OcUI_ChatHandler_Hook
    {
        [HarmonyPatch("TrySendMessage"), HarmonyPostfix]
        static void TrySendMessage(OcUI_ChatHandler __instance, string message)
        {
            UnityEngine.Debug.LogWarning($"TrySendMessage: {message}");
        }
    }
}
