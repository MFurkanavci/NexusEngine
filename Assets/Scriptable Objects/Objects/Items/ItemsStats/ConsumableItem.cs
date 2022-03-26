using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Default Item", menuName = "Item System/Items/ConsumableItem")]
public class ConsumableItem : ItemObject
{
    public void Awake()
    {
        type = itemType.consumables;
        ID = 4001 + uniqueID.nextconsumable++;
    }
}
