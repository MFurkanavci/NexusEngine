using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Item))]
public class ItemInspector : Editor
{
    public override void OnInspectorGUI()
    {
        var item = target as ItemObject;

        EditorGUILayout.Space(10);
        EditorGUILayout.LabelField("General Information", EditorStyles.boldLabel);
        EditorGUILayout.LabelField("ID                                     " + item.ID.ToString());
        item.Name = EditorGUILayout.TextField("Name", item.Name);
        item.SplashArt = (Sprite)EditorGUILayout.ObjectField("Splash Art", item.SplashArt, typeof(Sprite), allowSceneObjects: true);
        item.type = (itemType)EditorGUILayout.EnumPopup("Type", item.type);
        item.description = EditorGUILayout.TextArea(item.description, GUILayout.Height(100));

        EditorGUILayout.Space(10);
        EditorGUILayout.LabelField("Attributes", EditorStyles.boldLabel);
        item.damage_Physical = EditorGUILayout.FloatField("Physical Damage", item.damage_Physical);
        item.damage_Magical = EditorGUILayout.FloatField("Magical Damage", item.damage_Magical);
        item.hitPoint = EditorGUILayout.FloatField("Hit Points", item.hitPoint);
        item.regen_hitPoint = EditorGUILayout.FloatField("HP Regeneration", item.regen_hitPoint);
        item.manaPoint = EditorGUILayout.FloatField("Mana Points", item.manaPoint);
        item.regen_manaPoint = EditorGUILayout.FloatField("MP Regeneration", item.regen_manaPoint);
        item.armor_Physical = EditorGUILayout.FloatField("Physical Armor", item.armor_Physical);
        item.armor_Magical = EditorGUILayout.FloatField("Magical Armor", item.armor_Magical);
        item.speed_Attack = EditorGUILayout.FloatField("Attack Speed", item.speed_Attack);
        item.speed_Movement = EditorGUILayout.FloatField("Movement Speed", item.speed_Movement);
        item.criticalchance_Physical = EditorGUILayout.FloatField("Physical Critical Chance", item.criticalchance_Physical);
        item.criticalcahnce_Magical = EditorGUILayout.FloatField("Magical Critical Chance", item.criticalcahnce_Magical);
        item.criticaldamage_Physical = EditorGUILayout.FloatField("Physical Critical Damage", item.criticaldamage_Physical);
        item.criticaldamage_Magical = EditorGUILayout.FloatField("Magical Critical Damage", item.criticaldamage_Magical);
        item.rate_Block = EditorGUILayout.FloatField("Block Rate", item.rate_Block);
        item.rate_Dodge = EditorGUILayout.FloatField("Dodge Rate", item.rate_Dodge);
        item.rate_Parry = EditorGUILayout.FloatField("Parry Rate", item.rate_Parry);
        item.accuracy = EditorGUILayout.FloatField("Accuracy", item.accuracy);
        item.tenacity = EditorGUILayout.FloatField("Tenacity", item.tenacity);
        item.penetration_Physical = EditorGUILayout.FloatField("Physical Penetration", item.penetration_Physical);
        item.penetration_Magical = EditorGUILayout.FloatField("Magical Penetration", item.penetration_Magical);
        item.penetration_Tenacity = EditorGUILayout.FloatField("Tenacity Penetration", item.penetration_Tenacity);
        item.leech = EditorGUILayout.FloatField("Leech", item.leech);
        item.speed_Fly = EditorGUILayout.FloatField("Fly Speed", item.speed_Fly);
        item.speed_Jump = EditorGUILayout.FloatField("Jump Speed", item.speed_Jump);
        item.time = EditorGUILayout.FloatField("Time", item.time);


        EditorGUILayout.Space(10);
        EditorGUILayout.LabelField("Item Usage", EditorStyles.boldLabel);
        item.cost_Buy = EditorGUILayout.IntField("Buy Cost", item.cost_Buy);
        item.cost_Sell = EditorGUILayout.IntField("Sell Value", item.cost_Sell);
        item.stack_Count = EditorGUILayout.IntField("Stack Count", item.stack_Count);
        item.merge_Count = EditorGUILayout.IntField("Merge Count", item.merge_Count);

        EditorGUILayout.Space(10);
        EditorGUILayout.LabelField("Item Behavior", EditorStyles.boldLabel);
        item.isCritible = EditorGUILayout.Toggle("Is Critible?", item.isCritible);
        item.isInvisible = EditorGUILayout.Toggle("Is Invisible?", item.isInvisible);
        item.isPushable = EditorGUILayout.Toggle("Is Pushable?", item.isPushable);
        item.canJump = EditorGUILayout.Toggle("Can Jump?", item.canJump);
        item.canFly = EditorGUILayout.Toggle("Can Fly?", item.canFly);
        item.canMoveThroughOthers = EditorGUILayout.Toggle("Can Move Through Others?", item.canMoveThroughOthers);
        item.isStackable = EditorGUILayout.Toggle("Is Stackable?", item.isStackable);
        item.isMergable = EditorGUILayout.Toggle("Is Mergable?", item.isMergable);
        item.isEquipable = EditorGUILayout.Toggle("Is Equipable?", item.isEquipable);
        item.isEquipped = EditorGUILayout.Toggle("Is Equipped?", item.isEquipped);

        EditorGUILayout.Space(10);
        EditorGUILayout.LabelField("Spells", EditorStyles.boldLabel);
        EditorGUILayout.HelpBox("Drag and drop SpellArchitecture objects here.", MessageType.Info);

        //add button to add new spell
        if (GUILayout.Button("Add New Spell"))
        {
            //create a popup window to select a spell from the asset folder
            EditorUtility.DisplayDialog("Error", "This feature is not implemented yet.", "OK");
        }

        EditorGUILayout.Space(10);
        EditorGUILayout.LabelField("Recipe", EditorStyles.boldLabel);
        EditorGUILayout.HelpBox("Drag and drop Item objects here.", MessageType.Info);

        for (int i = 0; i < item.recipe.Count; i++)
        {
            EditorGUILayout.BeginHorizontal();
            item.recipe[i] = (Item)EditorGUILayout.ObjectField(item.recipe[i], typeof(Item), allowSceneObjects: true);
            if (GUILayout.Button("X", GUILayout.Width(20)))
            {
                item.cost_Buy -= item.recipe[i].cost_Buy;
                item.cost_Sell -= item.recipe[i].cost_Sell;
                
                item.recipe.RemoveAt(i);
            }
            EditorGUILayout.EndHorizontal();
        }

        //add button to add new item
        if (GUILayout.Button("Add New Item"))
        {
            int controlID = EditorGUIUtility.GetControlID(FocusType.Passive);
            EditorGUIUtility.ShowObjectPicker<Item>(null, true, "", controlID);
        }
        if (Event.current.commandName == "ObjectSelectorUpdated"&& Event.current.type == EventType.ExecuteCommand)
        {
            if (EditorGUIUtility.GetObjectPickerObject() != null)
            {
                item.recipe.Add((Item)EditorGUIUtility.GetObjectPickerObject());
                item.cost_Buy += item.recipe[item.recipe.Count - 1].cost_Buy;
                item.cost_Sell += item.recipe[item.recipe.Count - 1].cost_Sell;
            }
        }
    }
}
