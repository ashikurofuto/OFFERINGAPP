using UnityEngine;
using UnityEngine.Events;

public class PlayerMain : MonoBehaviour , IGameOptionalPress, IMenuBackPress
{
    public UnityEvent action = new UnityEvent();
    private bool canBack = false;

    private void OnEnable()
    {
        InputInterfacesStorage.menuBackPress = this;
        InputInterfacesStorage.gameOptionalPress = this;
    }
    private void OnDisable()
    {
        InputInterfacesStorage.menuBackPress = null;
        InputInterfacesStorage.gameOptionalPress = null;
    }

    public void OptionalUse()
    {
        Debug.Log("menu called");
        StateHandler.StartMenuState();
        canBack = true;
    }

    public void Back()
    {
        if (canBack == false)
            return;
        Debug.Log("Menu back accepted");
        action?.Invoke();
    }
}

