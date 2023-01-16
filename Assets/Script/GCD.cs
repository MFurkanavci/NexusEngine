using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GCD
{
    public static class GCD{

        //this is the global cooldown for all the abilities(attack, ability, etc)
        public static float globalCooldown = 0;
        
        //this is the delta time for the global cooldown
        public static float deltaTime = 0;

        //this is the update method for the global cooldown
        public static bool Update(float speed)
        {
            //if the global cooldown is not finished
            if (globalCooldown > 0)
            {
                //add the delta time
                deltaTime += Time.deltaTime;

                //if the delta time is bigger than the global cooldown
                if (deltaTime > globalCooldown)
                {
                    //reset the global cooldown and the delta time
                    globalCooldown = 0;
                    deltaTime = 0;
                }
                return false;
            }
            //if the global cooldown is finished
            else
            {
                //set the global cooldown
                globalCooldown = 1 / speed;
                return true;
            }
        }

        //this is the reset method for the global cooldown
        public static void Reset()
        {
            globalCooldown = 0;
            deltaTime = 0;
        }

        //this is the get method for the global cooldown
        public static float Get()
        {
            return globalCooldown;
        }

        //this is the get method for the delta time
        public static float GetDeltaTime()
        {
            return deltaTime;
        }

        //this is the set method for the global cooldown
        public static void Set(float value)
        {
            globalCooldown = value;
        }

        //this is the set method for the delta time
        public static void SetDeltaTime(float value)
        {
            deltaTime = value;
        }

        //this is the add method for the global cooldown
        public static void Add(float value)
        {
            globalCooldown += value;
        }

        //this is the add method for the delta time
        public static void AddDeltaTime(float value)
        {
            deltaTime += value;
        }

        //this is the subtract method for the global cooldown
        public static void Subtract(float value)
        {
            globalCooldown -= value;
        }

        //this is the subtract method for the delta time
        public static void SubtractDeltaTime(float value)
        {
            deltaTime -= value;
        }

        //calculate the time left for the global cooldown
        public static float TimeLeft()
        {
            return globalCooldown - deltaTime;
        }
    }
}
