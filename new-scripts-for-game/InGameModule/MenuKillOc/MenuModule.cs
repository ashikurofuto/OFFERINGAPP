using UnityEngine;

public class MenuModule : MonoBehaviour , IMenuInput , IMenuUsable
{
    [SerializeField] private MenuWindow[] menuWindows;
    [SerializeField] private AudioSource audio;
    private MenuWindow currentWindow;
   

    public void CloseMenu()
    {
        StageHandler.StartGameStage();
    }

    public void MenuCall()
    {
        StageHandler.StartMenuStage();
    }

    public void CheckMenuWindow(int index)
    {
        for (int i = 0; i < menuWindows.Length; i++)
        {
            if(i == index)
            {
                currentWindow = menuWindows[i];
                menuWindows[i].OpenWindow();
                PlayWindowSound(menuWindows[i]);
            }
            menuWindows[i].CloseWindow();
        }
    }
    private void PlayWindowSound(MenuWindow window)
    {
        audio.Stop();
        audio.clip = window.parameters.MenuSound;
        audio.Play();
    }


    public void OpenMenu()
    {
        menuWindows[0].OpenWindow();
    }

    public void BackMenuStage()
    {
        int prevWindowId = currentWindow.parameters.previousStage;
        currentWindow.CloseWindow();
        currentWindow = menuWindows[prevWindowId];
        currentWindow.OpenWindow();
    }
}
