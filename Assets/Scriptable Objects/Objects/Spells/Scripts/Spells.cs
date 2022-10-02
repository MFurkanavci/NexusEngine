using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Default Spell", menuName = "Spell System/Spells/Spell")]
public class Spells : SpellArchitecture
{
    public Spells (SpellArchitecture spellArchitecture )
    {
        this.ID = spellArchitecture.ID;
        this.Name = spellArchitecture.Name;
        this.SplashArt = spellArchitecture.SplashArt;
        this.description = spellArchitecture.description;
        
    }
    public void Awake()
    {
        ID = 2000;
    }

}

