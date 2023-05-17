using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GlobalCooldown;

public enum SpellArcType
{
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

    public int architectureCount = 1;




    public List<SpellArchitecture> 
        count = new List<SpellArchitecture>(), 
        missleCount;

    public float
        delayTime,
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

    public void SpellTypeSelecter()
    {
        switch (type)
        {
            case SpellArcType.Projectile:
                ProjectileSpawn();
                break;
            case SpellArcType.Self:
                SelfSpawn();
                break;
            case SpellArcType.Target:
                TargetSpawn();
                break;
            case SpellArcType.Area:
                AreaSpawn();
                break;
        }
    }
    public void ProjectileSpawn()
    {  
        
    }

    public void SelfSpawn()
    {
        Debug.Log("Self");
    }

    public void TargetSpawn()
    {
        Debug.Log("Target");
    }

    public void AreaSpawn()
    {
        Debug.Log("Area");
    }

    public void CopyFrom(SpellArchitecture source)
    {
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
