using UnityEngine;
using System.Collections.Generic;

public class PrimaryAndHitPointCurrentRegeneration : MonoBehaviour
{
    AgentObject agent;

    private void Start()
    {
        if (TryGetComponent<Player>(out var player))
        {
        agent = player.agent;
        }
        else if (TryGetComponent<Mobs>(out var mobs))
        {
        agent = mobs.agent;
        }

        // Start the coroutine to check secondary points
        StartCoroutine(CheckSecondaryPoints());
    }

    private IEnumerator<PrimaryAndHitPointCurrentRegeneration> CheckSecondaryPoints()
    {
        while (true)
        {
            yield return null;

            if (agent.maxManaPoint != 0)
            {
                RegenerateResource(ref agent.manaPointCurrent, agent.maxManaPoint, agent.regen_manaPoint);
            }
            else if (agent.maxEnergyPoint != 0)
            {
                RegenerateResource(ref agent.energyPointCurrent, agent.maxEnergyPoint, agent.regen_energyPoint);
            }
            else if (agent.maxWildPoint != 0)
            {
                RegenerateResource(ref agent.wildPointCurrent, agent.maxWildPoint, agent.regen_wildPoint);
            }
            
            if (agent.hitPointCurrent != 0)
                RegenerateResource(ref agent.hitPointCurrent, agent.maxHitPoint, agent.regen_hitPoint);
        }
    }

    private void RegenerateResource(ref float resource, float maxResource, float regenerationRate)
    {
        if (resource < maxResource)
        {
            resource += regenerationRate * Time.deltaTime;
            resource = Mathf.Min(resource, maxResource);
        }
    }
}
