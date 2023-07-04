using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "New Default Spell", menuName = "Spell System/Spells/Spell")]
public class Spells : SpellArchitecture
{
    private static int nextSpellID = 2000;

    private void OnEnable()
    {
        if (ID == 0)
        {
            ID = GenerateSpellID();
        }
    }

    private static int GenerateSpellID()
    {
        //check if the ID is already in use in the asset database
        if (AssetDatabase.FindAssets("t:SpellArchitecture").Length > 0)
        {
            //get all the assets
            string[] guids = AssetDatabase.FindAssets("t:SpellArchitecture");
            //loop through all the assets
            for (int i = 0; i < guids.Length; i++)
            {
                //get the asset path
                string path = AssetDatabase.GUIDToAssetPath(guids[i]);
                //get the asset
                SpellArchitecture spell = AssetDatabase.LoadAssetAtPath<SpellArchitecture>(path);
                //check if the ID is the same
                if (spell.ID == nextSpellID)
                {
                    //increase the ID
                    nextSpellID++;
                }
            }
        }
        //return the ID
        return nextSpellID;
    }
}
