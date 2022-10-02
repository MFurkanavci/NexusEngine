using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GlobalCooldown
{
    public static class GlobalCooldown
    {
        public static float globalCooldown = 0.5f;
        public static float globalCooldownTimer = 0;
        public static bool globalCooldownActive = false;

        public static void GlobalCooldownTimer()
        {
            if (globalCooldownActive)
            {
                globalCooldownTimer += Time.deltaTime;
                if (globalCooldownTimer >= globalCooldown)
                {
                    globalCooldownTimer = 0;
                    globalCooldownActive = false;
                }
            }
        }
    }
}
