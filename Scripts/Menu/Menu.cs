using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour , IMenuOpeneble
{
    [SerializeField] private MenuWindow MainPanel;
    private Stack<MenuWindow> windowsHistory = new Stack<MenuWindow>();
    private bool menuOpened = false;

    private void Awake()
    {
        StateHandler.MenuOpeneble = this;
        windowsHistory.Push(MainPanel);
    }

    public void Close()
    {
        MainPanel.CloseWindow();
        gameObject.SetActive(false);
        StateHandler.BackToPreviousState();
    }

    public void Open()
    {
        Debug.Log("Menu is Opened");
        gameObject.SetActive(true);
        OpenFirstWindow();
        menuOpened = true;
    }

    private void OpenFirstWindow()
    {
        windowsHistory.Peek().OpenFirstTime();
    }


    public void OpenNewWindow(MenuWindow newWindow)
    {
        if (!windowsHistory.Contains(newWindow))
        {
            windowsHistory.Peek().CloseWindow();
            windowsHistory.Push(newWindow);
            newWindow.OpenWindow();
            return;
        }
        throw new System.Exception($"{newWindow.gameObject.name} cant be added second time");
    }

    public void OpenPreviousWindow()
    {
        if (menuOpened == false)
            return;


        var temp = windowsHistory.Peek();
        temp.CloseWindow();
        if (temp == MainPanel && temp.OpenFirstTime()== true)
        {
            Close();
            return;
        }
        windowsHistory.Pop();
        windowsHistory.Peek().OpenWindow();
    }

}


