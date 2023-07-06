using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HPandMPManager : MonoBehaviour
{
    public TextMeshProUGUI HPText;
    public TextMeshProUGUI MPText;

    public Scrollbar HPBar;
    public Scrollbar MPBar;

    public Player player;

    public void Update()
    {
        HPText.text = player.agent.hitPointCurrent.ToString();
        MPText.text = player.agent.manaPointCurrent.ToString();

        //my bars are vertical so i need to change the fill amount of the bar
        HPBar.size = 1 / (player.agent.hitPoint / player.agent.hitPointCurrent);
        MPBar.size = 1 / (player.agent.manaPoint / player.agent.manaPointCurrent);
    }
}
