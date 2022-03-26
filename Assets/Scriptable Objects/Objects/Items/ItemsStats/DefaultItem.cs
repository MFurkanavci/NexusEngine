using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Default Item", menuName = "Item System/Items/DefaultItem")]
public class DefaultItem : ItemObject
{
    public void Awake()
    {
        type = itemType.Default;
    }
}
