using UnityEngine;

public class MenuState : State
{
    private IMenuOpeneble menuOpeneble;
    private AudioMixerService audio;

    public override void Enter()
    {
        Debug.Log("Menu state is started");
        audio = ServiceLocator.locator.GetService<AudioMixerService>();
        audio.Mixer.SetFloat("Menu", 0f);
        menuOpeneble = StateHandler.MenuOpeneble;
        menuOpeneble?.Open();
        InputMain.SetInputState(InputMain.MenuInputState);
    }

    public override void Exit()
    {
        audio.Mixer.SetFloat("Menu", -80f);
        Debug.Log("Menu state is stopped");
        menuOpeneble?.Close();
    }
}

