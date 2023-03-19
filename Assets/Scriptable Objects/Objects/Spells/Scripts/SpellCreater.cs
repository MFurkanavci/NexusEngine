using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCreater : MonoBehaviour
{
    
    GameObject newSpell;

    public Spell spell;

    public SpellCreater(SpellArchitecture spellArch, GameObject caster, GameObject target)
    {
        
        spell =  new Spell(PlayableAgent.CreateInstance("Spells") as Spells);
        spell.spellArch = spellArch;
        spell.SetPlayer(caster);
        spell.SetSpellTarget(target);
        if (spellArch == null)
        {
            Debug.Log("SpellArch is null");
            return;
        }
        if(CheckTargetable() && target == null)
        {
            Debug.Log("Target is null");
            return;
        }
        else if (CheckTargetable() && target != null)
        {
            CreateSpellObject(spell.CheckSpellObjectType());
        }
        else if (!CheckTargetable())
        {
            
        }
        else
        {
        }
    }

    //check if the spell is targetable
    public bool CheckTargetable()
    {
        return spell.spellArch.targetable;
    }

    public void CreateSpell(SpellArcType type)
    {

        switch (type)
        {
            case SpellArcType.Projectile:
                newSpell.AddComponent<ProjectileSpell>();
                break;
            case SpellArcType.Self:
                newSpell.AddComponent<SelfSpell>();
                break;
            case SpellArcType.Target:
                newSpell.AddComponent<TargetSpell>();
                break;
            case SpellArcType.Area:
                newSpell.AddComponent<AreaSpell>();
                break;
        }
    }

    public void CreateSpellObject(SpellObjectType type)
    {
        
        switch (type)
        {
            case SpellObjectType.Sphere:
                newSpell = createSphere(newSpell);
                break;
            case SpellObjectType.Cube:
                newSpell = createCube(newSpell);
                break;
            case SpellObjectType.Capsule:
                newSpell = createCapsule(newSpell);
                break;
            case SpellObjectType.Cylinder:
                newSpell = createCylinder(newSpell);
                break;
            case SpellObjectType.Cone:
                newSpell = createCone(newSpell);
                break;
            case SpellObjectType.Plane:
                newSpell = createPlane(newSpell);
                break;
            case SpellObjectType.Quad:
                newSpell = createQuad(newSpell);
                break;
            case SpellObjectType.Sprite:
                //newSpell = createSprite(newSpell);
                break;
            case SpellObjectType.Unique:
                //newSpell = createUnique(newSpell);
                break;
        }
        newSpell.AddComponent<Spell>();
        newSpell.GetComponent<Spell>().spellArch = spell.spellArch;
        
        CreateSpell(spell.CheckSpellType());
    }

    public GameObject createSphere(GameObject newSpell)
    {
        newSpell = GameObject.CreatePrimitive(PrimitiveType.Sphere);

        return newSpell;
    }

    public GameObject createCube(GameObject newSpell)
    {
        newSpell = GameObject.CreatePrimitive(PrimitiveType.Cube);

        return newSpell;
    }

    public GameObject createCapsule(GameObject newSpell)
    {
        newSpell = GameObject.CreatePrimitive(PrimitiveType.Capsule);

        return newSpell;
    }

    public GameObject createCylinder(GameObject newSpell)
    {
        newSpell = GameObject.CreatePrimitive(PrimitiveType.Cylinder);

        return newSpell;
    }

    public GameObject createCone(GameObject newSpell)
    {
        //newSpell = GameObject.CreatePrimitive(PrimitiveType.Cone);

        return newSpell;
    }

    public GameObject createPlane(GameObject newSpell)
    {
        newSpell = GameObject.CreatePrimitive(PrimitiveType.Plane);

        return newSpell;
    }

    public GameObject createQuad(GameObject newSpell)
    {
        newSpell = GameObject.CreatePrimitive(PrimitiveType.Quad);

        return newSpell;
    }

}
