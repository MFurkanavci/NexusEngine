using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpell : MonoBehaviour
{
    public Spell spell;
    public GameObject spellTarget;
    public DamageCalculations damageCalculations;

    private void Start()
    {
        damageCalculations = spell.CheckPlayer().GetComponent<Player>().GetComponent<DamageCalculations>();
        GameObject model = spell.spellArch.model;
        if (model != null)
        {
            var fire = Instantiate(model, transform.position, transform.rotation, transform);
            GetComponent<MeshRenderer>().enabled = false;
        }
        else
        {
            GetComponent<Renderer>().material.color = spell.CheckColor();
        }
    }

    public void SetSpell(Spell spell)
    {
        this.spell = spell;
        spellTarget = spell.CheckSpellTarget();
        gameObject.layer = 13;
        gameObject.tag = "Spell";
        gameObject.name = spell.CheckName();
        transform.position = spell.CheckPlayer().transform.localPosition;
        transform.localScale = new Vector3(spell.CheckMaxWidth(), spell.CheckMaxHeight(), spell.CheckMaxDepth());
        transform.rotation = transform.rotation;
        var rb = gameObject.AddComponent<Rigidbody>();
        var rd = GetComponent<Renderer>();
        var rbConstraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        var rbInterpolation = RigidbodyInterpolation.Interpolate;
        rb.useGravity = false;
        rb.isKinematic = true;
        rb.freezeRotation = true;
        rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        rb.interpolation = rbInterpolation;
        rb.mass = 1f;
        GetComponent<Collider>().isTrigger = true;
        rb.constraints = rbConstraints;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Mob"))
        {
            float damage = 50;
            damage = damageCalculations.DealDamage(other.gameObject, damageCalculations.damageTypeandValue(spell.getDamageType(spell.spellArch.damageType), damage));
            other.gameObject.GetComponent<Mobs>().agent.hitPoint -= damage;
            Destroy(gameObject);
        }
    }

    public void FixedUpdate()
    {
        if(spellTarget != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, spellTarget.transform.position, spell.spellArch.maxspeed);
        }
        else
        {
            //set direction to spell.checkdirection
            transform.position += spell.CheckDirection() * spell.spellArch.maxspeed;
            spell.SetLenght(spell.CheckLenght() + spell.spellArch.maxspeed);
            if (spell.CheckLenght() >= spell.CheckMaxLenght())
            {
                Destroy(gameObject);
                spell.SetLenght(0);
            }
        }
    }
}
