using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public TMP_Text hp_Base;
    public TMP_Text hp_Current;

    public Scrollbar healthBar;

    public PlayableAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.size = 1 / (agent.hitPoint / agent.hitPointCurrent);
        hp_Base.text = agent.hitPointCurrent + "/" + agent.hitPoint;
    }
}
