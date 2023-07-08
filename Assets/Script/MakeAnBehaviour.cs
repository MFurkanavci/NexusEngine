using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MakeAnBehaviour : BasicBehaviour
{
    public MakeAnBehaviour(PlayableAgent playableAgent, notPlayableAgent notPlayableAgent, AgentObject agent) : base(playableAgent, notPlayableAgent, agent)
    {
        
    }

    public AgentObject GetAgent()
    {
        return agent;
    }

    public override void MakeAnAttack(GameObject player, GameObject enemy, CooldownCalculator cooldownCalculator)
    {
        if (agent.activeSpells[0] == null)
            return;
        if (!cooldownCalculator.IsAbilityOnCooldown(agent.activeSpells[0]))
        {
            player.GetComponent<SpellCreater>().CreateSpell(agent.activeSpells[0], player, enemy);
            cooldownCalculator.StartCooldown(agent.activeSpells[0]);
            player.GetComponent<Player>().spellBarManager.SpellCasted(0);
        }        
    }

    public override void MakeAnAbility(GameObject player, GameObject enemy, SpellArchitecture spell, CooldownCalculator cooldownCalculator, int spellIndex)
    {
        SpellCreater spellCreater = player.GetComponent<SpellCreater>();
        Player playerComponent = player.GetComponent<Player>();
        SpellBarManager spellBarManager = playerComponent.spellBarManager;

        if (cooldownCalculator.IsAbilityOnCooldown(spell))
            return;

        if (agent.manaPointCurrent < spell.manaCost)
            return;

        if (spell.targetable)
        {
            if (enemy == null)
                return;

            if (Vector3.Distance(player.transform.position, enemy.transform.position) > spell.maxlenght)
                return;
        }

        player.GetComponent<SpellCreater>().CreateSpell(spell, player, enemy);

        cooldownCalculator.StartCooldown(spell);
        agent.manaPointCurrent -= spell.manaCost;
        spellBarManager.SpellCasted(spellIndex);
    }

    public override void MakeADesicion()
    {
        //Debug.Log("Decision");
    }

}
