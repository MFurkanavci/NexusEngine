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

    public List<Item> buyedItems = new List<Item>();

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
        if(enoughInventorySpace())
        {

        if (hasAllItemsInRecipe(item) && hasRecipe(item))
        {
            if (hasEnoughMoney(calculatePrice(buyedItems, item)))
            {
                removeMoney(calculatePrice(buyedItems, item));
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
        else if(haveSomeItemsInRecipe(item) && hasRecipe(item))
        {
            if (hasEnoughMoney(calculatePrice(buyedItems, item)))
            {
                removeMoney(calculatePrice(buyedItems, item));
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
            if (hasEnoughMoney(calculatePrice(buyedItems, item)))
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
        else
        {
            print("not enough inventory space");
            return;
        }
        clearBuyedItems();
    }

    public void removeMoney(int amount)
    {
        print(amount+" is removed from the player");
        player.agent.gold -= amount;
    }
    public int calculatePrice(List<Item> items, Item item)
    {
        int total = 0;
        foreach (Item child in items)
        {
            total += child.cost_Buy;
        }
        return item.cost_Buy - total;
    }

    public bool hasEnoughMoney(int amount)
    {
        if (player.agent.gold >= amount)
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
        foreach (Item child in player.inventory)
        {
            if (child == item)
            {
                return true;
            }
            else
            {
                continue;
            }
        }
        return false;
    }

    public bool hasRecipe(Item item)
    {
        if (item.recipe.Length > 0 && item.recipe != null)
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
        //create a list of items that are in the player inventory
        //check if the player has all the items in the recipe that are in the player inventory
        //recipe can have same item more then once, so check the enough of the item in the inventory with removing the items from the list

        
        int count = 0;
        if (hasRecipe(item))
        {
            List<Item> inventoryItems = new List<Item>();
            foreach (Item child in player.inventory)
            {
                if (child != null)
                {
                    inventoryItems.Add(child);
                }
            }
            foreach (Item child in item.recipe)
            {
                if (inventoryItems.Contains(child))
                {
                    buyedItems.Add(child);
                    inventoryItems.Remove(child);
                    count++;
                }
            }
        }
        
            if (count == item.recipe.Length)
            {
                print("has all items in recipe");
                return true;
            }
            else
            {
                return false;
            }
    }

    public bool haveSomeItemsInRecipe(Item item)
    {
        //create a list of items that are in the player inventory
        //check if the player has some of the items in the recipe that are in the player inventory
        //recipe can have same item more then once, so check the enough of the item in the inventory with removing the items from the list
        
        int count = 0;
        if (hasRecipe(item))
        {
            List<Item> inventoryItems = new List<Item>();
            foreach (Item child in player.inventory)
            {
                if (child != null)
                {
                    inventoryItems.Add(child);
                }
            }
            foreach (Item child in item.recipe)
            {
                if (inventoryItems.Contains(child))
                {
                    buyedItems.Add(child);
                    inventoryItems.Remove(child);
                    count++;
                }
            }
        }
        if (count > 0)
        {
            print("has some items in recipe");
            return true;
        }
        else
        {
            return false;
        }

        
    }

    public void clearBuyedItems()
    {
        buyedItems.Clear();
    }

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
