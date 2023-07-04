using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using MousePosition;

[CustomEditor(typeof(Spells))]
public class SpellInspectorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        var arcitecture = target as Spells;


        EditorGUILayout.Space(30);
        EditorGUILayout.LabelField("ID                                     " + arcitecture.ID.ToString());
        arcitecture.name = EditorGUILayout.TextField("Name", arcitecture.name);
        arcitecture.SplashArt = (Sprite)EditorGUILayout.ObjectField("Spalsh Art",arcitecture.SplashArt,typeof(Sprite),allowSceneObjects:true);
        EditorGUILayout.LabelField("Description", EditorStyles.boldLabel);
        arcitecture.description = EditorGUILayout.TextArea(arcitecture.description, GUILayout.Height(100));

        EditorGUILayout.Space(10);
        arcitecture.model = (GameObject)EditorGUILayout.ObjectField("Model", arcitecture.model, typeof(GameObject), allowSceneObjects: false);
        


        EditorGUILayout.Space(10);
        EditorGUILayout.LabelField("Spell Architecture", EditorStyles.boldLabel);
        arcitecture.type = (SpellArcType)EditorGUILayout.EnumPopup("Type", arcitecture.type);

        EditorGUILayout.Space(10);
        EditorGUILayout.LabelField("Damage Type", EditorStyles.boldLabel);
        arcitecture.damageType = (DamageType)EditorGUILayout.EnumPopup("Damage Type", arcitecture.damageType);

        EditorGUILayout.Space(10);
        EditorGUILayout.LabelField("Delay Time", EditorStyles.boldLabel);
        arcitecture.delay = EditorGUILayout.Toggle("Has Delay Time ?",arcitecture.delay);

        if (arcitecture.delay)
        {
            arcitecture.delayTime = EditorGUILayout.FloatField("Delay time", arcitecture.delayTime);
        }
        else
        {
            arcitecture.delayTime = 0;
        }
        
        EditorGUILayout.Space(10);
        EditorGUILayout.LabelField("Cooldown", EditorStyles.boldLabel);
        arcitecture.cooldown = EditorGUILayout.Toggle("Has Cooldown ?", arcitecture.cooldown);

        if (arcitecture.cooldown)
        {
            arcitecture.CD = EditorGUILayout.FloatField("Cooldown", arcitecture.CD);
        }
        else
        {
            arcitecture.CD = 0;
        }
        if (arcitecture.cooldown)
        {
            arcitecture.maxCooldown = EditorGUILayout.FloatField("Max Cooldown", arcitecture.maxCooldown);
        }
        else
        {
            arcitecture.maxCooldown = 0;
        }

        EditorGUILayout.Space(10);
        EditorGUILayout.LabelField("Cast Time", EditorStyles.boldLabel);
        arcitecture.cast = EditorGUILayout.Toggle("Has Cast Time ?",arcitecture.cast);

        if (arcitecture.cast)
        {
            arcitecture.castTime = EditorGUILayout.FloatField("Cast time", arcitecture.castTime);
            
        }
        else
        {
            arcitecture.castTime = 0;
        }

        EditorGUILayout.Space(10);
        EditorGUILayout.LabelField("Spell Object Type", EditorStyles.boldLabel);
        arcitecture.spellObjectType = (SpellObjectType)EditorGUILayout.EnumPopup("Object Type", arcitecture.spellObjectType);


        EditorGUILayout.Space(10);
        EditorGUILayout.LabelField("Adjustable Area", EditorStyles.boldLabel);
        arcitecture.defaultHitArea = EditorGUILayout.Toggle("Default Hit Area", arcitecture.defaultHitArea);

        if (arcitecture.defaultHitArea)
        {
            arcitecture.maxlenght = EditorGUILayout.FloatField("Max Lenght", arcitecture.maxlenght);
            arcitecture.lenght = EditorGUILayout.FloatField("Lenght", arcitecture.lenght);
            arcitecture.maxwidth = EditorGUILayout.FloatField("Max Width", arcitecture.maxwidth);
            arcitecture.width = EditorGUILayout.FloatField("Width", arcitecture.width);
            arcitecture.maxheight = EditorGUILayout.FloatField("Max Height", arcitecture.maxheight);
            arcitecture.height = EditorGUILayout.FloatField("Height", arcitecture.height);
            arcitecture.maxdepth = EditorGUILayout.FloatField("Max Depth", arcitecture.maxdepth);
            arcitecture.depth = EditorGUILayout.FloatField("Depth", arcitecture.depth);
            arcitecture.maxspeed = EditorGUILayout.FloatField("Max Speed", arcitecture.maxspeed);
            arcitecture.speed = EditorGUILayout.FloatField("Speed", arcitecture.speed);
            
            arcitecture.havecolor = EditorGUILayout.Toggle("Have Color", arcitecture.havecolor);

            if(arcitecture.havecolor)
            {
                arcitecture.color = EditorGUILayout.ColorField("Color", arcitecture.color);
            }
            else
            {
                arcitecture.color = Color.white;
            }
        }
        else
        {
            arcitecture.maxlenght = 0;
            arcitecture.lenght = 0;
            arcitecture.maxwidth = 0;
            arcitecture.width = 0;
            arcitecture.maxspeed = 0;
            arcitecture.speed = 0;
        }


        EditorGUILayout.Space(10);
        EditorGUILayout.LabelField("Is this a Unique Shot?", EditorStyles.boldLabel);
        arcitecture.uniqueShot = EditorGUILayout.Toggle("Unique Shot", arcitecture.uniqueShot);

        if (arcitecture.uniqueShot)
        {
            arcitecture.way = (Sprite)EditorGUILayout.ObjectField("Way", arcitecture.way, typeof(Sprite), allowSceneObjects: true);
            arcitecture.hitStop = EditorGUILayout.Toggle("Hit Stop", arcitecture.hitStop);
        }
        else
        {
            arcitecture.way = null;
            arcitecture.hitStop = false;
        }


        EditorGUILayout.Space(10);
        EditorGUILayout.LabelField("Sprite Area", EditorStyles.boldLabel);
        arcitecture.spriteHitArea = EditorGUILayout.Toggle("Sprite Hit Area", arcitecture.spriteHitArea);

        if (arcitecture.spriteHitArea)
        {
            arcitecture.hitArea = (Sprite)EditorGUILayout.ObjectField("Hit Area", arcitecture.hitArea, typeof(Sprite), allowSceneObjects: true);
        }
        else
        {
            arcitecture.hitArea = null;
        }


        EditorGUILayout.Space(10);
        EditorGUILayout.LabelField("Is There Any Way Effect?", EditorStyles.boldLabel);
        arcitecture.wayEffect = EditorGUILayout.Toggle("Way Effect", arcitecture.wayEffect);

        if (arcitecture.wayEffect)
        {
            arcitecture.wayEffectTime = EditorGUILayout.FloatField("Way Effect Time", arcitecture.wayEffectTime);
        }
        else
        {
            arcitecture.wayEffectTime = 0;
        }


        EditorGUILayout.Space(10);
        EditorGUILayout.LabelField("Shot Stay a While After a Hit?", EditorStyles.boldLabel);
        arcitecture.stay = EditorGUILayout.Toggle("Stay", arcitecture.stay);

        if (arcitecture.stay)
        {
            arcitecture.stayTime = EditorGUILayout.FloatField("Stay Time", arcitecture.stayTime);
        }
        else
        {
            arcitecture.stayTime = 0;
        }


        EditorGUILayout.Space(10);
        EditorGUILayout.LabelField("Shot Return After a Hit?", EditorStyles.boldLabel);
        arcitecture.Return = EditorGUILayout.Toggle("Return", arcitecture.Return);

        if (arcitecture.Return)
        {
            arcitecture.maxreturnSpeed = EditorGUILayout.FloatField("Max Return Speed", arcitecture.maxreturnSpeed);
            arcitecture.returnSpeed = EditorGUILayout.FloatField("Return Speed", arcitecture.returnSpeed);
        }
        else
        {
            arcitecture.maxreturnSpeed = 0;
            arcitecture.returnSpeed = 0;
        }

        EditorGUILayout.Space(10);
        EditorGUILayout.LabelField("Player", EditorStyles.boldLabel);
        arcitecture.player = (GameObject)EditorGUILayout.ObjectField("Player", arcitecture.player, typeof(GameObject), allowSceneObjects: true);

        EditorGUILayout.Space(10);
        EditorGUILayout.LabelField("Shot Targetable?", EditorStyles.boldLabel);
        arcitecture.targetable = EditorGUILayout.Toggle("Targetable", arcitecture.targetable);

        if(arcitecture.targetable)
        {
            arcitecture.target = (GameObject)EditorGUILayout.ObjectField("Target", arcitecture.target, typeof(GameObject), allowSceneObjects: true);
        }
        else
        {
            arcitecture.target = null;
            EditorGUILayout.Space(10);
            EditorGUILayout.LabelField("Shot Direction", EditorStyles.boldLabel);
        
            arcitecture.direction = MousePosition.MousePosition.GetMousePosition();
            EditorGUILayout.Vector3Field("Direction", arcitecture.direction);
        }    


        EditorGUILayout.Space(10);
        EditorGUILayout.LabelField("How Many New/Unique Architecture Have This Shot?", EditorStyles.boldLabel);

        arcitecture.architectureCount = EditorGUILayout.IntField("Architecture Count", arcitecture.architectureCount);
        if(arcitecture.architectureCount > 0)
        {
            for (int i = 0; i < arcitecture.architectureCount; i++)
            {
                arcitecture.count.Add(null);
                EditorGUILayout.LabelField("New/Unique Architecture", EditorStyles.boldLabel);
                arcitecture.count[i] = (SpellArchitecture)EditorGUILayout.ObjectField("Architecture", arcitecture.count[i], typeof(SpellArchitecture), allowSceneObjects: true);
            }
        }
        else if(arcitecture.architectureCount < 0)
                arcitecture.count.Clear();

        else
        {
            arcitecture.architectureCount = 0;
        }
        
    }
}
