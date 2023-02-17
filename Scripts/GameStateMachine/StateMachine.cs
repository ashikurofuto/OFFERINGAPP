using System.Collections.Generic;

public class StateMachine : IGameService
{
    public Dictionary<string, State> states;
    private State currentState;
    public IMenuOpeneble menuOpen;

    public StateMachine()
    {
        states = new Dictionary<string, State>();
        
    }

    public void InitializeStates()
    {
        AddState(new GameState());
        AddState(new PausedState());
        AddState(new MenuState());
        AddState(new GameOverState());
    }

    public void SetState(State newState)
    {
        currentState?.Exit();
        currentState = newState;
        currentState.Enter();
    }

    public State GetActiveState()
    {
        if (currentState == null)
        {
            throw new System.Exception("current state in empty");
        }
        return currentState;
    }


    public void AddState(State newState)
    {
        string name = newState.GetType().Name;
        if (states.ContainsKey(name))
        {
            throw new System.Exception($"state {name} cant be added second time");
        }
        states.Add(name, newState);
    }

}


