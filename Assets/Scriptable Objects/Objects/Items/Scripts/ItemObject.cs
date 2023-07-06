using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum itemType
{
    item,
    consumables,
    Default
}
public class ItemObject : ScriptableObject
{

    public int ID;
    public string Name;
    public Sprite SplashArt;
    public itemType type;
    
    [TextArea(15, 20)]
    public string description;

    public float
        damage_Physical = 0,
        damage_Magical = 0,
        hitPoint = 0,
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
        time = 0;
        

    public int
        cost_Buy = 0,
        cost_Sell = 0,
        stack_Count = 0,
        merge_Count = 0;

    
    public bool
      isCritible = false,
      isImmuneCriticalHit = false,
      isInvisible = false,
      isPushable = false,
      canJump = false,
      canFly = false,
      canMoveThroughOthers = false,
      isStackable = false,
      isMergable = false,
      isEquipable = false,
      isEquipped = false;


    public List<SpellArchitecture>
        activeSpells,
        passiveSpells;

    public Item[]
        recipe;
}
