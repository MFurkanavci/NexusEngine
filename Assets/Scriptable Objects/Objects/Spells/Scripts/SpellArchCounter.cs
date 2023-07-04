using UnityEngine;
using UnityEditor;


namespace InstanceCounter
{
[ExecuteInEditMode]
public class SpellArchCounter
{
    public static int count;

    public static int CountSpellArchInstances()
{
    count = 0;
    var spellArchetypes = Resources.LoadAll<SpellArchitecture>("");

    foreach (var spellArchetype in spellArchetypes)
    {
        if (spellArchetype.hideFlags == HideFlags.NotEditable || spellArchetype.hideFlags == HideFlags.HideAndDontSave)
            continue;

        count++;
    }

    return count;
}



}
}
