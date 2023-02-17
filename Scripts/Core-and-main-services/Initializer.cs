using UnityEngine;
using UnityEngine.Audio;

public class Initializer : MonoBehaviour
{
    [SerializeField] private AudioMixer Audio;
    [SerializeField] private ImageStorage imageStorage;
    private ServiceLocator service;


    private void InitializeServices()
    {
        InputMain.InitInputStates();
        StateHandler.Init();
        service.Register(new AudioMixerService(Audio));
    }



    private void Awake()
    {
        InitializeServices();
        StateHandler.StartGameState();
        service = new ServiceLocator();
        imageStorage.SetImages();
    }


    private void Start()
    {
        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        InputMain.UpdateInput();
    }


}

