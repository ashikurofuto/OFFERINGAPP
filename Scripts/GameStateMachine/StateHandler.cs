using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public static class StateHandler
{
    private const string GAME_STATE = "GameState";
    private const string PAUSED_STATE = "PausedState";
    private const string MENU_STATE = "MenuState";
    private const string GAME_OVER_STATE = "GameOverState";

    private static StateMachine stateMachine = new StateMachine();
    private static Stack<State> statesHistory = new Stack<State>();

    public static IMenuOpeneble MenuOpeneble { get; set; }
    public static IGameOverStartInteracion gameOverInteraction { get; set; }
    public static IGameOverPlayInteracion gameOverStartInteracion { get; set; }

    public static void Init()
    {
        stateMachine.InitializeStates();
    }

    public static void StartGameState()
    {
        stateMachine.SetState(stateMachine.states[GAME_STATE]);
        AddStateHistory(stateMachine.states[GAME_STATE]);
    }
    public static void StartPausedState()
    {
        stateMachine.SetState(stateMachine.states[PAUSED_STATE]);
        AddStateHistory(stateMachine.states[PAUSED_STATE]);
    }
    public static void StartMenuState()
    {
        stateMachine.SetState(stateMachine.states[MENU_STATE]);
        AddStateHistory(stateMachine.states[MENU_STATE]);
    }
    public static void StartGameOverState()
    {
        stateMachine.SetState(stateMachine.states[GAME_OVER_STATE]);
        AddStateHistory(stateMachine.states[GAME_OVER_STATE]);
    }

    private static void AddStateHistory(State state)
    {
        if (statesHistory.Contains(state))
        {
            throw new System.Exception($"this state {state} cant be added second time");
        }
        statesHistory.Push(state);
    }

    public static void BackToPreviousState()
    { 
        if (statesHistory.Peek() == stateMachine.states[GAME_STATE])
        {
            return;
        }
        statesHistory.Pop();
        Debug.Log($"history count {statesHistory.Count} ");
        var stateName = statesHistory.Peek().ToString();
        stateMachine.SetState(stateMachine.states[stateName]);        
    }

}


