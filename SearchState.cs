using System.Collections;
using System.Collections.Generic;
using UnityEngine;

private float searchTimer;
private float moveTimer;
public class SearchState :BaseState
{
	public override void Enter()
	{
		enemy.Agent.SetDestination(enemy.LastKnowPos);
	}
	public override void Perform()
	{
		if(enemy.CanSeePlayer())
			statemachine.ChangeState(new AttackState());
		if(enemy.Agent.remainingDistance < enemy.stoppingDistance)
		{
			searchTimer += Time.deltaTime;
			moveTimer += Time.deltaTime;
			if(moveTimer>Random.range(3 , 5))
			{
				enemy.Agent.SetDestination(enemy.transform.position + ( Random.insideUnitSphere * 10));
				moveTimer = 0;
			}
			if(seaRCHtIMER >10)
			{
				statemachine.ChangeState(new PatrolState());
			}
		}
	}
	public override void Exit()
	{
	}

}