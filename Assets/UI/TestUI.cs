using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TestUI : MonoBehaviour
{
    public GameObject image;
    GameObject panel;

    public Player player;

    public TMP_Text goldText;

    public void Start()
    {
        panel = this.gameObject;
    }

    public void calculateInventory()
    {
        if(panel.transform.childCount > 0)
            clearInventory();
        for (int i = 0; i < player.inventory.Length; i++)
        {
            if (player.inventory[i] != null)
            {
                GameObject newImage = Instantiate(image, panel.transform);
                newImage.GetComponent<TMP_Text>().text = player.inventory[i].Name;
            }
        }
    }

    public void clearInventory()
    {
        foreach (Transform child in panel.transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void Update()
    {
        goldText.text = player.agent.gold.ToString();
    }
}
