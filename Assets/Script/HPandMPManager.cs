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
        HPText.text = player.agent.hitPointCurrent.ToString("F0") + "/" + player.agent.maxHitPoint.ToString();

        if (player.agent.maxManaPoint != 0)
        {
            MPText.text = player.agent.manaPointCurrent.ToString("F0") + "/" + player.agent.maxManaPoint.ToString();
        }
        else if (player.agent.maxEnergyPoint != 0)
        {
            MPText.text = player.agent.energyPointCurrent.ToString("F0") + "/" + player.agent.maxEnergyPoint.ToString();
        }
        else if (player.agent.maxWildPoint != 0)
        {
            MPText.text = player.agent.wildPointCurrent.ToString("F0") + "/" + player.agent.maxWildPoint.ToString();
        }

        HPBar.size = player.agent.hitPointCurrent / player.agent.maxHitPoint;

        if (player.agent.maxManaPoint != 0)
        {
            MPBar.size = player.agent.manaPointCurrent / player.agent.maxManaPoint;
            MPBar.handleRect.GetComponent<Image>().color = Color.blue;
        }
        else if (player.agent.maxEnergyPoint != 0)
        {
            MPBar.size = player.agent.energyPointCurrent / player.agent.maxEnergyPoint;
            MPBar.handleRect.GetComponent<Image>().color = Color.yellow;
        }
        else if (player.agent.maxWildPoint != 0)
        {
            MPBar.size = player.agent.wildPointCurrent / player.agent.maxWildPoint;
            MPBar.handleRect.GetComponent<Image>().color = Color.red;
        }
    }
}
