using AfflictionComponent.Interfaces;
using Il2Cpp;
using PainComponent.CustomAfflictions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PainComponent.TestAfflictions
{
    internal class TestPainAffliction : CustomPainAffliction
    {
        public TestPainAffliction(string name, string causeText, string description, string? descriptionNoHeal, string spriteName, AfflictionBodyArea location, bool instantHeal, Tuple<string, int, int>[] remedyItems, float duration, float painLevel, float frequency, float fxLevel) : base(name, causeText, description, descriptionNoHeal, spriteName, location, instantHeal, remedyItems, duration, painLevel, frequency, fxLevel)
        {
        }
    }
}
