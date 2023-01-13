using UnityEngine;

public class BoostrapStage : IStageble
{
    private SaveSystem saveSystem;
    private GameData data;

    public BoostrapStage(SaveSystem save)
    {
        saveSystem = save;
        data = ServiceLocatorGame.serviceLocatorGame.GetGameService<GameData>();
    }

    public void EnterState()
    {
        Time.timeScale = 1;
        saveSystem.Load(data);
    }

    public void ExitState()
    {

    }
}
