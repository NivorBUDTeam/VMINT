using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public BaseState activeState;

    public void Initialise()
    {
        ChangeState(new PatrolState());
    }

    void Start()
    {

    }


    void Update()
    {
        activeState?.Perform();
    }

    public void ChangeState(BaseState newState)
    {
        activeState?.Exit();
        activeState = newState;
        if (activeState != null)
        {
            activeState.stateMachine = this;
            activeState.enemy = GetComponent<Enemy>();
            activeState.Enter();
        }
    }
}
