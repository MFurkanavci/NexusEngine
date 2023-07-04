using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GCD
{
    public static class GCD{

        public static float globalCooldown = 0;
        
        //this is the delta time for the global cooldown
        public static float deltaTime = 0;

        //this is the update method for the global cooldown

        public static void Update(float speed)
        {
            if (globalCooldown > 0)
            {
                deltaTime += Time.deltaTime;
                //calculate attack per second, attack speed is will be the how many attack per second so the global cooldown will be 1 divided by the attack speed
                globalCooldown = 1 / speed - deltaTime;
            }
        }

        //this is the set method for the global cooldown

        public static void Set(float speed)
        {
            globalCooldown = speed;
            deltaTime = 0;
        }

        //this is the get method for the global cooldown

        public static float Get()
        {
            return globalCooldown;
        }

        //this is the method to check if the global cooldown is ready

        public static bool gcdReady()
        {
            if(globalCooldown <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //this is the method to get the time left for the global cooldown
        public static float TimeLeft()
        {
            return globalCooldown * 1 + deltaTime;
        }
    }
}
