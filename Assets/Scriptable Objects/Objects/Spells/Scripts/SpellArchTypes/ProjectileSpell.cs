using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpell : MonoBehaviour
{
    public Spell spell;

    public GameObject spellTarget;

    public ProjectileSpell()
    {
    }
    public void Start() 
    { 
        
        spell = gameObject.GetComponent<Spell>();
        spellTarget = spell.CheckSpellTarget();
        gameObject.layer = 13;
        gameObject.tag = "Spell";
        gameObject.name = spell.CheckName();
        gameObject.transform.position = spell.CheckPlayer().transform.localPosition;
        gameObject.transform.localScale = new Vector3(spell.CheckWidth(), spell.CheckHeight(), spell.CheckDepth());
        gameObject.transform.rotation = transform.rotation;
        gameObject.AddComponent<Rigidbody>();
        gameObject.GetComponent<Renderer>().material.color = spell.CheckColor();
        gameObject.GetComponent<Rigidbody>().useGravity = false;
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        gameObject.GetComponent<Rigidbody>().freezeRotation = true;
        gameObject.GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        gameObject.GetComponent<Rigidbody>().interpolation = RigidbodyInterpolation.Interpolate;
        gameObject.GetComponent<Rigidbody>().mass = 1f;
        gameObject.GetComponent<Collider>().isTrigger = true;

        CastSpell(spell.CheckSpellTarget());
    }

    //cast the spell to the target
    public void CastSpell(GameObject target)
    {
        if (spell.CheckTarget())
        {
            gameObject.transform.LookAt(target.transform);
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
        else
        {
            return;
        }
    }

    //check if the spell hit the target
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Mob")
        {
            Destroy(gameObject);
            float damage = 0;
            damage += spell.CheckPlayer().GetComponent<Player>().agent.damageCalculations.DealDamage(spell.CheckPlayer().GetComponent<Player>().agent.damageCalculations.damageTypeandValue(spell.CheckPlayer().GetComponent<Player>().agent.damageCalculations.GetDamageType(), spell.CheckPlayer().GetComponent<Player>().agent.damage_Physical));

            other.gameObject.GetComponent<Mobs>().agent.damageCalculations.RecieveDamage(damage, spell.CheckPlayer().GetComponent<Player>().agent.damageCalculations.GetDamageType());
        }
    }

    public void FixedUpdate()
    {
        if(spellTarget != null)
        {
            gameObject.transform.LookAt(spellTarget.transform);
            gameObject.transform.Translate(spellTarget.transform.localPosition * spell.CheckSpeed() * Time.deltaTime);
        }
    }
}
