using BepInEx;
using HarmonyLib;
using Oc;
using Oc.Skills;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SkillUtility
{
    [BepInPlugin(PluginGuid, PluginName, PluginVersion)]
    public class ExamplePlugin : BaseUnityPlugin
    {
        private const string PluginGuid = "me.rin_jugatla.craftopia.mod.SkillUtility";
        private const string PluginName = "SkillUtility";
        private const string PluginVersion = "0.0.1";

        void Awake()
        {
            new Harmony(PluginGuid).PatchAll();
        }

        /// <summary>
        /// スキルリストをログファイルに出力
        /// </summary>
        [HarmonyPatch(typeof(OcSkillManager), "LoadSaveData")]
        public class OcSkillManagerLogger
        {
            static void Postfix(OcSkillManager __instance)
            {
                SoSkillDataList skillList = Traverse.Create(__instance).Field("skillList").GetValue<SoSkillDataList>();
                OcSkill[] skills = skillList.GetAll();

                // スキル概要
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (OcSkill skill in skills)
                    {
                        if (skill.Category == OcPlSkillCategory.None)
                            continue;
                        sb.AppendLine($"{skill.ID}\t{skill.Category}\t{skill.SkillCategoryName}\t{skill.Tier}\t{skill.SkillName}\t{skill.MaxLevel}\t{skill.OriginDesc}\t{skill.SkillIcon.name}");
                    }
                    using (StreamWriter sw = new StreamWriter("./skilldata.tsv", false, Encoding.UTF8))
                    {
                        string header = "ID\tCategory\tCategoryName\tTier\tSkillName\tMaxLevel\tLevelUpCost\tDescription\tIconName";
                        sw.WriteLine(header);
                        sw.WriteLine(sb.ToString());
                    }
                }

                // スキルパラメータ
                OutputSkillParams("activeParams", OcPlMaster.Inst.SoSkill.activeParams);
                OutputSkillParams("passiveParams", OcPlMaster.Inst.SoSkill.passiveParams);

                // スキル概要+パラメータ
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (var skill in skills)
                    {
                        OcPlActiveSkillType activeSkillType = skill.itemStack.ItemData.ActiveSkillType;
                        OcPlPassiveSkillType passiveSkillType = skill.itemStack.ItemData.PassiveSkillType;
                        SoSkillParam soSkillParam = (activeSkillType > OcPlActiveSkillType.None) ? OcPlMaster.Inst.SoSkill.activeParams[(int)activeSkillType] : OcPlMaster.Inst.SoSkill.passiveParams[(int)passiveSkillType];
                        sb.AppendLine($"{skill.ID}\t{skill.Category}\t{skill.SkillCategoryName}\t{skill.Tier}\t{skill.SkillName}\t{skill.MaxLevel}\t{skill.OriginDesc}\t{skill.SkillIcon.name}");
                        sb.AppendLine($"cooldowns\t{FloatToString(soSkillParam.cooldowns)}\ncostLife\t{FloatToString(soSkillParam.costLife_Values)}\ncostMana\t{FloatToString(soSkillParam.costMana_Values)}\ncostSatiety\t{FloatToString(soSkillParam.costSatiety_Values)}");
                    }
                    using (StreamWriter sw = new StreamWriter("./skilldata_detail.tsv", false, Encoding.UTF8))
                    {
                        string header = "ID\tCategory\tCategoryName\tTier\tSkillName\tMaxLevel\tLevelUpCost\tDescription\tIconName";
                        sw.WriteLine(header);
                        sw.WriteLine(sb.ToString());
                    }
                }
            }

            static void OutputSkillParams(string groupName, SoSkillParam[] paramSet)
            {
                StringBuilder sb = new StringBuilder();
                foreach (var skill in paramSet)
                {
                    sb.AppendLine($"id\t{skill.enumId}\nname\t{skill.name}\ncooldowns\t{FloatToString(skill.cooldowns)}\ncostLife\t{FloatToString(skill.costLife_Values)}\ncostMana\t{FloatToString(skill.costMana_Values)}\ncostSatiety\t{FloatToString(skill.costSatiety_Values)}");
                }
                using (StreamWriter sw = new StreamWriter($"./{groupName}.tsv", false, Encoding.UTF8))
                {
                    sw.WriteLine(sb.ToString());
                }
            }

            static string FloatToString(float[] values)
            {
                return String.Join("\t", values);
            }
        }
    }
}
