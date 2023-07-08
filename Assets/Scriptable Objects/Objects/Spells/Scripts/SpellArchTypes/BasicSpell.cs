using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicSpell : MonoBehaviour
{
    public Spell spell;

    [SerializeField] private GameObject spellTarget;
    public DamageCalculations damageCalculations;

    void Start()
    {
        damageCalculations = spell.CheckPlayer().GetComponent<Player>().GetComponent<DamageCalculations>();

        gameObject.GetComponent<MeshRenderer>().enabled = false;
    }

    public void SetSpell(Spell spell)
    {
        this.spell = spell;
        spellTarget = spell.CheckSpellTarget();
        gameObject.tag = "Spell";
        gameObject.name = spell.CheckName();
        gameObject.transform.position = spell.CheckPlayer().transform.position;
        gameObject.transform.localScale = new Vector3(spell.CheckMaxWidth(), spell.CheckMaxHeight(), spell.CheckMaxDepth());
        gameObject.transform.rotation = spell.CheckPlayer().transform.rotation;
        gameObject.AddComponent<Rigidbody>();
        gameObject.GetComponent<Renderer>().material.color = spell.CheckColor();
        gameObject.GetComponent<Rigidbody>().useGravity = false;
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        gameObject.GetComponent<Rigidbody>().freezeRotation = true;
        gameObject.GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        gameObject.GetComponent<Rigidbody>().interpolation = RigidbodyInterpolation.Interpolate;
        gameObject.GetComponent<Rigidbody>().mass = 1f;
        gameObject.GetComponent<Collider>().isTrigger = true;

        gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Mob"))
        {
            var agent = spell.CheckPlayer().GetComponent<Player>().agent;
            float damage = agent.damageCalculations.DealDamage(other.gameObject, damageCalculations.damageTypeandValue(spell.getDamageType(spell.spellArch.damageType), agent.damage_Physical));
            spell.CheckSpellTarget().GetComponent<Mobs>().agent.hitPoint -= damage;
            
            Destroy(gameObject);
        }
    }

    public void FixedUpdate()
    {
        if (spellTarget != null)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, spellTarget.transform.position, spell.CheckMaxSpeed() * Time.fixedDeltaTime);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public Vector3 GetSpellTarget()
    {
        if (spellTarget != null)
        {
            return spellTarget.transform.position - transform.position;
        }
        else
        {
            return Vector3.zero;
        }
    }
}
