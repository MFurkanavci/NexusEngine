using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "New Default Item", menuName = "Item System/Items/Item")]
public class  Item : ItemObject
{
    private static int nextItemID = 4000;

    private void OnEnable()
    {

        type = itemType.Default;
        ID = GenerateItemID();
    }

    private static int GenerateItemID()
    {
        //check if the ID is already in use in the asset database
        if (AssetDatabase.FindAssets("t:ItemObject").Length > 0)
        {
            //get all the assets
            string[] guids = AssetDatabase.FindAssets("t:ItemObject");
            //loop through all the assets
            for (int i = 0; i < guids.Length; i++)
            {
                //get the asset path
                string path = AssetDatabase.GUIDToAssetPath(guids[i]);
                //get the asset
                ItemObject item = AssetDatabase.LoadAssetAtPath<ItemObject>(path);
                //check if the ID is the same
                if (item.ID == nextItemID)
                {
                    //increase the ID
                    nextItemID++;
                }
            }
        }
        //return the ID
        return nextItemID;
    }
}
