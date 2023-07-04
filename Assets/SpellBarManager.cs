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

    //create keybinds array
    private char[] keybindsArray = new char[6] { 'B','P','Q', 'W', 'E', 'R' };

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
            GameObject spell = Instantiate(Spell, SpellBar.transform);
            spell.GetComponent<Image>().sprite = playableAgent.activeSpells[i].SplashArt;
            Spells.Add(spell);

            //we will loop all the child objects of the spell and first one will be the keybind and the second one will be the spell name and the third one will be the spell cooldown
            spell.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = keybinds[i].ToString();
            spell.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = playableAgent.activeSpells[i].name;
            spell.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = playableAgent.activeSpells[i].maxCooldown.ToString("F2");
        }
    }

    public void SpellCasted(int spellIndex)
    {
        Spells[spellIndex].GetComponent<Image>().color = Color.gray;
        Spells[spellIndex].transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = playableAgent.activeSpells[spellIndex].CD.ToString("F2");
        StartCoroutine(SpellCooldown(spellIndex));
    }

    IEnumerator SpellCooldown(int spellIndex)
    {
        float time = playableAgent.activeSpells[spellIndex].maxCooldown;
        while (time > 0)
        {
            Spells[spellIndex].transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = time.ToString("F2");
            time -= Time.deltaTime;
            yield return null;
        }
        Spells[spellIndex].GetComponent<Image>().color = Color.white;
        Spells[spellIndex].transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = playableAgent.activeSpells[spellIndex].maxCooldown.ToString();
    }
}
