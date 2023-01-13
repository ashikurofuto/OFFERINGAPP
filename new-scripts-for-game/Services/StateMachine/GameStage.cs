using UnityEngine;

public class GameStage : IStageble
{
    private AudioService audioService;

    public GameStage(AudioService audio)
    {
        audioService = audio;
    }

    public void EnterState()
    {
        TimeChanger(1);
        audioService.Audio.SetFloat("Envourment", 0f);
    }

    private void TimeChanger(int scale)
    {
        Time.timeScale = scale;
    }



    public void ExitState()
    {
        TimeChanger(0);
        audioService.Audio.SetFloat("Envourment", -80f);
    }
}
