using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GlobalCooldown
{
    public static class GlobalCooldown
    {
        public static float globalCooldown = .5f;
        public static float globalCooldownTimer = 0;
        public static bool globalCooldownActive = true;

        public static void GlobalCooldownUpdate()
        {
            if (globalCooldownActive)
            {
                globalCooldownTimer += Time.deltaTime;
                if (globalCooldownTimer >= globalCooldown)
                {
                    GlobalCooldownReset();
                }
            }
        }

        public static void GlobalCooldownReset()
        {
            globalCooldownTimer = 0;
            globalCooldownActive = false;
        }

        public static void GlobalCooldownSet(float newGlobalCooldown)
        {
            globalCooldown = newGlobalCooldown;
        }

        public static void GlobalCooldownSet(float newGlobalCooldown, float newGlobalCooldownTimer)
        {
            globalCooldown = newGlobalCooldown;
            globalCooldownTimer = newGlobalCooldownTimer;
        }
    }
}
