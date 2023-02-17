using UnityEngine;

public class PausedState : State
{
    private AudioMixerService audio;

    public override void Enter()
    {
        audio = ServiceLocator.locator.GetService<AudioMixerService>();
        audio.Mixer.SetFloat("Paused", 0f);
        InputMain.SetInputState(InputMain.PausedInputState);
        Debug.Log("Paused state is started");
    }

    public override void Exit()
    {
        audio.Mixer.SetFloat("Paused", -80f);
        Debug.Log("Paused state is stopped");
    }
}

