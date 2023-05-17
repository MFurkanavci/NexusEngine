using UnityEngine;
using UnityEditor;


namespace InstanceCounter
{
[ExecuteInEditMode]
public class SpellArchCounter
{
    public static int count = 0;

    public static int CountSpellArchInstances()
    {
        int count_temp = 0;

        string[] guids = AssetDatabase.FindAssets("t:SpellArchitecture");
        foreach (string guid in guids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            SpellArchitecture spellArch = AssetDatabase.LoadAssetAtPath<SpellArchitecture>(path);
            if (spellArch != null)
            {
                count_temp++;
            }
        }
        count = count_temp;
        return count;
    }
}
}
