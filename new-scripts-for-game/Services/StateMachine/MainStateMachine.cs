using System;
using System.Collections.Generic;

public class MainStateMachine : IGameService
{
    public Dictionary<Type, IStageble> stageMap;
    private IStageble currentStage;
    private AudioService audioService;
    private SaveSystem saveSystem;
    public IMenuUsable MenuUsable { get; set; }
    public IPlayerDeathWrapper playerDeath { get; set; }
    public IDialogueItem DialogueItem { get; set; }

    public MainStateMachine()
    {
        InitializeStageServices();
        InitializeStages();
    }

    public void SetCurrentStage(IStageble stage)
    {
        currentStage?.ExitState();
        currentStage = stage;
        currentStage.EnterState();
    }

    private void InitializeStages()
    {
        stageMap = new Dictionary<Type, IStageble>();

        AddState(new BoostrapStage(saveSystem));
        AddState(new GameStage(audioService));
        AddState(new DialogueStage(DialogueItem));
        AddState(new MenuStage(MenuUsable));
        AddState(new GameOverStage(playerDeath));
        
    }
    private void InitializeStageServices()
    {
        audioService = ServiceLocatorGame.serviceLocatorGame.GetGameService<AudioService>();
        saveSystem = ServiceLocatorGame.serviceLocatorGame.GetGameService<SaveSystem>();
    }

    public void AddState<T>(T stage) where T : IStageble
    {
        if (!stageMap.ContainsKey(stage.GetType()))
        {
            stageMap.Add(stage.GetType(), stage);
        }
    }
    public void RemoveState<T>(T stage) where T : IStageble
    {
        if (stageMap.ContainsKey(stage.GetType()))
        {
            stageMap.Remove(stage.GetType());
        }
    }
}
