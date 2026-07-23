using AfflictionComponent.Components;
using AfflictionComponent.Interfaces;
using AfflictionComponent.Enums;
using Il2Cpp;
using PainComponent.Component;
using PainComponent.Pain;
using PainComponent.Utils;
using UnityEngine;
using AfflictionComponent.Utilities;

namespace PainComponent.CustomAfflictions
{

    public class CustomPainAffliction
        : CustomAffliction, IDuration, IRemedies, IInstance, ICustomRightSidePanelObject
    {

        public CustomPainAffliction(string name, string causeText, string description, string? descriptionNoHeal, string spriteName, AfflictionBodyArea location, bool instantHeal, Tuple<string, int, int>[] remedyItems, float duration, float painLevel, float frequency, float fxLevel) : base(name, causeText, description, descriptionNoHeal, spriteName, location)
        {

            Duration = duration;

            //SetInstanceTypeBasedOnName();

            RemedyItems = remedyItems;
            AltRemedyItems = [];
            InstantHeal = instantHeal;

            m_PainLevel = painLevel;
            m_StartingPainLevel = painLevel;

            m_PulseFxFrequencySeconds = frequency;
            m_PulseFxIntensity = fxLevel;

            Mod.painManager.m_PainStartingLevel += painLevel;
            PainEffects.UpdatePainEffects();

            PanelLabel = "Painkillers";
            PanelBackground = true;
            PanelIcon = "ico_units_pill";
            PanelText = "";
            PanelTextColour = new SerializableColor(Color.white);

        }

        public float Duration { get; set; }
        public float EndTime { get; set; }
        public float m_PainLevel { get; set; }
        public float m_StartingPainLevel { get; set; }
        public float m_PulseFxIntensity { get; set; }
        public float m_PulseFxFrequencySeconds { get; set; }
        public bool InstantHeal { get; set; }
        public Tuple<string, int, int>[] RemedyItems { get; set; }
        public Tuple<string, int, int>[] AltRemedyItems { get; set; }
        public InstanceType Type { get; set; }
        public string PanelLabel { get; set; }
        public bool PanelBackground { get; set; }
        public string PanelIcon { get; set; }
        public string PanelText { get; set; }
        public SerializableColor PanelTextColour { get; set; }

        public override void OnUpdate() //if you inherit this class you will NEED to call base.OnUpdate in order for this logic to run
        {
            float tODHours = GameManager.GetTimeOfDayComponent().GetTODHours(Time.deltaTime);
            m_PainLevel -= GetPainLevelDecreasePerHour() * tODHours;

            int percentage = Mathf.RoundToInt(Mathf.Clamp01(Mod.painManager.m_PainkillerLevel / m_PainLevel) * 100);

            PanelText = percentage.ToString() + "%";

            float progress = Mathf.Clamp01(Mod.painManager.m_PainkillerLevel / m_PainLevel);
            PanelTextColour = new SerializableColor(Color.Lerp(Color.red, Color.green, progress));

        }
        public void CureSymptoms()
        {
        }
        public void OnCure()
        {
            Mod.painManager.m_PainStartingLevel = Mod.painManager.GetTotalPainStartingLevel();
            PainEffects.UpdatePainEffects();
        }

        public float GetPainLevelDecreasePerHour()
        {
            return m_StartingPainLevel / EndTime;
        }

        protected override bool ApplyRemedyCondition()
        {
            if (Mod.painManager.m_PainkillerLevel > m_PainLevel) return true;
            else return false;
            
        }
       
       
        public void SetInstanceTypeBasedOnName()
        {
            if(m_Name is null)
            {
              //Mod.Logger.Log("Name is null", ComplexLogger.FlaggedLoggingLevel.Error);

                if (Type != InstanceType.Open) Mod.Logger.Log("Instance type is not default", ComplexLogger.FlaggedLoggingLevel.Debug);
                return;
            }

            //support for Improved Afflictions
            if (m_Name.ToLowerInvariant().Contains("concussion")) Type = InstanceType.Single;
            else if (m_Name.ToLowerInvariant().Contains("bite")) Type = InstanceType.Open;
            else if (m_Name.ToLowerInvariant().Contains("chemical")) Type = InstanceType.SingleLocation;
            else if (m_Name.ToLowerInvariant().Contains("sprain")) Type = InstanceType.SingleLocation;
        }

        public void OnFoundExistingInstance(CustomAffliction aff)
        {
            if(aff is CustomPainAffliction paff)
            {
                AfflictionHelper.ResetPainAffliction(paff);
            }
        }
    }
}
