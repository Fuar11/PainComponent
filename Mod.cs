using MelonLoader;
using ModData;
using PainComponent.Utils;
using PainComponent.Pain;
using Il2Cpp;
using UnityEngine;
using PainComponent.Component;
using AfflictionComponent.Components;
using PainComponent.CustomAfflictions;
using Random = UnityEngine.Random;
using ComplexLogger;
using PainComponent.TestAfflictions;

namespace PainComponent;
internal sealed class Mod : MelonMod
{
    internal static Mod Instance { get; private set; }
    internal static ComplexLogger<Mod> Logger = new();
    internal static PainManager painManager;
    internal static SaveDataManager sdm = new SaveDataManager();

    public override void OnInitializeMelon()
	{
        Instance = this;
		MelonLogger.Msg("Pain Component is online.");
    }

    public override void OnSceneWasInitialized(int buildIndex, string sceneName)
    {
        if (sceneName.ToLowerInvariant().Contains("boot") || sceneName.ToLowerInvariant().Contains("empty")) return;
        if (sceneName.ToLowerInvariant().Contains("menu"))
        {
            UnityEngine.Object.Destroy(GameObject.Find("PainManager"));
            painManager = null;
            return;
        }

        if (!sceneName.Contains("_SANDBOX") && !sceneName.Contains("_DLC") && !sceneName.Contains("_WILDLIFE"))
        {
            if (painManager == null)
            {
                GameObject PainManager = new() { name = "PainManager", layer = vp_Layer.Default };
                UnityEngine.Object.Instantiate(PainManager, GameManager.GetVpFPSPlayer().transform);
                UnityEngine.Object.DontDestroyOnLoad(PainManager);
                painManager = PainManager.AddComponent<PainManager>();
            }
        }
    }

    public override void OnUpdate()
    {
        /**
        if (InputManager.GetKeyDown(InputManager.m_CurrentContext, KeyCode.U))
        {
            TestPainAffliction testAff = new TestPainAffliction("Test Pain Affliction", "Fuar", "", "Test is a test affliction with no remedies", "ico_units_pill", AfflictionBodyArea.Chest, false, null, 12, 45, 2, 2);
            testAff.Start();
        } **/

    }

}
