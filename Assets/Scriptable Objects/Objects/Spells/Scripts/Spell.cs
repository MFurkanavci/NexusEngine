using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    //this will be the spell object that will be used to create spells

    public SpellArchitecture spellArch;

    public Spell(SpellArchitecture spellArch)
    {
        this.spellArch = spellArch;
    }

    //check if the spell type
    public SpellArcType CheckSpellType()
    {
        return spellArch.type;
    }

    //check if the spell object type
    public SpellObjectType CheckSpellObjectType()
    {
        return spellArch.spellObjectType;
    }

    //check if the damage type
    public DamageType CheckDamageType()
    {
        return spellArch.damageType;
    }

    //check if delay
    public bool CheckDelay()
    {
        return spellArch.delay;
    }

    //check if cast
    public bool CheckCast()
    {
        return spellArch.cast;
    }

    //check if default hit area
    public bool CheckDefaultHitArea()
    {
        return spellArch.defaultHitArea;
    }

    //check if the spell is a unique shot
    public bool CheckUniqueShot()
    {
        return spellArch.uniqueShot;
    }

    //check if the spell is hit stop
    public bool CheckHitStop()
    {
        return spellArch.hitStop;
    }

    //check if the spell is has sprite area
    public bool CheckSpriteArea()
    {
        return spellArch.spriteHitArea;
    }

    //check if the spell is has a way effect
    public bool CheckWayEffect()
    {
        return spellArch.wayEffect;
    }

    //check if the spell is has a after effect
    public bool CheckAfterEffect()
    {
        return spellArch.afterEffect;
    }

    //check if the spell is has a stay effect
    public bool CheckStayEffect()
    {
        return spellArch.stay;
    }

    //check if the spell is has a return effect
    public bool CheckReturnEffect()
    {
        return spellArch.Return;
    }

    //check if the spell is has a targetable effect
    public bool CheckTargetableEffect()
    {
        return spellArch.targetable;
    }

    //check if the spell is has a unique behaviour
    public bool CheckUniqueBehaviour()
    {
        return spellArch.uniqueBehaviour;
    }

    //check how many missles the spell has
    public int CheckMissleCount()
    {
        return spellArch.missleCount.Count;
    }

    //check the effect of the spell
    public Effects CheckEffect()
    {
        return spellArch.effect;
    }

    //check the after effect of the spell
    public Effects CheckAfterEffectSpell()
    {
        return spellArch.afterEffect;
    }

    //check the stay effect of the spell
    public Effects CheckStayEffectSpell()
    {
        return spellArch.stayEffect;
    }

    //check the way effect of the spell
    public Sprite CheckWayEffectSpell()
    {
        return spellArch.way;
    }

    //check the hit area of the spell
    public Sprite CheckHitAreaSpell()
    {
        return spellArch.hitArea;
    }

    //check the delay time of the spell
    public float CheckDelayTime()
    {
        return spellArch.delayTime;
    }

    //check the cast time of the spell
    public float CheckCastTime()
    {
        return spellArch.castTime;
    }

    //check the lenght of the spell
    public float CheckLenght()
    {
        return spellArch.lenght;
    }

    //check the max lenght of the spell
    public float CheckMaxLenght()
    {
        return spellArch.maxlenght;
    }

    //check the width of the spell
    public float CheckWidth()
    {
        return spellArch.width;
    }

    //check the max width of the spell
    public float CheckMaxWidth()
    {
        return spellArch.maxwidth;
    }

    //check the height of the spell
    public float CheckHeight()
    {
        return spellArch.height;
    }

    //check the max height of the spell
    public float CheckMaxHeight()
    {
        return spellArch.maxheight;
    }

    //check the depth of the spell
    public float CheckDepth()
    {
        return spellArch.depth;
    }

    //check the max depth of the spell
    public float CheckMaxDepth()
    {
        return spellArch.maxdepth;
    }

    //check the speed of the spell
    public float CheckSpeed()
    {
        return spellArch.speed;
    }

    //check the max speed of the spell
    public float CheckMaxSpeed()
    {
        return spellArch.maxspeed;
    }

    public Color CheckColor()
    {
        return spellArch.color;
    }

    //check the way effect time of the spell
    public float CheckWayEffectTime()
    {
        return spellArch.wayEffectTime;
    }

    //check the after effect time of the spell
    public float CheckAfterEffectTime()
    {
        return spellArch.afterEffectTime;
    }

    //check the stay time of the spell
    public float CheckStayTime()
    {
        return spellArch.stayTime;
    }

    //check the return speed of the spell
    public float CheckReturnSpeed()
    {
        return spellArch.returnSpeed;
    }

    //check the max return speed of the spell
    public float CheckMaxReturnSpeed()
    {
        return spellArch.maxreturnSpeed;
    }

    //check the name of the spell
    public string CheckName()
    {
        return spellArch.name;
    }

    //check the id of the spell
    public int CheckID()
    {
        return spellArch.ID;
    }

    //check the description of the spell
    public string CheckDescription()
    {
        return spellArch.description;
    }

    //check the splash art of the spell
    public Sprite CheckSplashArt()
    {
        return spellArch.SplashArt;
    }

    //set the player of the spell
    public void SetPlayer(GameObject player)
    {
        spellArch.player = player;
    }

    //check the playerPosition of the spell
    public GameObject CheckPlayer()
    {
        return spellArch.player;
    }

    //check direction of the spell
    public Vector3 CheckDirection()
    {
        return spellArch.direction;
    }

    //check the position of the spell
    public Vector3 CheckPosition()
    {
        return spellArch.position;
    }

    //check the target of the spell
    public GameObject CheckTarget()
    {
        return spellArch.target;
    }

    public GameObject CheckSpellTarget()
    {
        return spellArch.spellTarget;
    }

    public void SetSpellTarget(GameObject target)
    {
        spellArch.spellTarget = target;
    }

}