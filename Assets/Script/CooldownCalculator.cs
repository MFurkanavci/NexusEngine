using UnityEngine;
using System.Collections.Generic;

public class AbilityData
{
    public float cooldown;
    public float maxCooldown;
    public bool active;
}

public class CooldownCalculator : MonoBehaviour
{
    public List<SpellArchitecture> activeSpells;
    private Dictionary<int, AbilityData> abilityData;

    private void Awake()
    {
        abilityData = new Dictionary<int, AbilityData>();
        activeSpells = new List<SpellArchitecture>();
    }

    public void StartCooldown(SpellArchitecture spell)
    {
        int spellID = spell.ID;

        if (!abilityData.ContainsKey(spellID))
        {
            Debug.LogError("Ability data not found for spell ID: " + spellID);
            return;
        }

        AbilityData data = abilityData[spellID];

        if (data.active)
            return;

        data.active = true;
        data.cooldown = data.maxCooldown;

        if (!activeSpells.Contains(spell))
            activeSpells.Add(spell);
    }

    private void Update()
    {
        for (int i = activeSpells.Count - 1; i >= 0; i--)
        {
            SpellArchitecture spell = activeSpells[i];
            int spellID = spell.ID;

            if (!abilityData.ContainsKey(spellID))
            {
                Debug.LogError("Ability data not found for spell ID: " + spellID);
                continue;
            }

            AbilityData data = abilityData[spellID];

            if (!data.active)
            {
                activeSpells.RemoveAt(i);
                continue;
            }

            data.cooldown -= Time.deltaTime;

            if (data.cooldown <= 0f)
            {
                data.cooldown = 0f;
                data.active = false;
                activeSpells.RemoveAt(i);
            }
        }
    }

    public bool IsAbilityOnCooldown(SpellArchitecture spell)
    {
        int spellID = spell.ID;

        if (!abilityData.ContainsKey(spellID))
        {
            Debug.LogError("Ability data not found for spell ID: " + spellID);
            return false;
        }

        return abilityData[spellID].active;
    }

    public float GetRemainingCooldownTime(SpellArchitecture spell)
    {
        int spellID = spell.ID;

        if (!abilityData.ContainsKey(spellID))
        {
            Debug.LogError("Ability data not found for spell ID: " + spellID);
            return 0f;
        }

        return abilityData[spellID].cooldown;
    }

    public void InitializeAbilityData(List<SpellArchitecture> spells)
    {
        abilityData.Clear();

        foreach (SpellArchitecture spell in spells)
        {
            int spellID = spell.ID;

            if (!abilityData.ContainsKey(spellID))
            {
                AbilityData data = new AbilityData();
                data.maxCooldown = spell.maxCooldown;
                abilityData.Add(spellID, data);
                activeSpells.Add(spell);
            }
        }
    }
}
