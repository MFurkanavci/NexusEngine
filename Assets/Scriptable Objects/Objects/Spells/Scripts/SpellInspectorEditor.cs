using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Spells))]
public class SpellInspectorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        var arcitecture = target as Spells;

        EditorGUILayout.Space(30);
        arcitecture.ID = EditorGUILayout.IntField("ID", arcitecture.ID);
        arcitecture.name = EditorGUILayout.TextField("Name", arcitecture.name);
        arcitecture.SplashArt = (Sprite)EditorGUILayout.ObjectField("Spalsh Art",arcitecture.SplashArt,typeof(Sprite),allowSceneObjects:true);
        arcitecture.description = EditorGUILayout.TextField("Description", arcitecture.description);


        EditorGUILayout.Space(10);
        EditorGUILayout.HelpBox("-----------------------------------------------------------------------------------", MessageType.None,true);
        EditorGUILayout.Space(10);
        arcitecture.cast = EditorGUILayout.Toggle("Has Cast Time ?",arcitecture.cast);

        if (arcitecture.cast)
        {
            arcitecture.castTime = EditorGUILayout.FloatField("Cast time", arcitecture.castTime);
            
        }


        EditorGUILayout.Space(10);
        EditorGUILayout.HelpBox("-----------------------------------------------------------------------------------", MessageType.None);
        EditorGUILayout.Space(10);
        arcitecture.defaultHitArea = EditorGUILayout.Toggle("Default Hit Area", arcitecture.defaultHitArea);

        if (arcitecture.defaultHitArea)
        {
            arcitecture.lenght = EditorGUILayout.FloatField("Lenght", arcitecture.lenght);
            arcitecture.width = EditorGUILayout.FloatField("Width", arcitecture.width);
            arcitecture.speed = EditorGUILayout.FloatField("Speed", arcitecture.speed);
        }


        EditorGUILayout.Space(10);
        EditorGUILayout.HelpBox("-----------------------------------------------------------------------------------", MessageType.None);
        EditorGUILayout.Space(10);
        arcitecture.uniqueShot = EditorGUILayout.Toggle("Unique Shot", arcitecture.uniqueShot);

        if (arcitecture.uniqueShot)
        {
            arcitecture.way = (Sprite)EditorGUILayout.ObjectField("Way", arcitecture.way, typeof(Sprite), allowSceneObjects: true);
            arcitecture.hitStop = EditorGUILayout.Toggle("Hit Stop", arcitecture.hitStop);
        }


        EditorGUILayout.Space(10);
        EditorGUILayout.HelpBox("-----------------------------------------------------------------------------------", MessageType.None);
        EditorGUILayout.Space(10);
        arcitecture.spriteHitArea = EditorGUILayout.Toggle("Sprite Hit Area", arcitecture.spriteHitArea);

        if (arcitecture.spriteHitArea)
        {
            arcitecture.hitArea = (Sprite)EditorGUILayout.ObjectField("Hit Area", arcitecture.hitArea, typeof(Sprite), allowSceneObjects: true);
        }


        EditorGUILayout.Space(10);
        EditorGUILayout.HelpBox("-----------------------------------------------------------------------------------", MessageType.None);
        EditorGUILayout.Space(10);
        arcitecture.wayEffect = EditorGUILayout.Toggle("Way Effect", arcitecture.wayEffect);

        if (arcitecture.wayEffect)
        {
            arcitecture.wayEffectTime = EditorGUILayout.FloatField("Way Effect Time", arcitecture.wayEffectTime);
        }


        EditorGUILayout.Space(10);
        EditorGUILayout.HelpBox("-----------------------------------------------------------------------------------", MessageType.None);
        EditorGUILayout.Space(10);
        arcitecture.stay = EditorGUILayout.Toggle("Stay", arcitecture.stay);

        if (arcitecture.stay)
        {
            arcitecture.stayTime = EditorGUILayout.FloatField("Stay Time", arcitecture.stayTime);
        }


        EditorGUILayout.Space(10);
        EditorGUILayout.HelpBox("-----------------------------------------------------------------------------------", MessageType.None);
        EditorGUILayout.Space(10);
        arcitecture.Return = EditorGUILayout.Toggle("Return", arcitecture.Return);

        if (arcitecture.Return)
        {
            
        }


        EditorGUILayout.Space(10);
        EditorGUILayout.HelpBox("-----------------------------------------------------------------------------------", MessageType.None);
        EditorGUILayout.Space(10);


        arcitecture.direction = EditorGUILayout.Vector3Field("Direction", arcitecture.direction);


        EditorGUILayout.Space(10);
        EditorGUILayout.HelpBox("-----------------------------------------------------------------------------------", MessageType.None);
        EditorGUILayout.Space(10);


        arcitecture.count.Add(null);
        if (arcitecture.count.Count != 0)
        {
            arcitecture.count[0] = (SpellArchitecture)EditorGUILayout.ObjectField("Architecture Count", arcitecture.count[0], typeof(SpellArchitecture), allowSceneObjects: true);
        }
        
        
    }
}
