using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GCDtest : MonoBehaviour
{
    //check and trigger the global cooldown and print the result
    public void GCDtest1()
    {
        if (!GlobalCooldown.GlobalCooldown.globalCooldownActive)
        {
            GlobalCooldown.GlobalCooldown.globalCooldownActive = true;
            print("GCDtest1: Global Cooldown Active");
        }
        else
        {
            print("GCDtest1: Global Cooldown Not Active");
        }
    }

    void Update()
    {
        GlobalCooldown.GlobalCooldown.GlobalCooldownUpdate();
        GCDtest1();
    }
}
