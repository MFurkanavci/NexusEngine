using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deneme : MonoBehaviour
{
    public Spells test;


    public void Awake()
    {
        print(test.castTime);
        print(test.stay.ToString());
        print(test.stayTime);
        print(test.cast.ToString());
    }
}
