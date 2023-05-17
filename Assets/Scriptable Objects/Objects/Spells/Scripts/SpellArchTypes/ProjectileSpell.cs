using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpell : MonoBehaviour
{
    public Spell spell;

    public GameObject spellTarget;

    public GameObject fireBall;

    public DamageCalculations damageCalculations;

    public ProjectileSpell()
    { 
    }

    private void Start() {
        
        fireBall = spell.CheckPlayer().GetComponent<Player>().fireBall;
        damageCalculations = spell.CheckPlayer().GetComponent<Player>().GetComponent<DamageCalculations>();
        
        var fire = Instantiate(fireBall, gameObject.transform.position, gameObject.transform.rotation);
        fire.transform.parent = gameObject.transform;
        gameObject.GetComponent<MeshRenderer>().enabled = false;
    }

    public void SetSpell(Spell spell)
    {
        this.spell = spell;
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
        
        gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
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
            float damage = 50;
            print("Hit");
            //deal damage cs is taking gameobject and not spelltarget
            
            print("Damage: " + damage);
            
            Destroy(gameObject);
            
        }
    }

    public void FixedUpdate()
    {
        if(spellTarget != null)
        {
            gameObject.transform.Translate(GetSpellTarget() * Time.deltaTime * spell.CheckSpeed());
        }
    }

    public Vector3 GetSpellTarget()
    {
        return (spellTarget.transform.position - gameObject.transform.position).normalized;
    }
}
