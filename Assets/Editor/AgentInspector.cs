using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PlayableAgent))]
public class AgentInspector : Editor
{
    public override void OnInspectorGUI()
    {
        var agent = target as PlayableAgent;

        EditorGUILayout.Space(10);
        EditorGUILayout.LabelField("General Information", EditorStyles.boldLabel);
        agent.prefab = (GameObject)EditorGUILayout.ObjectField("Prefab", agent.prefab, typeof(GameObject), allowSceneObjects: true);
        agent.Name = EditorGUILayout.TextField("Name", agent.Name);
        //change the name of the asset if the name of the agent is changed, with a delay, so that the asset is not renamed every time a letter is typed
        if (GUI.changed)
        {
            EditorApplication.delayCall += () =>
            {
                AssetDatabase.RenameAsset(AssetDatabase.GetAssetPath(agent), agent.Name);
            };
        }
        EditorGUILayout.LabelField("ID                                     " + agent.ID.ToString());
        agent.type = (agentType)EditorGUILayout.EnumPopup("Type", agent.type);
        agent.mobtype = (mobType)EditorGUILayout.EnumPopup("Mob Type", agent.mobtype);
        agent.description = EditorGUILayout.TextArea(agent.description, GUILayout.Height(100));

        EditorGUILayout.Space(10);
        EditorGUILayout.LabelField("Attributes", EditorStyles.boldLabel);
        agent.level = EditorGUILayout.FloatField("Level", agent.level);
        agent.modifier = EditorGUILayout.FloatField("Modifier", agent.modifier);
        agent.experience = EditorGUILayout.FloatField("Experience", agent.experience);
        agent.damage_Physical = EditorGUILayout.FloatField("Physical Damage", agent.damage_Physical);
        agent.damage_range = EditorGUILayout.FloatField("Range Damage", agent.damage_range);
        agent.damage_Magical = EditorGUILayout.FloatField("Magical Damage", agent.damage_Magical);
        agent.damage_True = EditorGUILayout.FloatField("True Damage", agent.damage_True);
        agent.speed_Movement = EditorGUILayout.FloatField("Movement Speed", agent.speed_Movement);
        agent.speed_Attack = EditorGUILayout.FloatField("Attack Speed", agent.speed_Attack);
        agent.speed_Cast = EditorGUILayout.FloatField("Cast Speed", agent.speed_Cast);
        agent.penetration_Physical = EditorGUILayout.FloatField("Physical Penetration", agent.penetration_Physical);
        agent.penetration_Magical = EditorGUILayout.FloatField("Magical Penetration", agent.penetration_Magical);
        agent.criticalchance_Physical = EditorGUILayout.FloatField("Physical Critical Chance", agent.criticalchance_Physical);
        agent.criticalchance_Magical = EditorGUILayout.FloatField("Magical Critical Chance", agent.criticalchance_Magical);
        agent.criticaldamage_Physical = EditorGUILayout.FloatField("Physical Critical Damage", agent.criticaldamage_Physical);
        agent.criticaldamage_Magical = EditorGUILayout.FloatField("Magical Critical Damage", agent.criticaldamage_Magical);
        

        EditorGUILayout.Space(10);
        EditorGUILayout.LabelField("Stats", EditorStyles.boldLabel);
        agent.hitPoint = EditorGUILayout.FloatField("Hit Points", agent.hitPoint);
        agent.hitPointCurrent = EditorGUILayout.FloatField("Current Hit Points", agent.hitPointCurrent);
        agent.regen_hitPoint = EditorGUILayout.FloatField("HP Regeneration", agent.regen_hitPoint);
        agent.manaPoint = EditorGUILayout.FloatField("Mana Points", agent.manaPoint);
        agent.manaPointCurrent = EditorGUILayout.FloatField("Current Mana Points", agent.manaPointCurrent);
        agent.regen_manaPoint = EditorGUILayout.FloatField("Mana Regeneration", agent.regen_manaPoint);
        agent.wildPoint = EditorGUILayout.FloatField("Wild Points", agent.wildPoint);
        agent.regen_wildPoint = EditorGUILayout.FloatField("Wild Regeneration", agent.regen_wildPoint);
        agent.energyPoint = EditorGUILayout.FloatField("Energy Points", agent.energyPoint);
        agent.regen_energyPoint = EditorGUILayout.FloatField("Energy Regeneration", agent.regen_energyPoint);
        agent.armor_Physical = EditorGUILayout.FloatField("Physical Armor", agent.armor_Physical);
        agent.armor_Magical = EditorGUILayout.FloatField("Magical Armor", agent.armor_Magical);
        agent.rate_Block = EditorGUILayout.FloatField("Block Rate", agent.rate_Block);
        agent.rate_Dodge = EditorGUILayout.FloatField("Dodge Rate", agent.rate_Dodge);
        agent.rate_Parry = EditorGUILayout.FloatField("Parry Rate", agent.rate_Parry);
        agent.tenacity = EditorGUILayout.FloatField("Tenacity", agent.tenacity);
        agent.penetration_Tenacity = EditorGUILayout.FloatField("Tenacity Penetration", agent.penetration_Tenacity);
        agent.speed_Jump = EditorGUILayout.FloatField("Jump Speed", agent.speed_Jump);
        agent.speed_Fly = EditorGUILayout.FloatField("Fly Speed", agent.speed_Fly);

        EditorGUILayout.Space(10);
        EditorGUILayout.LabelField("Agent Behavior", EditorStyles.boldLabel);
        agent.isAlive = EditorGUILayout.Toggle("Is Alive?", agent.isAlive);
        agent.isCritible = EditorGUILayout.Toggle("Is Critible?", agent.isCritible);
        agent.isInvisible = EditorGUILayout.Toggle("Is Invisible?", agent.isInvisible);
        agent.isImmuneCriticalHit = EditorGUILayout.Toggle("Is Immune Critical Hit?", agent.isImmuneCriticalHit);
        agent.isPushable = EditorGUILayout.Toggle("Is Pushable?", agent.isPushable);
        agent.canJump = EditorGUILayout.Toggle("Can Jump?", agent.canJump);
        agent.canFly = EditorGUILayout.Toggle("Can Fly?", agent.canFly);
        agent.canMoveThroughOthers = EditorGUILayout.Toggle("Can Move Through Others?", agent.canMoveThroughOthers);
        agent.isFriendly = EditorGUILayout.Toggle("Is Friendly?", agent.isFriendly);
        agent.isEnemy = EditorGUILayout.Toggle("Is Enemy?", agent.isEnemy);

        EditorGUILayout.Space(10);
        EditorGUILayout.LabelField("Agent Status", EditorStyles.boldLabel);
        agent.gold = EditorGUILayout.IntField("Gold", agent.gold);
        

        EditorGUILayout.Space(10);
        EditorGUILayout.LabelField("Spells", EditorStyles.boldLabel);
        //check if the list is empty
        if (agent.activeSpells == null)
        {
            agent.activeSpells = new List<SpellArchitecture>();
        }
        //check if the list is empty
        if (agent.passiveSpells == null)
        {
            agent.passiveSpells = new List<SpellArchitecture>();
        }

        //add label
        EditorGUILayout.LabelField("Active Spells", EditorStyles.boldLabel);

        //add a new spell
        if (GUILayout.Button("Add Active Spell"))
        {
            agent.activeSpells.Add(null);
        }
        //show all the active spells
        for (int i = 0; i < agent.activeSpells.Count; i++)
        {
            EditorGUILayout.BeginHorizontal();
            agent.activeSpells[i] = (SpellArchitecture)EditorGUILayout.ObjectField(agent.activeSpells[i], typeof(SpellArchitecture), allowSceneObjects: true);
            if (GUILayout.Button("Remove"))
            {
                agent.activeSpells.RemoveAt(i);
            }
            EditorGUILayout.EndHorizontal();
        }

        //add label
        EditorGUILayout.LabelField("Passive Spells", EditorStyles.boldLabel);

        //add a new spell
        if (GUILayout.Button("Add Passive Spell"))
        {
            agent.passiveSpells.Add(null);
        }
        //show all the passive spells
        for (int i = 0; i < agent.passiveSpells.Count; i++)
        {
            EditorGUILayout.BeginHorizontal();
            agent.passiveSpells[i] = (SpellArchitecture)EditorGUILayout.ObjectField(agent.passiveSpells[i], typeof(SpellArchitecture), allowSceneObjects: true);
            if (GUILayout.Button("Remove"))
            {
                agent.passiveSpells.RemoveAt(i);
            }
            EditorGUILayout.EndHorizontal();
        }

        // Apply modifications
        if (GUI.changed)
        {
            EditorUtility.SetDirty(agent);
        }
    }
}
