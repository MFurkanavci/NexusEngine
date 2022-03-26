using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : ScriptableObject
{
    public float
        level = 0,
        modifier = 0,
        experience = 0,
        damage_Physical = 0,
        damage_Magical = 0,
        hitPoint = 0,
        hitPointCurrent = 0,
        regen_hitPoint = 0,
        manaPoint = 0,
        regen_manaPoint = 0,
        wildPoint = 0,
        regen_wildPoint = 0,
        energyPoint = 0,
        regen_energyPoint = 0,
        armor_Physical = 0,
        armor_Magical = 0,
        speed_Movement = 0,
        speed_Attack = 0,
        drop_Gold = 0,
        drop_Experience = 0,
        penetration_Physical = 0,
        penetration_Magical = 0,
        criticalchance_Physical = 0,
        criticaldamage_Physical = 0,
        criticalcahnce_Magical = 0,
        criticaldamage_Magical = 0,
        rate_Block = 0,
        rate_Parry = 0,
        rate_Dodge = 0,
        accuracy = 0,
        tenacity = 0,
        penetration_Tenacity = 0,
        speed_Jump = 0,
        speed_Fly = 0,
        leech = 0,
        gold = 0,
        vaskaPoint = 0;


    public bool
        isCritible = true,
        isImmuneCriticalHit = false,
        isInvisible = false,
        isPushable = false,
        canJumpable = false,
        canFlyable = false,
        canMoveThroughOthers = false;

}
