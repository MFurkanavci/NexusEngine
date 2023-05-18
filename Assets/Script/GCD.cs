using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GCD
{
    public class GCD{

        //this is the global cooldown for all the abilities(attack, ability, etc)
        public float globalCooldown = 0;
        
        //this is the delta time for the global cooldown
        public float deltaTime = 0;

        //this is the update method for the global cooldown

        public void Update(float speed)
        {
            if (globalCooldown > 0)
            {
                deltaTime += Time.deltaTime;
                //calculate attack per second, attack speed is will be the how many attack per second so the global cooldown will be 1 divided by the attack speed
                globalCooldown = 1 / speed - deltaTime;
            }
        }

        //this is the set method for the global cooldown

        public void Set(float speed)
        {
            globalCooldown = speed;
            deltaTime = 0;
        }

        //this is the get method for the global cooldown

        public float Get()
        {
            return globalCooldown;
        }

        //this is the method to check if the global cooldown is ready

        public bool gcdReady()
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
        public float TimeLeft()
        {
            return globalCooldown;
        }
    }
}
