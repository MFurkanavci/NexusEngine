using System;
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
        if (index < 0 || index > player.inventory.Length)
        {
            return null;
        }
        else
        {
            return player.inventory[index];
        }
    }

    public void setItem(int index, Item item)
    {
        player.inventory[index] = item;
    }

    public void buyedItem(Item item)
    {    
        //check if the player can buy the item wiht the recipe if that so buy the item and remove the items in the recipe from the player inventory
        //if cant buy with recpie check if the player has enough money to buy the item
        //if cant buy with money return
        //if can buy with money buy the item and remove the money from the player
        //if can buy with recipe buy the item and remove the items in the recipe from the player inventory
        //if can buy with money and recipe buy the item and remove the items in the recipe from the player inventory and remove the money from the player

        if (hasAllItemsInRecipe(item))
        {
            if (hasEnoughMoney(item))
            {
                removeMoney(item.cost_Buy);
                removeItemsInRecipe(item);
                addItem(item);
                recalculateInventory();
                addStattoPlayer(item);
            }
            else
            {
                return;
            }
        }
        else
        {
            if (hasEnoughMoney(item))
            {
                removeMoney(item.cost_Buy);
                addItem(item);
                recalculateInventory();
                addStattoPlayer(item);
            }
            else
            {
                return;
            }
        }
    }

    public void removeMoney(int amount)
    {
        player.agent.gold -= amount;
    }

    public bool hasEnoughMoney(Item item)
    {
        if (player.agent.gold >= item.cost_Buy)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void selledItem(Item item)
    {
        if(!inventoryHasItem(item))
        {
        removeStatfromPlayer(item);
        removeItem(item);
        recalculateInventory();
        }

    }

    public bool inventoryHasItem(Item item)
    {
        for (int i = 0; i < player.inventory.Length; i++)
        {
            if (getItem(i) == item)
            {
                return true;
            }
        }
        return false;
    }

    //items can have a recipe to craft them item.recipe is a list of items that are needed to craft the item
    //this function checks if the player has all the items in the recipe
    //but in the recipe there can be items that are not in the player inventory
    //so this function checks if the player has all the items in the recipe that are in the player inventory
    //recipe can have same item more then once, so check the enough of the item in the inventory

    public bool hasRecipe(Item item)
    {
        if (item.recipe != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool hasAllItemsInRecipe(Item item)
    {
        if (item.recipe != null)
        {
            foreach (Item child in item.recipe)
            {
                if (inventoryHasItem(child))
                {
                    if (itemCount(child) < itemCountInRecipe(child, item))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        else
        {
            return false;
        }
    }

    public int itemCountInRecipe(Item item, Item recipeItem)
    {
        int count = 0;
        foreach (Item child in recipeItem.recipe)
        {
            if (child == item)
            {
                count++;
            }
        }
        return count;
    }

    //if player can buy the item with recpie remove the items in the recipe from the inventory
    //do not remove all the recipe items are in the player inventory
    public void removeItemsInRecipe(Item item)
    {
        foreach (Item child in item.recipe)
        {
            if (inventoryHasItem(child))
            {
                    removeStatfromPlayer(child);
                    removeItem(child);
            }
        }
    }

    public bool enoughInventorySpace()
    {
        int count = 0;
        foreach (Item child in player.inventory)
        {
            if (child != null)
            {
                count++;
            }
        }
        if (count < player.inventory.Length)
        {
            return true;
        }
        else
        {
            return false;
        }
    }



    public int itemCount(Item item)
    {
        int count = 0;
        for (int i = 0; i < player.inventory.Length; i++)
        {
            if (getItem(i) == item)
            {
                count++;
            }
        }
        return count;
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
