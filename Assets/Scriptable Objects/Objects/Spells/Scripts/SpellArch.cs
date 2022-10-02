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

public class SpellArchitecture : ScriptableObject
{
    public SpellArcType type;
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
        speed,
        maxspeed,
        wayEffectTime,
        afterEffectTime,
        stayTime,
        returnSpeed,
        maxreturnSpeed;


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
        Return;

    public Effects 
        effect,
        afterEffect,
        stayEffect;

    public Sprite
        way,
        hitArea;

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
        Debug.Log("Projectile");
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

}
