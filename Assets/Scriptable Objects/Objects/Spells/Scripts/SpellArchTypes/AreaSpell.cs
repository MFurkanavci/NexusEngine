using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaSpell : MonoBehaviour
{
    public Spell spell;
    public GameObject spellTarget;
    public DamageCalculations damageCalculations;

    public bool tick = true;

    private void Start()
    {
        damageCalculations = spell.CheckPlayer().GetComponent<Player>().GetComponent<DamageCalculations>();
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

        StartCoroutine(DestroySpell());
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Mob") && tick)
        {
            StartCoroutine(DamageTick());
            float damage = 50;
            damage = damageCalculations.DealDamage(other.gameObject, damageCalculations.damageTypeandValue(spell.getDamageType(spell.spellArch.damageType), damage));
            other.gameObject.GetComponent<Mobs>().agent.hitPointCurrent -= damage;
        }
    }

    IEnumerator DestroySpell()
    {
        yield return new WaitForSeconds(spell.CheckStayTime());
        Destroy(gameObject);
    }

    IEnumerator DamageTick()
    {   
        tick = false;
        yield return new WaitForSeconds(.5f);
        tick = true;
    }
}
