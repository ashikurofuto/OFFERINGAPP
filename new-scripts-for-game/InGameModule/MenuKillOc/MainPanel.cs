using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MainPanel : MenuWindow
{
    [SerializeField] private Button[] buttons;
    [SerializeField] private AudioClip[] panelClips;
    public UnityAction MainPanelEvent;
    private int defaultIndex = 1;
    private bool firstStage = true;
    private bool secondStage = false;


    private void SetWindowStage()
    {
        if (firstStage == true)
        {
            parameters.MenuSound = panelClips[0];
            MainPanelEvent?.Invoke();
            firstStage = false;
            secondStage = true;
        }
        if (secondStage == true)
        {
            parameters.MenuSound = panelClips[1];
        }

    }

    private void FindSelectebleButton(int currentIndex)
    {
        buttons[currentIndex].Select();
    }
    private void OnEnable()
    {
        SetWindowStage();
        FindSelectebleButton(defaultIndex);
    }


}