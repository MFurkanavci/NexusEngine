using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryHandler : MonoBehaviour
{
    //this is the ınventory handler for the player
    //it is used to check if the player buy an item and calculate new item stats and add them to the player stats
    //it is also used to check if the player sell an item and calculate new item stats and remove them from the player stats

    Player player;
    public dictionary[] itemStats = new dictionary[6];

    public void Awake()
    {
        player = GetComponent<Player>();
    }

    public Item getItem(int index)
    {
        return player.inventory[index];
    }

    public void setItem(int index, Item item)
    {
        player.inventory[index] = item;
    }

    public void buyedItem(Item item)
    {
        addItem(item);
        recalculateInventory();
        addStattoPlayer(item);
    }

    public void selledItem(Item item)
    {
        removeStatfromPlayer(item);
        removeItem(item);
        recalculateInventory();
    }

    public void addItem(Item item)
    {
        if(isInventoryAvailable()){
            for (int i = 0; i < player.inventory.Length; i++)
            {
                if (getItem(i) == null)
                {
                    setItem(i,item);
                    break;
                }
            }
        }
    }

    public void removeItem(Item item)
    {
        for (int i = 0; i < player.inventory.Length; i++)
        {
            if (getItem(i) == item)
            {
                setItem(i,null);
                break;
            }
        }
    }

    //check the inventory is reach its limit
    public bool isInventoryAvailable()
    {
        for (int i = 0; i < player.inventory.Length; i++)
        {
            if (getItem(i) == null)
            {
                return true;
            }
        }
        return false;
    }

    public void recalculateInventory()
    {
        for (int i = 0; i < player.inventory.Length; i++)
        {
            if (getItem(i) != null)
            {
                itemStats[i] = new dictionary();
                itemStats[i].setitemBaseStats(getItem(i));
            }
        }
    }
    public Dictionary<string, float> getItemStats(Item item)
    {
        for (int i = 0; i < player.inventory.Length; i++)
        {
            if (getItem(i) == item)
            {
                return itemStats[i].stats;
            }
        }
        return null;
    }

    public void addStattoPlayer(Item item)
    {
        player.agentStats.addStat(getItemStats(item));
        player.agentStats.setFilteredStats(player.agent,getItemStats(item));
    }

    public void removeStatfromPlayer(Item item)
    {
        player.agentStats.removeStat(getItemStats(item));
    }
    public void buy(Item item)
    {
        buyedItem(item);
    }

    public void sell(Item item)
    {
        selledItem(item);
    }

}
