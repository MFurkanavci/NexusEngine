using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpellBarManager : MonoBehaviour
{
    public Player player;
    public PlayableAgent playableAgent;
    public GameObject Spell;
    public List<GameObject> Spells;
    
    public GameObject SpellBar;

    public Dictionary<int, KeyCode> keybinds = new Dictionary<int, KeyCode>();

    private char[] keybindsArray = new char[6] { 'B', 'P', 'Q', 'W', 'E', 'R' };

    public void Start()
    {
        for (int i = 0; i < 6; i++)
        {
            keybinds.Add(i, (KeyCode)Enum.Parse(typeof(KeyCode), keybindsArray[i].ToString()));
        }
        playableAgent = player.agent;
        SetSpells();
    }

    public void SetSpells()
    {
        for (int i = 0; i < playableAgent.activeSpells.Count; i++)
        {
            if (playableAgent.activeSpells[i] != null)
            {
                GameObject spell = Instantiate(Spell, SpellBar.transform);
                spell.GetComponent<Image>().sprite = playableAgent.activeSpells[i].SplashArt;
                Spells.Add(spell);
                spell.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = keybinds[i].ToString();
                spell.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = playableAgent.activeSpells[i].name;
                spell.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = playableAgent.activeSpells[i].maxCooldown.ToString("F2");
            }
            else if (playableAgent.activeSpells[i] == null)
            {
                GameObject spell = Instantiate(Spell, SpellBar.transform);
                spell.GetComponent<Image>().sprite = null;
                Spells.Add(spell);
                spell.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = keybinds[i].ToString();
                spell.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "Empty";
                spell.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "0";
            }
            else
            {
                Debug.LogError("Spell is null");
            }
        }
    }

    public void SpellCasted(int spellIndex)
    {
        StartCoroutine(SpellCooldown(spellIndex));
    }

    IEnumerator SpellCooldown(int spellIndex)
    {
        float maxCD = playableAgent.activeSpells[spellIndex].maxCooldown;
        float time = 0;

        while (time < maxCD)
        {
            Spells[spellIndex].GetComponent<Image>().color = Color.gray;
            Spells[spellIndex].transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = (maxCD - time).ToString("F2");
            time += Time.deltaTime;
            yield return null;
        }
        Spells[spellIndex].transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = maxCD.ToString("F2");
        Spells[spellIndex].GetComponent<Image>().color = Color.white;
    }
}
