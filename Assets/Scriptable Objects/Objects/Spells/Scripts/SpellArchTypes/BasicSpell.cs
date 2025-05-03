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
        gameObject.layer = 13;
        gameObject.tag = "Spell";

        gameObject.name = spell.CheckName();


        if(spell.CheckTargetable())
            transform.position = spell.CheckDirection();

        if(spell.CheckDefaultHitArea())
        {
            transform.localScale = new Vector3(spell.CheckMaxWidth(), spell.CheckMaxHeight(), spell.CheckMaxDepth());
        }
        else if(spell.CheckSpriteArea())
        {
            Sprite sprite = spell.CheckSprite();

            transform.localScale = new Vector3(sprite.texture.width, sprite.texture.height,sprite.texture.width).normalized;

            transform.rotation = Quaternion.Euler(90, 0, 0);

            DestroyImmediate(GetComponent<MeshFilter>());
            DestroyImmediate(GetComponent<MeshRenderer>());

            gameObject.AddComponent<SpriteRenderer>();
            gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
            
        }
        else if(spell.CheckSpellModel())
        {
            GameObject model = spell.spellArch.model;
            var fire = Instantiate(model, transform.position, transform.rotation, transform);
            GetComponent<MeshRenderer>().enabled = false;
        }

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
            var agent = spell.CheckPlayer().GetComponent<Player>().agent;
            float damage = agent.damageCalculations.DealDamage(other.gameObject, damageCalculations.damageTypeandValue(spell.getDamageType(spell.spellArch.damageType), agent.damage_Physical));
            spell.CheckSpellTarget().GetComponent<Mobs>().agent.hitPointCurrent -= damage;

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
