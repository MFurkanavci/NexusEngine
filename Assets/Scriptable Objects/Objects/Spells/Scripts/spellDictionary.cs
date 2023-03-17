using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spellDictionary {
    
        public Dictionary<int, SpellArchitecture> spellDictionarys = new Dictionary<int, SpellArchitecture>();
    
        public void setSpellDictionary(SpellArchitecture[] spells)
        {
            foreach (var item in spells)
            {
                spellDictionarys.Add(item.ID, item);
            }
        }
    
        public SpellArchitecture getSpell(int ID)
        {
            return spellDictionarys[ID];
        }

        public void addSpell(SpellArchitecture spell)
        {
            spellDictionarys.Add(spell.ID, spell);
        }

        public void removeSpell(int ID)
        {
            spellDictionarys.Remove(ID);
        }

        public void removeSpell(SpellArchitecture spell)
        {
            spellDictionarys.Remove(spell.ID);
        }

        void Start()
        {
            SpellArchitecture[] spells = Resources.LoadAll<SpellArchitecture>("Scriptable Objects/Objects/Spells/Spells");
            setSpellDictionary(spells);
        }

}
