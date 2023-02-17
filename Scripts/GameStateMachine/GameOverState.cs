using UnityEngine;

public class GameOverState : State
{
    private IGameOverStartInteracion gameOverInteraction;
    private IGameOverPlayInteracion gameOverStartInteraction;
    private AudioMixerService audio;

    public override void Enter()
    {
        audio = ServiceLocator.locator.GetService<AudioMixerService>();
        audio.Mixer.SetFloat("GameOver", 0f);
        DeathPlayInteraction();
        Debug.Log("Game over state is started");
    }

    private void DeathPlayInteraction()
    {
        gameOverInteraction = StateHandler.gameOverInteraction;
        gameOverStartInteraction = StateHandler.gameOverStartInteracion;
        gameOverInteraction?.SetInteraction();
        gameOverStartInteraction?.StartInteraction();
    }

    public override void Exit()
    {
        audio.Mixer.SetFloat("GameOver", -80f);
        Debug.Log("Game over state is stopped");
    }
}

