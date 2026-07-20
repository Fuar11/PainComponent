using AfflictionComponent.Components;
using Il2Cpp;
using Il2CppTLD.Gameplay;
using PainComponent.Component;
using PainComponent.CustomAfflictions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace PainComponent.Utils
{
    internal class UtilityFunctions
    {

        public static PainManager pm = Mod.painManager;
        public static float MapPercentageToVariable(double percentage, float minVariableValue = 1.0f, float maxVariableValue = 2.0f)
        {

            double minPercentage = 0;
            double maxPercentage = 100;
           
            float variable = (float)((percentage - minPercentage) / (maxPercentage - minPercentage) * (maxVariableValue - minVariableValue) + minVariableValue);

            variable = Math.Max(minVariableValue, Math.Min(maxVariableValue, variable));

            return variable;
        }

        public static bool IsInterloperOrFastDecayRate()
        {
            if (ExperienceModeManager.GetCurrentExperienceModeType() == ExperienceModeType.Interloper || GameManager.InCustomMode() && GameManager.GetCustomMode().m_ItemDecayRate == Il2CppTLD.Gameplay.Tunable.CustomTunableLMHV.VeryHigh) return true;
            else return false;
        }

        public static void ScaleCraftingProgressHours(ref float hoursSpentCrafting)
        {
            if (hoursSpentCrafting <= 0f) return;

            if (InterfaceManager.GetPanel<Panel_Cooking>().isActiveAndEnabled)
            {
                Mod.Logger.Log("Cooking panel is enabled, do not apply debuff.", ComplexLogger.FlaggedLoggingLevel.Debug);
                return;
            }


            float multiplier = GetCraftingDurationMultiplier();
            if (multiplier <= 0f || Mathf.Approximately(multiplier, 1f)) return;

            hoursSpentCrafting /= multiplier;
        }

        public static float GetCraftingDurationMultiplier()
        {
            return GetCraftingTimeMultiplier();
        }

        private static float GetCraftingTimeMultiplier()
        {
            PainManager pm = Mod.painManager;

            AfflictionBodyArea[] arms = { AfflictionBodyArea.ArmLeft, AfflictionBodyArea.ArmRight };

            float armsPainLevel = pm.GetTotalPainLevelForPainAtLocations(arms);
            float armsStartingPainLevel = pm.GetTotalPainLevelForPainAtLocations(arms, true);
            float armsPainDifference = (armsPainLevel / armsStartingPainLevel) * 100;

            AfflictionBodyArea[] hands = { AfflictionBodyArea.HandLeft, AfflictionBodyArea.HandRight };

            float handsPainLevel = pm.GetTotalPainLevelForPainAtLocations(hands);
            float handsStartingPainLevel = pm.GetTotalPainLevelForPainAtLocations(hands, true);
            float handsPainDifference = (handsPainLevel / handsStartingPainLevel) * 100;

            if (handsPainDifference > 0 || armsPainDifference > 0)
            {

                float handsPainMulti = pm.PainkillersInEffect(handsPainLevel) ? UtilityFunctions.MapPercentageToVariable(handsPainDifference / 2) : UtilityFunctions.MapPercentageToVariable(handsPainDifference);
                float armsPainMulti = pm.PainkillersInEffect(armsPainLevel) ? UtilityFunctions.MapPercentageToVariable(armsPainDifference / 2) : UtilityFunctions.MapPercentageToVariable(armsPainDifference);

                return handsPainMulti + armsPainMulti;
            }
            else return 1;
        }
    }
}
