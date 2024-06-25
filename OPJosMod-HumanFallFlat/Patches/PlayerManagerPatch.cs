using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;

namespace OPJosMod_HumanFallFlat.Patches
{
    [HarmonyPatch(typeof(PlayerManager))]
    internal class PlayerManagerPatch
    {
        private static ManualLogSource mls;
        public static void SetLogSource(ManualLogSource logSource)
        {
            mls = logSource;
        }

        [HarmonyPatch("Update")]
        [HarmonyPostfix]
        static void UpdatePatch(PlayerActions __instance)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                mls.LogMessage("p pressed!");
            }
        }
    }
}
