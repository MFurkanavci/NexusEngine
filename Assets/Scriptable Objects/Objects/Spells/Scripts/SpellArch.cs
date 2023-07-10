using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GlobalCooldown;

public enum SpellArcType
{
    Basic,
    Projectile,
    Self,
    Target,
    Area
}

public enum SpellObjectType
{
    Sphere,
    Cube,
    Capsule,
    Cylinder,
    Cone,
    Plane,
    Quad,
    Sprite,
    Unique
}

public enum DamageType
{
    Physical,
    Magical,
    True
}

public class SpellArchitecture : ScriptableObject
{
    public SpellArcType type;
    public DamageType damageType;

    public SpellObjectType spellObjectType;
    public int ID;
    public string Name;
    public Sprite SplashArt;
    [TextArea(15, 20)]
    public string description;

    public GameObject model;

    public int architectureCount = 1;

    public float manaCost;




    public List<SpellArchitecture> 
        count = new List<SpellArchitecture>(), 
        missleCount;

    public float
        delayTime,
        CD,
        maxCooldown,
        castTime,
        lenght,
        maxlenght,
        width,
        maxwidth,
        height,
        maxheight,
        depth,
        maxdepth,
        speed,
        maxspeed,
        wayEffectTime,
        afterEffectTime,
        stayTime,
        returnSpeed,
        maxreturnSpeed;

    public Color color;


    public bool
        cast,
        cooldown,
        active = true,
        delay,
        defaultHitArea,
        uniqueShot,
        spriteHitArea,
        uniqueBehaviour,
        hitStop,
        wayEffect,
        stay,
        Return,
        targetable,
        havecolor;

    public Effects 
        effect,
        afterEffect,
        stayEffect;

    public Sprite
        way,
        hitArea;

    public GameObject

    player, 
    target,
    spellTarget;

    public Vector3
        direction,
        position;


    public void CopyFrom(SpellArchitecture source)
    {
        if (source == null)
            return;
        foreach (var item in source.GetType().GetFields())
        {
            this.GetType().GetField(item.Name).SetValue(this, item.GetValue(source));
        }

        foreach (var item in source.GetType().GetProperties())
        {
            this.GetType().GetProperty(item.Name).SetValue(this, item.GetValue(source));
        }
    }


}
