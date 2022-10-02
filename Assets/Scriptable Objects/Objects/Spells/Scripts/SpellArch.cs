using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public SpellGameObject spellGameObject;
    public int ID;
    public string Name;
    public Sprite SplashArt;
    [TextArea(15, 20)]
    public string description;

    public int architectureCount;




    public List<SpellArchitecture> 
        count, 
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
    public void ProjectileSpawn()
    {
        GameObject spell = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        spell.transform.position = new Vector3(0, 2, 0);
        spell.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        spell.layer = 13;
        spell.AddComponent<Rigidbody>();
        spell.GetComponent<Rigidbody>().useGravity = false;
        spell.GetComponent<Rigidbody>().AddForce(MousePosition.MousePosition.GetMousePosition() * speed);
    }
}
