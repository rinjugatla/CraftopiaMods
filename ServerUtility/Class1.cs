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

namespace ServerUtility
{
    [BepInPlugin(PluginGuid, PluginName, PluginVersion)]
    public class ServerUtilityPlugin : BaseUnityPlugin
    {
        private const string PluginGuid = "me.rin_jugatla.craftopia.mod.ServerUtility";
        private const string PluginName = "ServerUtility";
        private const string PluginVersion = "0.0.1";

        private static ConfigFile MyConfig = new ConfigFile(Path.Combine(Paths.ConfigPath, $"{PluginGuid}.cfg"), true);
        private static ConfigEntry<string> FolderName;
        private static ConfigEntry<string> ServerSettingFileName;

        void Awake()
        {
            FolderName = MyConfig.Bind<string>("General", "SaveFolderName", "DedicatedServerSave", "Enter a save folder name.");
            ServerSettingFileName = MyConfig.Bind<string>("General", "ServerSettingFileName", "ServerSetting.ini", "Enter a server setting file name.");
            new Harmony(PluginGuid).PatchAll();
        }

        [HarmonyPatch(typeof(OcAllSceneShareSingleton), "SERVER_SETTING_PATH", MethodType.Getter)]
        public class OcAllSceneShareSingleton_Hook
        {
            static void Postfix(ref string __result)
            {
                if (ServerSettingFileName == null || ServerSettingFileName.Value == "")
                    return;

                string name = ServerSettingFileName.Value;
                if (!name.EndsWith(".ini"))
                    name += ".ini";

                string path = UnityEngine.Application.persistentDataPath + "/" + name;

                UnityEngine.Debug.Log($"{PluginName} ServerSettingFileName: {path}");

                __result = path;
            }
        }

        [HarmonyPatch(typeof(OcSaveManager), "OnUnityAwake")]
        public class OcSaveManager_Hook
        {
            /// <summary>
            /// セーブデータの保存先を変更
            /// </summary>
            /// <param name="___FolderPath"></param>
            static void Postfix(OcSaveManager __instance,
                ref string ___FolderPath, ref string ___BackupMinPath, ref string ___BackupHourPath, ref ES3Settings ____saveSetting)
            {
                // 不正な設定値の場合は初期値を使用
                if (FolderName == null || FolderName.Value == "")
                    return;

                ___FolderPath = FixFolderName(FolderName.Value) + "/";

                ___BackupMinPath = ___FolderPath + "SaveBackup_m";
                ___BackupHourPath = ___FolderPath + "SaveBackup_h";
                ____saveSetting = new ES3Settings(___FolderPath + "SaveData.ocs", settings: null);

                UnityEngine.Debug.Log($"{PluginName} SaveFolderPath: {____saveSetting.FullPath}");

                if (ES3.FileExists(____saveSetting))
                    Traverse.Create(__instance).Method("TryCreateCache").GetValue();
            }

            /// <summary>
            /// 不正なフォルダ名を補正
            /// </summary>
            /// <param name="name"></param>
            /// <returns></returns>
            private static string FixFolderName(string name)
            {
                string result = name;
                // フルパスの場合は最後のフォルダ名だけを取得
                if (result.IndexOf("://") > -1)
                    result = Path.GetFileName(Path.GetDirectoryName(result));

                // 不正な文字を削除
                string[] invalidChars = new string[] { ":", "*", "?", "\"", "<", ">", "|" };
                foreach (var s in invalidChars)
                {
                    result = result.Replace(s, "");
                }

                if (name != result)
                    UnityEngine.Debug.Log($"{PluginName} FixFolderName: {name} -> {result}");

                return result;
            }
        }
    }
}
