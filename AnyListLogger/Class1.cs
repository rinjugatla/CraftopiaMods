using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BepInEx;
using HarmonyLib;
using Oc.Item;

namespace AnyListLogger
{
    [BepInPlugin(PluginGuid, PluginName, PluginVersion)]
    public class ExamplePlugin : BaseUnityPlugin
    {
        public const string PluginGuid = "2AA56D88-A06D-4790-89E7-5192585E1A41";
        public const string PluginName = "AnyListLogger";
        public const string PluginVersion = "0.0.1";

        void Awake()
        {
            UnityEngine.Debug.Log($"{PluginName} : {PluginVersion}");
            Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly());
        }

        [HarmonyPatch(typeof(OcItemDataMng), "SetupCraftableItems")]
        public class CraftableItemLogger
        {
        }
    }
}
