using UnityEngine;
using static GlobalCooldown.GlobalCooldown;
namespace Engage
{
    public class Engage : MonoBehaviour
    {

        //check if the player is in range of the enemy
        public bool IsInRange(GameObject player, GameObject enemy, float range)
        {
            if (Vector3.Distance(player.transform.position, enemy.transform.position) <= range)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //check if the player is in front of the enemy
        public bool IsInFront(GameObject player, GameObject enemy)
        {
            Vector3 direction = player.transform.position - enemy.transform.position;
            float angle = Vector3.Angle(direction, enemy.transform.forward);

            if (angle < 90f)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //check if the player is behind the enemy
        public bool IsBehind(GameObject player, GameObject enemy)
        {
            Vector3 direction = player.transform.position - enemy.transform.position;
            float angle = Vector3.Angle(direction, enemy.transform.forward);

            if (angle > 90f)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //trigger the attack every attackSpeed seconds
        public bool IsAttackSpeedReady(float attackSpeed)
        {
            if (!globalCooldownActive)
            {
                globalCooldownActive = true;
                return true;
            }
            else
            {
                return false;
            }
        }

        //set global cooldown to attack speed and reset the global cooldown timer
        public void SetGlobalCooldown(float attackSpeed)
        {
            GlobalCooldownSet(attackSpeed);
        }

        //trigger the attack to selected enemy
        public void Attack(GameObject player, GameObject enemy, float range ,  float attackSpeed, float attackDamage)
        {
            if (IsInRange(player, enemy, range) && IsInFront(player, enemy) && IsAttackSpeedReady(attackSpeed))
            {
                SetGlobalCooldown(attackSpeed);
                Debug.Log("Attack " + "Dummy" + "for " + attackDamage + "damage ");
            }
        }
    }
}