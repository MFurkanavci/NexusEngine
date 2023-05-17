using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InstanceCounter;


[CreateAssetMenu(fileName = "New Default Spell", menuName = "Spell System/Spells/Spell")]
public class Spells : SpellArchitecture
{

    private void OnEnable() {
        ID = SetSpellID();
        Name = "Default Spell";
        description = "This is the default spell";
    }
    public int SetSpellID()
    {
        return 2001 + SpellArchCounter.CountSpellArchInstances();
    }
}

