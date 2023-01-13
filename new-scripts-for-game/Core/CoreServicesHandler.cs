using UnityEngine;
using UnityEngine.Audio;

public class CoreServicesHandler : MonoBehaviour
{
    [SerializeField]
    private AudioMixer audioMixer;
    [SerializeField]
    private LevelStorage levelStorage;

    private LevelService levelService;
    private ServiceLocatorGame serviceLocator;
    private MainStateMachine stateMachine;
    private SaveSystem saveSystem;
    private AudioService audioService;
    private GameData gameData;
    

    private void Awake()
    {
        DontDestroyOnLoad(this);
        InitServices();
    }

    private void Start()
    {
        serviceLocator.RegisterGameService(stateMachine);
        serviceLocator.RegisterGameService(saveSystem);
        serviceLocator.RegisterGameService(audioService);
        serviceLocator.RegisterGameService(levelService);
        serviceLocator.RegisterGameService(gameData);


        stateMachine.SetCurrentStage(stateMachine.stageMap[typeof(BoostrapStage)]);
    }

    private void OnDestroy()
    {
        serviceLocator.UnregistredGameService(stateMachine);
        serviceLocator.UnregistredGameService(gameData);
        serviceLocator.UnregistredGameService(saveSystem);
        serviceLocator.UnregistredGameService(audioService);
        serviceLocator.UnregistredGameService(levelService);
    }

    private void InitServices()
    {
        serviceLocator = new ServiceLocatorGame();
        serviceLocator.Initialize();
        gameData = new GameData();
        saveSystem = new SaveSystem();
        levelService = new LevelService(levelStorage);
        audioService = new AudioService(audioMixer);
        stateMachine = new MainStateMachine();
    }
}




