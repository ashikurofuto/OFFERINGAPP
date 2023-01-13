using System;

public static class StageHandler
{
    public static event Action OnStartGameStageEvent;
    public static event Action OnStartDialogueStageEvent;
    public static event Action OnStartMenuStageEvent;
    public static event Action OnStartGameOverStageEvent;

    public static void StartGameStage()
    {
        OnStartGameStageEvent?.Invoke();
    }
    public static void StartDialogueStage()
    {
        OnStartDialogueStageEvent?.Invoke();
    }
    public static void StartMenuStage()
    {
        OnStartMenuStageEvent?.Invoke();
    }
    public static void StartGameOverStage()
    {
        OnStartGameOverStageEvent?.Invoke();
    }


}