using UnityEngine;

public class GameState : State
{
    private AudioMixerService audio;

    public override void Enter()
    {
        audio = ServiceLocator.locator.GetService<AudioMixerService>();
        audio.Mixer.SetFloat("Game", 0f);
        Debug.Log("Game State started");
        InputMain.SetInputState(InputMain.InputGameState);
        //TimeChanger(1);
    }

    public override void Exit()
    {
        audio.Mixer.SetFloat("Game", -80f);
        Debug.Log("Game state stopped");
        
    }

    private void TimeChanger(float t)
    {
        Time.timeScale = t;
    }

}

