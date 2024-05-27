publice abstract class BaseState{
	//instance of enemy class
	public Enemy enemy;
	//instance of statemachine class
	public StateMachine statemachine;
	public abstract void Enter();
	public abstract void Perform();
	public abstract void Exit();
}	