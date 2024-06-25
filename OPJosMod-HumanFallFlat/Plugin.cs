using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using OPJosMod_HumanFallFlat.SpiderMan.Patches;

namespace OPJosModHumanFallFlat.SpiderMan
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class OpJosModBase : BaseUnityPlugin
    {
        private const string modGUID = "OpJosModHumanFallFlat.SpiderMan";
        private const string modName = "SpiderMan";
        private const string modVersion = "1.0.0";

        private readonly Harmony harmony = new Harmony(modGUID);
        private static OpJosModBase Instance;
        internal ManualLogSource mls;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);
            mls.LogInfo($"{modName} has started!");

            HumanPatch.SetLogSource(mls);
            harmony.PatchAll();
        }
    }
}
