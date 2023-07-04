using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Text;
using System;

public class SOtoES : EditorWindow
{
    private enum Tab
    {
        Agents,
        Spells,
        Items
    }

    private Tab currentTab = Tab.Agents;

    private List<AgentObject> agentsList = new List<AgentObject>(); // List to store instances of AgentObject
    private List<SpellArchitecture> spellsList = new List<SpellArchitecture>(); // List to store instances of SpellArchitecture

    private List<ItemObject> itemsList = new List<ItemObject>(); // List to store instances of ItemObject

    private Vector2 agentScrollPosition; // Scroll position for the agent list
    private Vector2 spellScrollPosition; // Scroll position for the spell list

    private Vector2 itemScrollPosition; // Scroll position for the item list

    [MenuItem("NexusEngine/ScriptableObjects/SOWindow")]
    private static void ShowWindow()
    {
        var window = GetWindow<SOtoES>();
        window.titleContent = new GUIContent("SO Editor");
        window.Show();
    }

    private void OnGUI()
    {
        GUILayout.Label("SO Editor", EditorStyles.boldLabel);

        //add space between label and scrollview
        GUILayout.Space(10f);

        // Tabs for agents and spells
        currentTab = (Tab)GUILayout.Toolbar((int)currentTab, new string[] { "Agents", "Spells", "Items" });

        if (currentTab == Tab.Agents)
        {
            DisplayAgentsTab();
        }
        else if (currentTab == Tab.Spells)
        {
            DisplaySpellsTab();
        }
        else if (currentTab == Tab.Items)
        {
            DisplayItemsTab();
        }
    }

    private void OnInspectorUpdate()
    {
        // Show all the items in the specified folders in the project window 
        // and add them to the respective lists
        agentsList.Clear();
        spellsList.Clear();
        itemsList.Clear();

        string[] agentGuids = AssetDatabase.FindAssets("t:AgentObject", new[] { "Assets/Scriptable Objects/Objects" });
        foreach (string guid in agentGuids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            AgentObject agent = AssetDatabase.LoadAssetAtPath<AgentObject>(path);
            agentsList.Add(agent);
        }

        string[] spellGuids = AssetDatabase.FindAssets("t:SpellArchitecture", new[] { "Assets/Scriptable Objects/Objects/Spells" });
        foreach (string guid in spellGuids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            SpellArchitecture spell = AssetDatabase.LoadAssetAtPath<SpellArchitecture>(path);
            spellsList.Add(spell);
        }

        string[] itemGuids = AssetDatabase.FindAssets("t:ItemObject", new[] { "Assets/Scriptable Objects/Objects/Items" });
        foreach (string guid in itemGuids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            ItemObject item = AssetDatabase.LoadAssetAtPath<ItemObject>(path);
            itemsList.Add(item);
        }

        // Force the window to update regularly
        Repaint();
    }

    private void DisplayAgentsTab()
    {   
        // Label for the agent objects, but also displays the number of agent objects
        GUILayout.Label("Agent Objects (" + agentsList.Count + ")", EditorStyles.boldLabel);

        //add space between label and scrollview
        GUILayout.Space(10f);


        // If there are no agent objects, display a message
        if (agentsList.Count == 0)
        {
            GUILayout.Label("No agent objects found. Create a new agent object to get started.");
        }

        // Scroll view to contain the list of agent objects
        agentScrollPosition = EditorGUILayout.BeginScrollView(agentScrollPosition);

        // Display each agent object
        for (int i = 0; i < agentsList.Count; i++)
        {
            EditorGUILayout.BeginHorizontal();

            // Display the agent's name
            GUILayout.Label(agentsList[i].name, EditorStyles.boldLabel, GUILayout.Width(200f));

            // If the agent's name is empty, set it to "New Agent"
            if (agentsList[i].name == "")
            {
                agentsList[i].name = "New Agent";
            }

            // Add buttons to edit or delete the agent object
            if (GUILayout.Button("Edit"))
            {
                // Open the edit window for the agent object
                AgentEditorWindow.OpenWindow(agentsList[i]);
            }

            if (GUILayout.Button("Delete"))
            {
                // Ask the user for confirmation before deleting the agent object
                if (EditorUtility.DisplayDialog("Delete Agent Object",
                    "Are you sure you want to delete the agent object: " + agentsList[i].name + "?",
                    "Yes", "No"))
                {
                    // Delete the agent object
                    DeleteAgentObject(agentsList[i]);
                }
            }
            EditorGUILayout.EndHorizontal();
        }

        EditorGUILayout.EndScrollView();


        GUILayout.Space(10f);

        // Button to create a new agent object
        if (GUILayout.Button("Create New Agent Object"))
        {
            CreateNewAgentObject();
        }

        // Force the window to update regularly
        Repaint();
    }

    private void DisplaySpellsTab()
    {
        // Label for the spell objects, but also displays the number of spell objects
        GUILayout.Label("Spell Objects (" + spellsList.Count + ")", EditorStyles.boldLabel);

        //add space between label and scrollview
        GUILayout.Space(10f);

        // If there are no spell objects, display a message
        if (spellsList.Count == 0)
        {
            GUILayout.Label("No spell objects found. Create a new spell object to get started.");
        }

        // Scroll view to contain the list of spell objects
        spellScrollPosition = EditorGUILayout.BeginScrollView(spellScrollPosition);

        // Display each spell object
        for (int i = 0; i < spellsList.Count; i++)
        {
            EditorGUILayout.BeginHorizontal();

            // Display the spell's name
            GUILayout.Label(spellsList[i].name, EditorStyles.boldLabel, GUILayout.Width(200f));

            // Add buttons to edit or delete the spell object
            if (GUILayout.Button("Edit"))
            {
                // Open the edit window for the spell object
                SpellEditorWindow.OpenWindow(spellsList[i]);
            }

            if (GUILayout.Button("Delete"))
            {
                // Ask the user for confirmation before deleting the spell object
                if (EditorUtility.DisplayDialog("Delete Spell Object",
                    "Are you sure you want to delete the spell object: " + spellsList[i].name + "?",
                    "Yes", "No"))
                {
                    // Delete the spell object
                    DeleteSpellObject(spellsList[i]);
                }
            }

            EditorGUILayout.EndHorizontal();
        }

        EditorGUILayout.EndScrollView();

        GUILayout.Space(10f);

        // Button to create a new spell object
        if (GUILayout.Button("Create New Spell Object"))
        {
            CreateNewSpellObject();
        }

        // Force the window to update regularly
        Repaint();
    }

    private void DisplayItemsTab()
    {
        // Label for the item objects, but also displays the number of item objects
        GUILayout.Label("Item Objects (" + itemsList.Count + ")", EditorStyles.boldLabel);

        //add space between label and scrollview
        GUILayout.Space(10f);

        // If there are no item objects, display a message
        if (itemsList.Count == 0)
        {
            GUILayout.Label("No item objects found. Create a new item object to get started.");
        }

        // Scroll view to contain the list of item objects
        itemScrollPosition = EditorGUILayout.BeginScrollView(itemScrollPosition);

        // Display each item object
        for (int i = 0; i < itemsList.Count; i++)
        {
            EditorGUILayout.BeginHorizontal();

            // Display the item's name
            GUILayout.Label(itemsList[i].name, EditorStyles.boldLabel, GUILayout.Width(200f));

            // Add buttons to edit or delete the item object
            if (GUILayout.Button("Edit"))
            {
                // Open the edit window for the item object
                ItemEditorWindow.OpenWindow(itemsList[i]);
            }

            if (GUILayout.Button("Delete"))
            {
                // Ask the user for confirmation before deleting the item object
                if (EditorUtility.DisplayDialog("Delete Item Object",
                    "Are you sure you want to delete the item object: " + itemsList[i].name + "?",
                    "Yes", "No"))
                {
                    // Delete the item object
                    DeleteItemObject(itemsList[i]);
                }
            }

            EditorGUILayout.EndHorizontal();
        }

        EditorGUILayout.EndScrollView();

        GUILayout.Space(10f);

        // Button to create a new item object
        if (GUILayout.Button("Create New Item Object"))
        {
            CreateNewItemObject();
        }

        // Force the window to update regularly
        Repaint();
    }

    private void CreateNewAgentObject()
    {
        // Create a new instance of the AgentObject
        AgentObject newAgent = ScriptableObject.CreateInstance<AgentObject>();

        // Set the name of the agent
        newAgent.name = "New Agent";
        newAgent.Name = "New Agent";

        // Add the new agent to the list
        agentsList.Add(newAgent);

        // Create a new asset for the agent object
        AssetDatabase.CreateAsset(newAgent, "Assets/Scriptable Objects/Objects/Heroes/" + newAgent.name + ".asset");

        //Open the edit window for the agent object
        AgentEditorWindow.OpenWindow(newAgent);

        // Force the window to update regularly
        Repaint();
    }

    private void DeleteAgentObject(AgentObject agent)
    {
        // Remove the agent from the list
        agentsList.Remove(agent);

        // Destroy the agent object asset
        AssetDatabase.DeleteAsset(AssetDatabase.GetAssetPath(agent));
    }

    private void CreateNewSpellObject()
    {
        // Create a new instance of the Spell
        Spells newSpell = ScriptableObject.CreateInstance<Spells>();
        newSpell.name = "New Spell";
        newSpell.Name = "New Spell";

        // Add the new spell to the list
        spellsList.Add(newSpell);

        // Create a new asset for the spell object
        AssetDatabase.CreateAsset(newSpell, "Assets/Scriptable Objects/Objects/Spells/Objects/" + newSpell.name + ".asset");

        //Open the edit window for the spell object
        SpellEditorWindow.OpenWindow(newSpell);

        // Force the window to update regularly
        Repaint();
    }

    private void DeleteSpellObject(SpellArchitecture spell)
    {
        // Remove the spell from the list
        spellsList.Remove(spell);

        // Destroy the spell object asset
        AssetDatabase.DeleteAsset(AssetDatabase.GetAssetPath(spell));
    }

    private void CreateNewItemObject()
    {
        // Create a new instance of the Item
        Item newitem = ScriptableObject.CreateInstance<Item>();
        newitem.name = "New Item";
        newitem.Name = "New Item";

        // Add the new item to the list
        itemsList.Add(newitem);

        // Create a new asset for the item object
        AssetDatabase.CreateAsset(newitem, "Assets/Scriptable Objects/Objects/Items/ItemObjects/" + newitem.name + ".asset");

        //Open the edit window for the item object
        ItemEditorWindow.OpenWindow(newitem);

        // Force the window to update regularly
        Repaint();
    }

    private void DeleteItemObject(ItemObject item)
    {
        // Remove the item from the list
        itemsList.Remove(item);

        // Destroy the item object asset
        AssetDatabase.DeleteAsset(AssetDatabase.GetAssetPath(item));
    }

    
}

// Custom EditorWindow for editing AgentObjects
public class AgentEditorWindow : EditorWindow
{
    private AgentObject agent;

    private Vector2 scrollPos;

    public static void OpenWindow(AgentObject agent)
    {
        var window = GetWindow<AgentEditorWindow>();
        window.titleContent = new GUIContent("Agent Editor");
        window.agent = agent;
        window.Show();
    }

    private void OnGUI()
    {
        EditorGUILayout.LabelField("Agent Editor("+agent.name+")", EditorStyles.boldLabel);

        if(agent != null)
        {
            scrollPos = EditorGUILayout.BeginScrollView(scrollPos);

        EditorGUILayout.Space(10);
        EditorGUILayout.LabelField("General Information", EditorStyles.boldLabel);
        agent.prefab = (GameObject)EditorGUILayout.ObjectField("Prefab", agent.prefab, typeof(GameObject), allowSceneObjects: true);
        agent.Name = EditorGUILayout.TextField("Name", agent.Name);
        if (GUI.changed)
        {
            EditorApplication.delayCall += () =>
            {
                AssetDatabase.RenameAsset(AssetDatabase.GetAssetPath(agent), agent.Name);
            };
        }
        agent.ID = EditorGUILayout.IntField("ID", agent.ID);
        agent.type = (agentType)EditorGUILayout.EnumPopup("Type", agent.type);
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
        
        //end scroll view
        EditorGUILayout.EndScrollView();
    }
    if (GUI.changed)
    {
        EditorUtility.SetDirty(agent);
    }
    }
}

// Custom EditorWindow for editing SpellArchitectures
public class SpellEditorWindow : EditorWindow
{
    private static SpellArchitecture spellObject;

    //Scroll View
    private Vector2 scrollPos; 

    public static void OpenWindow(SpellArchitecture spell)
    {
        var window = GetWindow<SpellEditorWindow>();
        window.titleContent = new GUIContent("Spell Editor");
        spellObject = spell;
        window.Show();
    }

    private void OnGUI()
    {
        EditorGUILayout.LabelField("Spell Editor("+spellObject.name+")", EditorStyles.boldLabel);

        if (spellObject != null)
        {
            scrollPos = EditorGUILayout.BeginScrollView(scrollPos);
        EditorGUILayout.Space(30);
        EditorGUILayout.LabelField("ID                                     " + spellObject.ID.ToString());
        spellObject.name = EditorGUILayout.TextField("Name", spellObject.name);
        spellObject.SplashArt = (Sprite)EditorGUILayout.ObjectField("Spalsh Art",spellObject.SplashArt,typeof(Sprite),allowSceneObjects:true);
        EditorGUILayout.LabelField("Description", EditorStyles.boldLabel);
        spellObject.description = EditorGUILayout.TextArea(spellObject.description, GUILayout.Height(100));

        EditorGUILayout.Space(10);
        spellObject.model = (GameObject)EditorGUILayout.ObjectField("Model", spellObject.model, typeof(GameObject), allowSceneObjects: false);
        


        EditorGUILayout.Space(10);
        EditorGUILayout.LabelField("Spell Architecture", EditorStyles.boldLabel);
        spellObject.type = (SpellArcType)EditorGUILayout.EnumPopup("Type", spellObject.type);

        EditorGUILayout.Space(10);
        EditorGUILayout.LabelField("Damage Type", EditorStyles.boldLabel);
        spellObject.damageType = (DamageType)EditorGUILayout.EnumPopup("Damage Type", spellObject.damageType);

        EditorGUILayout.Space(10);
        EditorGUILayout.LabelField("Delay Time", EditorStyles.boldLabel);
        spellObject.delay = EditorGUILayout.Toggle("Has Delay Time ?",spellObject.delay);

        if (spellObject.delay)
        {
            spellObject.delayTime = EditorGUILayout.FloatField("Delay time", spellObject.delayTime);
        }
        else
        {
            spellObject.delayTime = 0;
        }
        
        EditorGUILayout.Space(10);
        EditorGUILayout.LabelField("Cooldown", EditorStyles.boldLabel);
        spellObject.cooldown = EditorGUILayout.Toggle("Has Cooldown ?", spellObject.cooldown);

        if (spellObject.cooldown)
        {
            spellObject.CD = EditorGUILayout.FloatField("Cooldown", spellObject.CD);
        }
        else
        {
            spellObject.CD = 0;
        }
        if (spellObject.cooldown)
        {
            spellObject.maxCooldown = EditorGUILayout.FloatField("Max Cooldown", spellObject.maxCooldown);
        }
        else
        {
            spellObject.maxCooldown = 0;
        }

        EditorGUILayout.Space(10);
        EditorGUILayout.LabelField("Cast Time", EditorStyles.boldLabel);
        spellObject.cast = EditorGUILayout.Toggle("Has Cast Time ?",spellObject.cast);

        if (spellObject.cast)
        {
            spellObject.castTime = EditorGUILayout.FloatField("Cast time", spellObject.castTime);
            
        }
        else
        {
            spellObject.castTime = 0;
        }

        EditorGUILayout.Space(10);
        EditorGUILayout.LabelField("Spell Object Type", EditorStyles.boldLabel);
        spellObject.spellObjectType = (SpellObjectType)EditorGUILayout.EnumPopup("Object Type", spellObject.spellObjectType);


        EditorGUILayout.Space(10);
        EditorGUILayout.LabelField("Adjustable Area", EditorStyles.boldLabel);
        spellObject.defaultHitArea = EditorGUILayout.Toggle("Default Hit Area", spellObject.defaultHitArea);

        if (spellObject.defaultHitArea)
        {
            spellObject.maxlenght = EditorGUILayout.FloatField("Max Lenght", spellObject.maxlenght);
            spellObject.lenght = EditorGUILayout.FloatField("Lenght", spellObject.lenght);
            spellObject.maxwidth = EditorGUILayout.FloatField("Max Width", spellObject.maxwidth);
            spellObject.width = EditorGUILayout.FloatField("Width", spellObject.width);
            spellObject.maxheight = EditorGUILayout.FloatField("Max Height", spellObject.maxheight);
            spellObject.height = EditorGUILayout.FloatField("Height", spellObject.height);
            spellObject.maxdepth = EditorGUILayout.FloatField("Max Depth", spellObject.maxdepth);
            spellObject.depth = EditorGUILayout.FloatField("Depth", spellObject.depth);
            spellObject.maxspeed = EditorGUILayout.FloatField("Max Speed", spellObject.maxspeed);
            spellObject.speed = EditorGUILayout.FloatField("Speed", spellObject.speed);
            
            spellObject.havecolor = EditorGUILayout.Toggle("Have Color", spellObject.havecolor);

            if(spellObject.havecolor)
            {
                spellObject.color = EditorGUILayout.ColorField("Color", spellObject.color);
            }
            else
            {
                spellObject.color = Color.white;
            }
        }
        else
        {
            spellObject.maxlenght = 0;
            spellObject.lenght = 0;
            spellObject.maxwidth = 0;
            spellObject.width = 0;
            spellObject.maxspeed = 0;
            spellObject.speed = 0;
        }


        EditorGUILayout.Space(10);
        EditorGUILayout.LabelField("Is this a Unique Shot?", EditorStyles.boldLabel);
        spellObject.uniqueShot = EditorGUILayout.Toggle("Unique Shot", spellObject.uniqueShot);

        if (spellObject.uniqueShot)
        {
            spellObject.way = (Sprite)EditorGUILayout.ObjectField("Way", spellObject.way, typeof(Sprite), allowSceneObjects: true);
            spellObject.hitStop = EditorGUILayout.Toggle("Hit Stop", spellObject.hitStop);
        }
        else
        {
            spellObject.way = null;
            spellObject.hitStop = false;
        }


        EditorGUILayout.Space(10);
        EditorGUILayout.LabelField("Sprite Area", EditorStyles.boldLabel);
        spellObject.spriteHitArea = EditorGUILayout.Toggle("Sprite Hit Area", spellObject.spriteHitArea);

        if (spellObject.spriteHitArea)
        {
            spellObject.hitArea = (Sprite)EditorGUILayout.ObjectField("Hit Area", spellObject.hitArea, typeof(Sprite), allowSceneObjects: true);
        }
        else
        {
            spellObject.hitArea = null;
        }


        EditorGUILayout.Space(10);
        EditorGUILayout.LabelField("Is There Any Way Effect?", EditorStyles.boldLabel);
        spellObject.wayEffect = EditorGUILayout.Toggle("Way Effect", spellObject.wayEffect);

        if (spellObject.wayEffect)
        {
            spellObject.wayEffectTime = EditorGUILayout.FloatField("Way Effect Time", spellObject.wayEffectTime);
        }
        else
        {
            spellObject.wayEffectTime = 0;
        }


        EditorGUILayout.Space(10);
        EditorGUILayout.LabelField("Shot Stay a While After a Hit?", EditorStyles.boldLabel);
        spellObject.stay = EditorGUILayout.Toggle("Stay", spellObject.stay);

        if (spellObject.stay)
        {
            spellObject.stayTime = EditorGUILayout.FloatField("Stay Time", spellObject.stayTime);
        }
        else
        {
            spellObject.stayTime = 0;
        }


        EditorGUILayout.Space(10);
        EditorGUILayout.LabelField("Shot Return After a Hit?", EditorStyles.boldLabel);
        spellObject.Return = EditorGUILayout.Toggle("Return", spellObject.Return);

        if (spellObject.Return)
        {
            spellObject.maxreturnSpeed = EditorGUILayout.FloatField("Max Return Speed", spellObject.maxreturnSpeed);
            spellObject.returnSpeed = EditorGUILayout.FloatField("Return Speed", spellObject.returnSpeed);
        }
        else
        {
            spellObject.maxreturnSpeed = 0;
            spellObject.returnSpeed = 0;
        }

        EditorGUILayout.Space(10);
        EditorGUILayout.LabelField("Player", EditorStyles.boldLabel);
        spellObject.player = (GameObject)EditorGUILayout.ObjectField("Player", spellObject.player, typeof(GameObject), allowSceneObjects: true);

        EditorGUILayout.Space(10);
        EditorGUILayout.LabelField("Shot Targetable?", EditorStyles.boldLabel);
        spellObject.targetable = EditorGUILayout.Toggle("Targetable", spellObject.targetable);

        if(spellObject.targetable)
        {
            spellObject.target = (GameObject)EditorGUILayout.ObjectField("Target", spellObject.target, typeof(GameObject), allowSceneObjects: true);
        }
        else
        {
            spellObject.target = null;
            EditorGUILayout.Space(10);
            EditorGUILayout.LabelField("Shot Direction", EditorStyles.boldLabel);
        
            spellObject.direction = MousePosition.MousePosition.GetMousePosition();
            EditorGUILayout.Vector3Field("Direction", spellObject.direction);
        }    


        EditorGUILayout.Space(10);
        EditorGUILayout.LabelField("How Many New/Unique Architecture Have This Shot?", EditorStyles.boldLabel);

        spellObject.architectureCount = EditorGUILayout.IntField("Architecture Count", spellObject.architectureCount);
        if(spellObject.architectureCount > 0)
        {
            for (int i = 0; i < spellObject.architectureCount; i++)
            {
                spellObject.count.Add(null);
                EditorGUILayout.LabelField("New/Unique Architecture", EditorStyles.boldLabel);
                spellObject.count[i] = (SpellArchitecture)EditorGUILayout.ObjectField("Architecture", spellObject.count[i], typeof(SpellArchitecture), allowSceneObjects: true);
            }
        }
        else if(spellObject.architectureCount < 0)
                spellObject.count.Clear();

        else
        {
            spellObject.architectureCount = 0;
        }
        
            
        
        EditorGUILayout.EndScrollView();
        }

        if (GUI.changed)
        {
            EditorUtility.SetDirty(spellObject);
        }


            
    }
}

public class ItemEditorWindow : EditorWindow
{
    private ItemObject item;

    private Vector2 scrollPos;

    public static void OpenWindow(ItemObject item)
    {
        var window = GetWindow<ItemEditorWindow>();
        window.titleContent = new GUIContent("Item Editor");
        window.item = item;
        window.Show();
    }


    public void OnGUI()
    {
        EditorGUILayout.LabelField("Item Editor("+item.name+")", EditorStyles.boldLabel);

        if( item != null)
        {
            scrollPos = EditorGUILayout.BeginScrollView(scrollPos);

        EditorGUILayout.Space(10);
        EditorGUILayout.LabelField("General Information", EditorStyles.boldLabel);
        item.ID = EditorGUILayout.IntField("ID", item.ID);
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

        //add button to add new item
        if (GUILayout.Button("Add New Item"))
        {
            //create a popup window to select an item from the asset folder
            EditorUtility.DisplayDialog("Error", "This feature is not implemented yet.", "OK");

        }
            EditorGUILayout.EndScrollView();
        }

        if(GUI.changed)
        {
            EditorUtility.SetDirty(item);
        }
    }
}

