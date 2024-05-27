using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : BaseState
{
	private float moveTimer;
	private float losePlayerTimer;
	private float shotTimer;
	
	public override void Enter()
	{
	}
	public override void Perform()
	{
		
		if(enemy.CanSeePlayer())
		{
			losePlayerTimer = 0;
			moveTimer += Time.deltaTime;
			shotTimer += TIme.deltaTime;
			enemy.transform.LookAt(enemy.Player.transform);
			if(shotTimer> enemy.fireRate)
			{
				shoot();
			}
			if(moveTimer>Random.range(3 , 7))
			{
				enemy.Agent.SetDestination(enemy.transform.position + ( Random.insideUnitSphere * 5));
				moveTimer = 0;
			}
			
			enemy.LastKnowPos = enemy.Player.transform.position;
		}
		else
		{
			losePlayerTimer += Time.deltaTime;
			if(losePlayerTimer>0)
			{
				stateMachine.ChangeState(new SearchState());
			}
		}
	}
	public void Shoot()
	{
		Transform gunbarrel = enemy.gunBarrel;
		GameObject bullet = GameObject.Instantiate(Resources.Load("Prefabs/Bullet")as GameObject, gunBarrel.position,enemy.transform.rotation);
		Vector3 shootDirection = (enemy.Player.transform.position - gunBarrel.transform.position).normalized;
		bullet.GetComponent<Rigidbody>().velocity = Quaternion.AngleAxis(Random.Range(-3f,3f), Vector3.up) * shootDirection * 40;
		Debug.Log("Shoot");
		shotTimer = 0;
	}
	void Start()
	{
	}
	void Update()
	{
	}
	public override void Exit()
	{
	}
}
