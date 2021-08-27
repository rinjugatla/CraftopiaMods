using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using Oc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FixEars
{
    [BepInPlugin(PluginGuid, PluginName, PluginVersion)]
    public class ExamplePlugin : BaseUnityPlugin
    {
        private const string PluginGuid = "me.rin_jugatla.craftopia.mod.FixEars";
        private const string PluginName = "FixEars";
        private const string PluginVersion = "0.0.1";

        private static ConfigFile MyConfig = new ConfigFile(Path.Combine(Paths.ConfigPath, $"{PluginGuid}.cfg"), true);
        private static ConfigEntry<bool> IsForwardByPlayer;

        void Awake()
        {
            IsForwardByPlayer = MyConfig.Bind<bool>("General", "IsForwardByPlayer", false, "Either align the ears with the direction the character is facing, rather than the direction of the camera.");
            new Harmony(PluginGuid).PatchAll();
        }

        [HarmonyPatch(typeof(OcAudioListenerCtrl))]
        internal class OcAudioListenerCtrl_Hook
        {
            [HarmonyPatch("Update"), HarmonyPostfix]
            static void OcAudioListenerCtrl_Update(Camera ___mainCamera, ref AudioListener ___audioListener)
            {
                if(IsForwardByPlayer.Value)
                    ___audioListener.transform.forward = OcPlMaster.Inst.transform.forward;
                ___audioListener.transform.position = OcPlMaster.Inst.transform.position;
            }
        }
    }
}
