using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCreater : MonoBehaviour
{
    
    GameObject newSpell;

    public Spell spell;

    public SpellCreater()
    {
        spell = new Spell();
    }

    public void CreateSpell(SpellArchitecture spellArch, GameObject caster, GameObject target)
    {
        spell.spellArch = spellArch as Spells;
        spell.SetPlayer(caster);
        spell.SetSpellTarget(target);
        bool targetable = spell.CheckTargetable();
        if (spellArch == null)
        {
            Debug.Log("SpellArch is null");
            return;
        }
        if(targetable && target == null)
        {
            Debug.Log("Target is null");
            return;
        }
        else if (targetable && target != null)
        {
            CreateSpellObject(spellArch.spellObjectType);
        }
        else if (!targetable)
        {
            spell.SetDirection(MousePosition.MousePosition.GetMousePosition() - caster.transform.position);
            CreateSpellObject(spellArch.spellObjectType);
        }
        else
        {
            Debug.Log("Target is not targetable");
        }
    }

    public void AddSpellScript(SpellArcType type)
    {

        switch (type)
        {
            case SpellArcType.Basic:
                newSpell.AddComponent<BasicSpell>();
                newSpell.GetComponent<BasicSpell>().SetSpell(spell);
                break;
            case SpellArcType.Projectile:
                newSpell.AddComponent<ProjectileSpell>();
                newSpell.GetComponent<ProjectileSpell>().SetSpell(spell);
                break;
            case SpellArcType.Self:
                newSpell.AddComponent<SelfSpell>();
                newSpell.GetComponent<SelfSpell>().SetSpell(spell);
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
        
        AddSpellScript(spell.CheckSpellType());
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
