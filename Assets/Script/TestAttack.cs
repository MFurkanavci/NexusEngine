using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GlobalCooldown.GlobalCooldown;

public class TestAttack : MonoBehaviour
{
    public GameObject player;

    public EnemySelecter enemySelecter;

    public Engage.Engage engage;
    public float range = 2f;
    public float attackSpeed = 1f;
    public float attackDamage = 10f;
    void Update()
    {
        if (enemySelecter.IsEnemySelected())
        {
            GlobalCooldownUpdate();
            engage.Attack(player, enemySelecter.GetSelectedEnemy(), range, attackSpeed, attackDamage);
        }
    }

}
