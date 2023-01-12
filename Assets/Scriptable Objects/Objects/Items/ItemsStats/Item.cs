using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Default Item", menuName = "Item System/Items/Item")]
public class  Item : ItemObject
{
    public void Awake()
    {
        type = itemType.item;
        ID = 3001 + uniqueID.nextitem++;
    }
}
