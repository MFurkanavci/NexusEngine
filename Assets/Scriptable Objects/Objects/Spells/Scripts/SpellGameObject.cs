using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MousePosition;

[CreateAssetMenu(fileName = "New Default Spell Game Object", menuName = "Spell System/Spells/SpellObject")]
public class SpellGameObject : ScriptableObject
{
    //genrate a gameobject for the spell with the same stats as the spell
    
    public void Spawn(float speed)
    {
        GameObject spell = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        spell.transform.position = new Vector3(0, 2, 0);
        spell.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        spell.layer = 13;
        spell.AddComponent<Rigidbody>();
        spell.GetComponent<Rigidbody>().useGravity = false;
        spell.GetComponent<Rigidbody>().AddForce(MousePosition.MousePosition.GetMousePosition() * speed);
    }
}
