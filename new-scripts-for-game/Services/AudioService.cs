using UnityEngine.Audio;

public class AudioService : IGameService
{
    public AudioMixer Audio { get; set; }

    public AudioService(AudioMixer mixer)
    {
        Audio = mixer;
    }
}

