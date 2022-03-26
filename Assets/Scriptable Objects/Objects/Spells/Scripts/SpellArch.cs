using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SpellArchitecture : ScriptableObject
{

    public int ID;
    public string Name;
    public Sprite SplashArt;
    [TextArea(15, 20)]
    public string description;


    public List<SpellArchitecture> 
        count, 
        missleCount;

    public float
        delay,
        castTime,
        lenght,
        width,
        speed,
        wayEffectTime,
        afterEffectTime,
        stayTime;


    public bool
        cast,
        defaultHitArea,
        uniqueShot,
        spriteHitArea,
        uniqueBehaviour,
        hitStop,
        wayEffect,
        stay,
        Return;

    public Effects 
        effect,
        afterEffect,
        stayEffect;

    public Sprite
        way,
        hitArea;

    public Vector3
        direction;

}
