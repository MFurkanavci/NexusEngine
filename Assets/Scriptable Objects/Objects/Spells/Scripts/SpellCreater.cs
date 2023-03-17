using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCreater : MonoBehaviour
{
    GameObject newSpell;

    public SpellArchitecture spell;

    public Spell spellchecker;

    public SpellCreater(SpellArchitecture spell)
    {
        this.spell = spell;
        spellchecker = new Spell(spell);
    }

    void setValues(GameObject newSpell)
    {
        
        newSpell.AddComponent<Spell>();
        newSpell.GetComponent<Spell>().spellArch = spell;
        Vector3 scale = new Vector3(spell.width, spell.height, spell.depth);
        Vector3 position = newSpell.GetComponent<Spell>().CheckPlayer().transform.localPosition;
        Vector3 direction = newSpell.GetComponent<Spell>().CheckDirection();
        Color color = new Color(spell.color.r, spell.color.g, spell.color.b, spell.color.a);
        float speed = spell.speed;



        newSpell.AddComponent<Rigidbody>();

        newSpell.transform.localScale = scale;
        newSpell.transform.localPosition = position;
        newSpell.GetComponent<Renderer>().material.color = color;
        newSpell.GetComponent<Rigidbody>().useGravity = false;
        newSpell.GetComponent<Rigidbody>().velocity = direction * speed;

    }

    public void createaNewSpell()
    {
        Debug.Log("Spell Created");
        newSpell = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        newSpell.layer = 13;
        setValues(newSpell);
    }
}
