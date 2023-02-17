using UnityEngine.Audio;

public class AudioMixerService : IGameService
{
    private AudioMixer audioMixer;
    public AudioMixer Mixer { get => audioMixer; }

    public AudioMixerService(AudioMixer audio)
    {
        audioMixer = audio;
    }
}
