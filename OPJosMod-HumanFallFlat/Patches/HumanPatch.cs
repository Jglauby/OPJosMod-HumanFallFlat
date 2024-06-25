using BepInEx.Logging;
using HarmonyLib;
using InControl;
using UnityEngine;

namespace OPJosMod_HumanFallFlat.Patches
{
    [HarmonyPatch(typeof(Human))]
    internal class HumanPatch
    {
        private static ManualLogSource mls;
        public static void SetLogSource(ManualLogSource logSource)
        {
            mls = logSource;
        }

        private static float maxUpVelocity = 2f;

        [HarmonyPatch("FixedUpdate")]
        [HarmonyPostfix]
        static void FixedUpdatePatch(Human __instance)
        {
            if (!__instance.IsLocalPlayer)
                return;

            Vector3 grabStartPosition = Vector3.zero;
            if (__instance.hasGrabbed && ((Component)__instance).transform.position.y < grabStartPosition.y)
            {
                grabStartPosition = ((Component)__instance).transform.position;
            }

            if (Input.GetKey(KeyCode.Space) && __instance.hasGrabbed && ((Component)__instance).transform.position.y - grabStartPosition.y > 0.1f)
            {
                Rigidbody[] array = __instance.rigidbodies;
                Vector3 vector = __instance.velocity;

                if (vector.y < maxUpVelocity)
                    vector.y += 0.5f;

                foreach (Rigidbody val in array)
                {
                    val.velocity = vector;
                }

                mls.LogInfo($"result vector: {vector}");
            }
        }
    }
}
