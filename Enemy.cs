using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : Monobehaviour
{
	private StateMachine stateMachine;
	private NavMeshAgent agent;
	private GameObject player;
	private Vector3 lastKnowPos;
	
	public NavMeshAgent Agent {get =>agent;}
	
	public GameObject Player{get => player;}
	
	public Vector3 LastKnowPos{get =>lastKnowPos; set => lastKnowPos=value;}
	
	public Path path;
	[Header("Sight Values")]
	
	public float sightDistance = 20f;
	public float fieldOfView = 85f;
	public float eyeHeight;
	[Header("Weapon Values")]
	public transform gunBarrel;
	[Range(0.1f, 10f)]
	public float fireRate; 
	[SerializeField]
	private string currentState;
	void start()
	
	{
		stateMachine = GetComponent<StateMachine>();
		agent =GetComponent<NavMeshAgent>();
		stateMachine.Initialise();
		player = GameObject.FindGameObjectWithTag("Player");
		
	}
	
	
	
	
	void update()
	{
		CanSeePlayer();
		currentState = stateMachine.activeState.ToString(); 
	
	}
	public bool CanSeePlayer()
	{
		if(player !=null)
		{
			if (Vector3.Distance(transform.position,player.transform.powsition)<sightDistance)
			{
				Vector3 targetDirection = player.transform.position - transform.position -(Vector3.up *eyeHeight);
				float angleToPlayer = Vector3.Angle(targetDirection, transform.forward);
				if(angleToPlayer >= fieldOfView && angleToPlayer <= fieldOfView)
				{
					Ray ray = new Ray(transform.position+ (Vector3.up * eyeHeight), targetDirection);
					RaycastHit hitinfo = new RaycastHit();
					if(Physics.Raycast(ray,out hitInfo, sightDistance))
					{
						if(hitInfo.transform.gameObject == player)
						{	
							Debug.DrawRay(ray.origin , ray.direction *sightDistance);
							return true;
						}
					}
				
				}
			}
		}
		
	}
	return false;
	
	
}
