using UnityEngine;

public class StageChangerInteraction : MonoBehaviour
{
    private MainStateMachine stateMachine;

    private void Start()
    {
        stateMachine = ServiceLocatorGame.serviceLocatorGame.GetGameService<MainStateMachine>();
        StageHandler.OnStartGameStageEvent += StartGameStage;
        StageHandler.OnStartDialogueStageEvent += StartDialogueStage;
        StageHandler.OnStartMenuStageEvent += StartMenuStage;
        StageHandler.OnStartGameOverStageEvent += StartGameOverStage;
    }

    private void StartGameStage()
    {
        stateMachine.SetCurrentStage(stateMachine.stageMap[typeof(GameStage)]);
    }

    private void StartDialogueStage()
    {
        stateMachine.SetCurrentStage(stateMachine.stageMap[typeof(DialogueStage)]);
    }

    private void StartMenuStage()
    {
        stateMachine.SetCurrentStage(stateMachine.stageMap[typeof(MenuStage)]);
    }

    private void StartGameOverStage()
    {
        stateMachine.SetCurrentStage(stateMachine.stageMap[typeof(GameOverStage)]);
    }

    private void OnDestroy()
    {
        StageHandler.OnStartGameStageEvent -= StartGameStage;
        StageHandler.OnStartDialogueStageEvent -= StartDialogueStage;
        StageHandler.OnStartMenuStageEvent -= StartMenuStage;
        StageHandler.OnStartGameOverStageEvent -= StartGameOverStage;
    }

}
