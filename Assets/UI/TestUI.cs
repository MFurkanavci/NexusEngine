using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestUI : MonoBehaviour
{
    public GameObject image;
    GameObject panel;

    public Player player;
    public void addInventoryImage()
    {
        ClearInventory();
        for (int i = 0; i < player.inventory.Length; i++)
        {
            if (player.inventory[i] != null)
            {
                panel = Instantiate(image, transform);
                panel.GetComponent<Image>().sprite = player.inventory[i].SplashArt;
            }
        }
    }

    void ClearInventory()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}
