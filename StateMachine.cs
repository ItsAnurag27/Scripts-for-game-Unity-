using System.collection;
using System.collection.Generic;
using UnityEngine;
public class StateMachine, MonoBehavior
{
	public BaseState activeState;
	public void  Initialise()
	{
		ChangeState(new PatrolState());
	}
	
	
	void start()
	{
		
	}
	void update()
	{
		if(activeState !=null)
		{
			activeState.Perform();
		}
		
	}
	
	public void ChangeState(BaseState newState)
	{
		if(activeState !=null)
		{
			activeState.Exit();
		}
		if(activeState !=null)
		{
			//setup new state.
			activeState.stateMachine=this;
			activeState.enemy = GetComponent<Enemy>();
			activeState.Enter();
		}
	}
}