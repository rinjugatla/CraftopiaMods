using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using Oc;
using Oc.Achievements;
using Oc.Em;
using Oc.Item;
using Oc.Item.UI;
using Oc.Statistical;
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

    [HarmonyPatch(typeof(OcEmMng))]
    internal class OcEmMng_Hook
    {
        [HarmonyPatch("doSpawn_FreeSlot_CheckHost"), HarmonyPostfix]
        static void DoSpawn_FreeSlot_CheckHost(OcEmMng __instance, OcEmType emType, Vector3 pos, Quaternion quat, 
            byte level, bool isCharm = false, OcSpawner spawner = null, 
            int petId = 65535, int petOwnerPlId = -1, bool forceIgnoreSave = false, 
            OcCondition.EnemyStrongType? enemyStrongType = null)
        {
            UnityEngine.Debug.Log($"OcEmMng doSpawn_FreeSlot_CheckHost");
        }
    }

    #region 剣
    [HarmonyPatch(typeof(AsPl_AttackSword0))]
    internal class AsPl_AttackSword0_Hook
    {
        [HarmonyPatch("enter"), HarmonyPostfix]
        static void enter()
        {
            UnityEngine.Debug.Log($"AsPl_AttackSword0 enter");
        }
    }


    [HarmonyPatch(typeof(AsPl_AttackSword1))]
    internal class AsPl_AttackSword1_Hook
    {
        /// <summary>
        /// 剣を振るタイミング2段階め
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
        /// 剣を振るタイミング3段階め
        /// </summary>
        [HarmonyPatch("enter"), HarmonyPostfix]
        static void Enter()
        {
            UnityEngine.Debug.Log($"AsPl_AttackSword2 enter");
        }
    }


    [HarmonyPatch(typeof(AsPl_AttackSwordChargeEnd))]
    internal class AsPl_AttackSwordChargeEnd_Hook
    {
        [HarmonyPatch("enter"), HarmonyPostfix]
        static void Enter()
        {
            UnityEngine.Debug.Log($"AsPl_AttackSwordChargeEnd enter");
        }

        [HarmonyPatch("move"), HarmonyPostfix]
        static void Move()
        {
            UnityEngine.Debug.Log($"AsPl_AttackSwordChargeEnd move");
        }

        [HarmonyPatch("attackCancel_Main"), HarmonyPostfix]
        static void AttackCancel_Main()
        {
            UnityEngine.Debug.Log($"AsPl_AttackSwordChargeEnd attackCancel_Main");
        }
    }

    [HarmonyPatch(typeof(AsPl_AttackSwordChargeLoop))]
    internal class AsPl_AttackSwordChargeLoop_Hook
    {
        [HarmonyPatch("enter"), HarmonyPostfix]
        static void Enter()
        {
            UnityEngine.Debug.Log($"AsPl_AttackSwordChargeLoop enter");
        }

        [HarmonyPatch("move"), HarmonyPostfix]
        static void Move()
        {
            UnityEngine.Debug.Log($"AsPl_AttackSwordChargeLoop move");
        }
    }

    [HarmonyPatch(typeof(AsPl_AttackSwordChargeStart))]
    internal class AsPl_AttackSwordChargeStart_Hook
    {
        [HarmonyPatch("enter"), HarmonyPostfix]
        static void Enter()
        {
            UnityEngine.Debug.Log($"AsPl_AttackSwordChargeStart enter");
        }

        [HarmonyPatch("move"), HarmonyPostfix]
        static void Move()
        {
            UnityEngine.Debug.Log($"AsPl_AttackSwordChargeStart move");
        }
    }
    #endregion

    #region Attack
    [HarmonyPatch(typeof(AsPl_AttackAxe))]
    internal class AsPl_AttackAxe_Hook
    {
        [HarmonyPatch("enter"), HarmonyPostfix]
        static void Enter()
        {
            UnityEngine.Debug.Log($"AsPl_AttackAxe enter");
        }
    }

    [HarmonyPatch(typeof(AsPl_AttackBucketEmpty))]
    internal class AsPl_AttackBucketEmpty_Hook
    {
        [HarmonyPatch("enter"), HarmonyPostfix]
        static void Enter()
        {
            UnityEngine.Debug.Log($"AsPl_AttackBucketEmpty enter");
        }
    }

    [HarmonyPatch(typeof(AsPl_Bucket))]
    internal class AsPl_Bucket_Hook
    {
        [HarmonyPatch("enter"), HarmonyPostfix]
        static void Enter()
        {
            UnityEngine.Debug.Log($"AsPl_Bucket enter");
        }

        [HarmonyPatch("exit"), HarmonyPostfix]
        static void Exit()
        {
            UnityEngine.Debug.Log($"AsPl_Bucket exit");
        }
    }

    [HarmonyPatch(typeof(AsPl_AttackDashShield))]
    internal class AsPl_AttackDashShield_Hook
    {
        [HarmonyPatch("enter"), HarmonyPostfix]
        static void Enter()
        {
            UnityEngine.Debug.Log($"AsPl_AttackDashShield enter");
        }
    }

    [HarmonyPatch(typeof(AsPl_AttackHammer))]
    internal class AsPl_AttackHammer_Hook
    {
        [HarmonyPatch("enter"), HarmonyPostfix]
        static void Enter()
        {
            UnityEngine.Debug.Log($"AsPl_AttackHammer enter");
        }
    }

    [HarmonyPatch(typeof(AsPl_AttackPickel))]
    internal class AsPl_AttackPickel_Hook
    {
        [HarmonyPatch("enter"), HarmonyPostfix]
        static void Enter()
        {
            UnityEngine.Debug.Log($"AsPl_AttackPickel enter");
        }
    }

    [HarmonyPatch(typeof(AsPl_AttackShield))]
    internal class AsPl_AttackShield_Hook
    {
        [HarmonyPatch("enter"), HarmonyPostfix]
        static void Enter()
        {
            UnityEngine.Debug.Log($"AsPl_AttackShield enter");
        }
    }

    [HarmonyPatch(typeof(AsPl_AttackTorch))]
    internal class AsPl_AttackTorch_Hook
    {
        [HarmonyPatch("enter"), HarmonyPostfix]
        static void Enter()
        {
            UnityEngine.Debug.Log($"AsPl_AttackTorch enter");
        }

        [HarmonyPatch("move"), HarmonyPostfix]
        static void Move()
        {
            UnityEngine.Debug.Log($"AsPl_AttackTorch move");
        }
    }

    [HarmonyPatch(typeof(AsPl_AttackTorchTwoHand))]
    internal class AsPl_AttackTorchTwoHand_Hook
    {
        [HarmonyPatch("enter"), HarmonyPostfix]
        static void Enter()
        {
            UnityEngine.Debug.Log($"AsPl_AttackTorchTwoHand enter");
        }
    }
    #endregion

    [HarmonyPatch(typeof(AsPl_AirJump))]
    internal class AsPl_AirJump_Hook
    {
        [HarmonyPatch("enter"), HarmonyPostfix]
        static void Enter()
        {
            UnityEngine.Debug.Log($"AsPl_AirJump enter");
        }
    }

    [HarmonyPatch(typeof(AsPl_AirDash))]
    internal class AsPl_AirDash_Hook
    {
        [HarmonyPatch("enter"), HarmonyPostfix]
        static void Enter()
        {
            UnityEngine.Debug.Log($"AsPl_AirDash enter");
        }
    }

    #region 弓
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

    [HarmonyPatch(typeof(AsPlSub_BowLoop))]
    internal class AsPlSub_BowLoop_Hook
    {
        [HarmonyPatch("playAnim"), HarmonyPostfix]
        static void PlayAnim()
        {
            UnityEngine.Debug.Log($"AsPlSub_BowLoop playAnim");
        }
    }

    [HarmonyPatch(typeof(AsPlSub_BowNoAmmo))]
    internal class AsPlSub_BowNoAmmo_Hook
    {
        [HarmonyPatch("playAnim"), HarmonyPostfix]
        static void PlayAnim()
        {
            UnityEngine.Debug.Log($"AsPlSub_BowNoAmmo playAnim");
        }
    }

    [HarmonyPatch(typeof(AsPlSub_BowShot))]
    internal class AsPlSub_BowShot_Hook
    {
        [HarmonyPatch("playAnim"), HarmonyPostfix]
        static void PlayAnim()
        {
            UnityEngine.Debug.Log($"AsPlSub_BowShot playAnim");
        }
    }

    [HarmonyPatch(typeof(AsPlSub_BowStart))]
    internal class AsPlSub_BowStart_Hook
    {
        [HarmonyPatch("playAnim"), HarmonyPostfix]
        static void PlayAnim()
        {
            UnityEngine.Debug.Log($"AsPlSub_BowStart playAnim");
        }
    }

    [HarmonyPatch(typeof(AsPlSub_BowWpOn))]
    internal class AsPlSub_BowWpOn_Hook
    {
        [HarmonyPatch("playAnim"), HarmonyPostfix]
        static void PlayAnim()
        {
            UnityEngine.Debug.Log($"AsPlSub_BowWpOn playAnim");
        }

        [HarmonyPatch("move"), HarmonyPostfix]
        static void Move()
        {
            UnityEngine.Debug.Log($"AsPlSub_BowWpOn move");
        }
    }

    [HarmonyPatch(typeof(AsPlSub_BowWpOff))]
    internal class AsPlSub_BowWpOff_Hook
    {
        [HarmonyPatch("playAnim"), HarmonyPostfix]
        static void PlayAnim()
        {
            UnityEngine.Debug.Log($"AsPlSub_BowWpOff playAnim");
        }

        [HarmonyPatch("move"), HarmonyPostfix]
        static void Move()
        {
            UnityEngine.Debug.Log($"AsPlSub_BowWpOff move");
        }
    }
    #endregion

    [HarmonyPatch(typeof(OcItemUI_InventoryMng))]
    internal class OcItemUI_InventoryMng_Hook
    {
        [HarmonyPatch("GetItemCount"), HarmonyPostfix]
        static void GetItemCount(OcItemUI_InventoryMng __instance, ItemData item, object __originalMethod, bool containsEquip = false)
        {
            UnityEngine.Debug.Log($"OcItemUI_InventoryMng GetItemCount");

            if (item.IsNullOrEmpty())
            {
                return;
            }
            int num = 0;
            OcItemUI_Cell_List cellList = Traverse.Create(__instance).Method("GetCellList", item.ItemType).GetValue<OcItemUI_Cell_List>();
            if (cellList != null)
            {
                num += cellList.GetItemCount(item, containsEquip);
            }
        }
    }

    /// <summary>
    /// これを使うといろいろ楽に解決しそう
    /// </summary>
    [HarmonyPatch(typeof(StatisticalDataManager))]
    internal class StatisticalDataManager_Hook
    {
        [HarmonyPatch("AddItemTook"), HarmonyPostfix]
        static void AddItemTook(StatisticalDataManager __instance, int itemID, int addCount, int numOfPossessions)
        {
            int a = 10;
        }
    }

    #region キャラクタ
    [HarmonyPatch(typeof(OcCharacter))]
    internal class OcCharacter_Hook
    {
        /// <summary>
        /// キャラクタのジャンプ(NPC, MOBも含む
        /// </summary>
        [HarmonyPatch("jumped"), HarmonyPostfix]
        static void Jumped()
        {
            UnityEngine.Debug.Log($"OcCharacter jumped");
        }

        [HarmonyPatch("calcDropExp"), HarmonyPostfix]
        static void CalcDropExp()
        {
            UnityEngine.Debug.Log($"OcCharacter calcDropExp");
        }
    }

    /// <summary>
    /// 
    /// </summary>
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
    #endregion

    //[HarmonyPatch(typeof(AsPlSub_Default))]
    //internal class AsPlSub_Default_Hook
    //{
    //    [HarmonyPatch("enter"), HarmonyPostfix]
    //    static void Enter()
    //    {
    //        UnityEngine.Debug.Log($"AsPlSub_Default enter");
    //    }

    //    [HarmonyPatch("move"), HarmonyPostfix]
    //    static void Move(AsPlSub_Default __instance)
    //    {
    //        UnityEngine.Debug.Log($"AsPlSub_Default move");
    //    }

    //    [HarmonyPatch("exit"), HarmonyPostfix]
    //    static void Exit()
    //    {
    //        UnityEngine.Debug.Log($"AsPlSub_Default exit");
    //    }
    //}

    [HarmonyPatch(typeof(AsPlSub_Drink))]
    internal class AsPlSub_Drink_Hook
    {
        [HarmonyPatch("playAnim"), HarmonyPostfix]
        static void PlayAnim()
        {
            UnityEngine.Debug.Log("AsPlSub_Drink playAnim");
        }
    }

    [HarmonyPatch(typeof(AsPlSub_GuardLoop))]
    internal class AsPlSub_GuardLoop_Hook
    {
        [HarmonyPatch("playAnim"), HarmonyPostfix]
        static void PlayAnim()
        {
            UnityEngine.Debug.Log("AsPlSub_GuardLoop playAnim");
        }
    }

    #region 銃
    [HarmonyPatch(typeof(AsPlSub_GunNoAmmo))]
    internal class AsPlSub_GunNoAmmo_Hook
    {
        [HarmonyPatch("playAnim"), HarmonyPostfix]
        static void PlayAnim()
        {
            UnityEngine.Debug.Log("AsPlSub_GunNoAmmo playAnim");
        }

        [HarmonyPatch("move"), HarmonyPostfix]
        static void Move()
        {
            UnityEngine.Debug.Log("AsPlSub_GunNoAmmo move");
        }
    }

    [HarmonyPatch(typeof(AsPlSub_GunReload))]
    internal class AsPlSub_GunReload_Hook
    {
        [HarmonyPatch("playAnim"), HarmonyPostfix]
        static void PlayAnim()
        {
            UnityEngine.Debug.Log("AsPlSub_GunReload playAnim");
        }

        [HarmonyPatch("move"), HarmonyPostfix]
        static void Move()
        {
            UnityEngine.Debug.Log("AsPlSub_GunReload move");
        }
    }

    [HarmonyPatch(typeof(AsPlSub_GunShot))]
    internal class AsPlSub_GunShot_Hook
    {
        [HarmonyPatch("playAnim"), HarmonyPostfix]
        static void PlayAnim()
        {
            UnityEngine.Debug.Log("AsPlSub_GunShot playAnim");
        }
    }

    [HarmonyPatch(typeof(AsPlSub_GunWpOn))]
    internal class AsPlSub_GunWpOn_Hook
    {
        [HarmonyPatch("playAnim"), HarmonyPostfix]
        static void PlayAnim()
        {
            UnityEngine.Debug.Log("AsPlSub_GunWpOn playAnim");
        }

        [HarmonyPatch("move"), HarmonyPostfix]
        static void Move()
        {
            UnityEngine.Debug.Log("AsPlSub_GunWpOn move");
        }
    }

    [HarmonyPatch(typeof(AsPlSub_GunWpOff))]
    internal class AsPlSub_GunWpOff_Hook
    {
        [HarmonyPatch("playAnim"), HarmonyPostfix]
        static void PlayAnim()
        {
            UnityEngine.Debug.Log("AsPlSub_GunWpOff playAnim");
        }

        [HarmonyPatch("move"), HarmonyPostfix]
        static void Move()
        {
            UnityEngine.Debug.Log("AsPlSub_GunWpOff move");
        }
    }
    #endregion

    #region Install
    [HarmonyPatch(typeof(AsPlSub_InstallEnd))]
    internal class AsPlSub_InstallEnd_Hook
    {
        [HarmonyPatch("playAnim"), HarmonyPostfix]
        static void PlayAnim()
        {
            UnityEngine.Debug.Log("AsPlSub_InstallEnd playAnim");
        }

        [HarmonyPatch("move"), HarmonyPostfix]
        static void Move()
        {
            UnityEngine.Debug.Log("AsPlSub_InstallEnd move");
        }
    }

    [HarmonyPatch(typeof(AsPlSub_InstallLoop))]
    internal class AsPlSub_InstallLoop_Hook
    {
        [HarmonyPatch("playAnim"), HarmonyPostfix]
        static void PlayAnim()
        {
            UnityEngine.Debug.Log("AsPlSub_InstallLoop playAnim");
        }
    }

    [HarmonyPatch(typeof(AsPlSub_InstallPut))]
    internal class AsPlSub_InstallPut_Hook
    {
        [HarmonyPatch("playAnim"), HarmonyPostfix]
        static void PlayAnim()
        {
            UnityEngine.Debug.Log("AsPlSub_InstallPut playAnim");
        }

        [HarmonyPatch("move"), HarmonyPostfix]
        static void Move()
        {
            UnityEngine.Debug.Log("AsPlSub_InstallPut move");
        }
    }

    [HarmonyPatch(typeof(AsPlSub_InstallStart))]
    internal class AsPlSub_InstallStart_Hook
    {
        [HarmonyPatch("playAnim"), HarmonyPostfix]
        static void PlayAnim()
        {
            UnityEngine.Debug.Log("AsPlSub_InstallStart playAnim");
        }

        [HarmonyPatch("move"), HarmonyPostfix]
        static void Move()
        {
            UnityEngine.Debug.Log("AsPlSub_InstallStart move");
        }
    }
    #endregion

    [HarmonyPatch(typeof(AsPlSub_Juggling))]
    internal class AsPlSub_Juggling_Hook
    {
        [HarmonyPatch("playAnim"), HarmonyPostfix]
        static void PlayAnim()
        {
            UnityEngine.Debug.Log("AsPlSub_Juggling playAnim");
        }
    }

    #region Lift
    [HarmonyPatch(typeof(AsPlSub_LiftDown))]
    internal class AsPlSub_LiftDown_Hook
    {
        [HarmonyPatch("playAnim"), HarmonyPostfix]
        static void PlayAnim()
        {
            UnityEngine.Debug.Log("AsPlSub_LiftDown playAnim");
        }
    }

    [HarmonyPatch(typeof(AsPlSub_LiftIdle))]
    internal class AsPlSub_LiftIdle_Hook
    {
        [HarmonyPatch("playAnim"), HarmonyPostfix]
        static void PlayAnim()
        {
            UnityEngine.Debug.Log("AsPlSub_LiftIdle playAnim");
        }

        [HarmonyPatch("move"), HarmonyPostfix]
        static void Move()
        {
            UnityEngine.Debug.Log("AsPlSub_LiftIdle move");
        }

        [HarmonyPatch("exit"), HarmonyPostfix]
        static void Exit()
        {
            UnityEngine.Debug.Log("AsPlSub_LiftIdle exit");
        }
    }

    [HarmonyPatch(typeof(AsPlSub_LiftThrow))]
    internal class AsPlSub_LiftThrow_Hook
    {
        [HarmonyPatch("playAnim"), HarmonyPostfix]
        static void PlayAnim()
        {
            UnityEngine.Debug.Log("AsPlSub_LiftThrow playAnim");
        }
    }
    #endregion

    [HarmonyPatch(typeof(AsPlSub_PickelUpper))]
    internal class AsPlSub_PickelUpper_Hook
    {
        [HarmonyPatch("playAnim"), HarmonyPostfix]
        static void PlayAnim()
        {
            UnityEngine.Debug.Log("AsPlSub_PickelUpper playAnim");
        }

        [HarmonyPatch("move"), HarmonyPostfix]
        static void Exit()
        {
            UnityEngine.Debug.Log("AsPlSub_PickelUpper move");
        }
    }

    #region RecallRod
    [HarmonyPatch(typeof(AsPlSub_RecallRod))]
    internal class AsPlSub_RecallRod_Hook
    {
        [HarmonyPatch("playAnim"), HarmonyPostfix]
        static void PlayAnim()
        {
            UnityEngine.Debug.Log("AsPlSub_RecallRod playAnim");
        }
    }

    [HarmonyPatch(typeof(AsPlSub_RecallRodShot))]
    internal class AsPlSub_RecallRodShot_Hook
    {
        [HarmonyPatch("playAnim"), HarmonyPostfix]
        static void PlayAnim()
        {
            UnityEngine.Debug.Log("AsPlSub_RecallRodShot playAnim");
        }
    }
    #endregion

    [HarmonyPatch(typeof(AsPlSub_TakeItem))]
    internal class AsPlSub_TakeItem_Hook
    {
        [HarmonyPatch("playAnim"), HarmonyPostfix]
        static void PlayAnim()
        {
            UnityEngine.Debug.Log("AsPlSub_TakeItem playAnim");
        }
    }

    [HarmonyPatch(typeof(AsPlSub_TwoHand))]
    internal class AsPlSub_TwoHand_Hook
    {
        [HarmonyPatch("playAnim"), HarmonyPostfix]
        static void PlayAnim()
        {
            UnityEngine.Debug.Log("AsPlSub_TwoHand playAnim");
        }
    }

    [HarmonyPatch(typeof(AsPlSub_WallHit))]
    internal class AsPlSub_WallHit_Hook
    {
        [HarmonyPatch("playAnim"), HarmonyPostfix]
        static void PlayAnim()
        {
            UnityEngine.Debug.Log("AsPlSub_WallHit playAnim");
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

    [HarmonyPatch(typeof(OcHealth))]
    internal class OcHealth_Hook
    {
        /// <summary>
        /// solveDmgMsg Prefixが呼ばれたときの生存状態
        /// </summary>
        static bool IsAliveSolveDmgMsg_Prefix = false;
        /// <summary>
        /// solveDmgMsg Prefixが呼ばれたときにHP
        /// </summary>
        static float HpSolveDmgMsg_Prefix = 0f;

        /// <summary>
        /// ダメージ計算
        /// </summary>
        /// <param name="__instance"></param>
        /// <param name="dmgMsg"></param>
        /// <param name="dmgMsgRcvChange"></param>
        /// <param name="____NeedSolveStaticObj_ForInstallObj"></param>
        [HarmonyPatch("solveDmgMsg"), HarmonyPrefix]
        static void SolveDmgMsg_Prefix(OcHealth __instance, OcDamageMsg dmgMsg, OcDamageMsg_RcvChange dmgMsgRcvChange)
        {
            IsAliveSolveDmgMsg_Prefix = __instance.IsAlive;
            HpSolveDmgMsg_Prefix = __instance.HP;

            // 死亡チェック
            if (!__instance.IsAlive)
                return;

            OcEm ocEm = __instance.Em;
            //if (ocEm != null)
            //    UnityEngine.Debug.Log($"{ocEm}");

            //if(dmgMsg.attackType == OcAttackType.Slip)
            //    UnityEngine.Debug.Log($"スリップダメージ: {dmgMsg.motDamage}");

            int a = 10;
        }

        [HarmonyPatch("solveDmgMsg"), HarmonyPostfix]
        static void SolveDmgMsg_Postfix(OcHealth __instance, OcDamageMsg dmgMsg, OcDamageMsg_RcvChange dmgMsgRcvChange)
        {

            float damage = HpSolveDmgMsg_Prefix - __instance.HP;
            bool nowDeath = IsAliveSolveDmgMsg_Prefix && !__instance.IsAlive;

            // HP計算前に死亡してる場合は処理不要
            if (!IsAliveSolveDmgMsg_Prefix)
                return;

            // 敵がオブジェクトに攻撃したとき
            if (__instance.IsInstallObj)
                return;

            bool isPlayer2Enemy = !__instance.IsPlMaster;
            OcEm ocEm = __instance.Em;
            if (ocEm == null)
                ocEm = dmgMsg?.attackerTrans?.GetComponent<OcEm>();

            string enemyName = null;
            bool isBoss = false;
            if (ocEm != null)
            {
                enemyName = ocEm.SoEm.name;
                isBoss = ocEm.SoEm.IsBoss;
            }
            OcPl ocPlTemp = dmgMsg?.attackerTrans?.GetComponent<OcPl>();

            string death = "";
            if (nowDeath)
                death = "死亡";

            if (dmgMsg.attackType == OcAttackType.Slip)
            {
                //UnityEngine.Debug.Log($"スリップダメージ: {enemyName} {dmgMsg.motDamage}");
                return;
            }

             if (isPlayer2Enemy)
              UnityEngine.Debug.Log($"プレイヤー -> {enemyName} {damage} {death}");
            else
                UnityEngine.Debug.Log($"{enemyName} -> プレイヤー {damage} {death}");
        }

        /// <summary>
        /// ダメージ表示
        /// </summary>
        /// <param name="__instance"></param>
        /// <param name="value"></param>
        /// <param name="ignoreShield"></param>
        /// <param name="msg"></param>
        //[HarmonyPatch("ChangeHp"), HarmonyPrefix]
        //static void ChangeHp(OcHealth __instance, float value, bool ignoreShield, OcDamageMsg msg)
        //{
        //    int a = 10;
        //}
    }

    [HarmonyPatch(typeof(OcAchievement_BuildCount))]
    internal class OcAchievement_BuildCount_Hook
    {
        [HarmonyPatch("OnBuildingBuild"), HarmonyPostfix]
        static void OnBuildingBuild(int itemID)
        {
            UnityEngine.Debug.Log($"OnBuildingBuild {itemID}");
        }
    }

    [HarmonyPatch(typeof(OcAchievement_ItemCraftCount))]
    internal class OcAchievement_ItemCraftCount_Hook
    {
        [HarmonyPatch("OnItemCraft"), HarmonyPostfix]
        static void OnItemCraft(OcItem item, int addCount)
        {
            UnityEngine.Debug.Log($"OnItemCraft {item} {addCount}");
        }
    }

    [HarmonyPatch(typeof(OcAchievement_ItemTookCount))]
    internal class OcAchievement_ItemTookCount_Hook
    {
        [HarmonyPatch("OnItemTook"), HarmonyPostfix]
        static void OnItemTook(int itemID, int addCount, int numOfPossessions)
        {
            UnityEngine.Debug.Log($"OnItemTook {itemID} {addCount} {numOfPossessions}");
        }
    }

    [HarmonyPatch(typeof(OcAchievement_KillCount))]
    internal class OcAchievement_KillCount_Hook
    {
        [HarmonyPatch("OnEnemyKill"), HarmonyPostfix]
        static void OnEnemyKill(OcEm enemy)
        {
            UnityEngine.Debug.Log($"OnEnemyKill {enemy}");
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


    [HarmonyPatch(typeof(AsPl_FallBase))]
    internal class AsPl_FallBase_Hook
    {
        [HarmonyPatch("move"), HarmonyPrefix]
        static void Move(AsPl_FallBase __instance, Transform ____Trans, OcPl ____Pl)
        {
            float fallDistance = ____Trans.position.y - ____Pl.FallStartY;
            bool isFallDiveFallDist = fallDistance < ____Pl.SoPl.Fall_DiveFallDist;
            bool idGndDist = ____Pl.GndDist < -80f;
        }
    }

    

    [HarmonyPatch(typeof(OcPl))]
    internal class OcPl_Hook
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="__instance"></param>
        [HarmonyPatch("checkLand_FromFall"), HarmonyPrefix]
        static void CheckLand_FromFall(OcPl __instance)
        {
            float num = __instance.TransSelf.position.y - __instance.FallStartY;
            if(__instance.IsGnd)
            {
                int a = 0;
            }
        }

        /// <summary>
        /// アイテム情報取得
        /// </summary>
        /// <param name="___validItemDataList"></param>
        [HarmonyPatch("checkFallDamage"), HarmonyPrefix]
        static void CheckFallDamage(OcPl __instance, float ____FallStartY)
        {
            if (!__instance.IsMaster)
            {
                return;
            }
            float num = __instance.TransSelf.position.y - ____FallStartY;
            if (num > __instance.SoPl.Fall_LandHighDist)
            {
                return;
            }
            float num2 = Mathf.Abs(num + __instance.SoPl.Fall_LandHighDist) * 0.0069999998f * __instance.SkillCtrl.PerfectLander_DefRate;
            float damage = -(__instance.Health.MaxHP * num2);
        }
    }

    /// <summary>
    /// アイテムデータ
    /// </summary>
    [HarmonyPatch(typeof(OcItemDataMng))]
    internal class OcItemDataMng_Hook
    {
        private static Dictionary<int, ItemData> ItemDict = new Dictionary<int, ItemData>();

        /// <summary>
        /// アイテム情報取得
        /// </summary>
        /// <param name="___validItemDataList"></param>
        [HarmonyPatch("SetupCraftableItems"), HarmonyPrefix]
        static void SetupCraftableItems(ref ItemData[] ___validItemDataList)
        {
            foreach (var item in ___validItemDataList)
            {
                ItemDict[item.Id] = item;
            }
        }

        /// <summary>
        /// アイテムIDからアイテム情報を取得
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        internal static ItemData GetItemData(int id)
        {
            if (ItemDict.Keys.Contains(id))
                return ItemDict[id];
            return null;
        }
    }
}