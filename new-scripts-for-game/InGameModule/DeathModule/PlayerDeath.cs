using System.Collections;
using UnityEngine;

public class PlayerDeath : MonoBehaviour, IPlayerDeathWrapper
{
    [SerializeField] private int VideoChance;
    [SerializeField] private PlayVideoDeath videoDeath;
    private LevelService levelService;
    private MainStateMachine stateMachine;

    private void Awake()
    {
        levelService = ServiceLocatorGame.serviceLocatorGame.GetGameService<LevelService>();
        stateMachine = ServiceLocatorGame.serviceLocatorGame.GetGameService<MainStateMachine>();
        stateMachine.playerDeath = this;
    }

    private IEnumerator PlayVideoDeath()
    {
        videoDeath.PlayDeath();
        yield return new WaitForSeconds(videoDeath.GetVideoTime());
        levelService.LoadLastSimpleLevel();
        StageHandler.StartGameStage();
    }

    public void SetAndStartDeath()
    {
        int randomChance = Random.Range(0, 100);
        if (randomChance > VideoChance)
        {
            levelService.LoadDeathScene(0);
            return;
        }
        StartCoroutine(PlayVideoDeath());
    }
}
