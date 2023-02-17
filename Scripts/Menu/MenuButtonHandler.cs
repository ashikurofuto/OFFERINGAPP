using UnityEngine;
using UnityEngine.UI;


public class MenuButtonHandler : MonoBehaviour, IMenuMovePress, IMenuAcceptPress
{
    [SerializeField]private Button firstButton;
    private Button currentButton;

    private void OnEnable()
    {
        InputInterfacesStorage.menuAcceptPress = this;
        InputInterfacesStorage.menuMovePress = this;
        currentButton = firstButton;
        SetSelectedButton(currentButton);
    }

    public void MoveButtons(Vector2 inputDirection)
    {
        SetSelectedButton(currentButton);
        ChangeSelectedButton(inputDirection);   
    }

    private void ChangeSelectedButton(Vector2 dir)
    {
        if (dir.x > 0)
        {
            currentButton.FindSelectableOnLeft();
        }
        if (dir.x < 0)
        {
            currentButton.FindSelectableOnRight();
        }
        if (dir.y > 0)
        {
            currentButton.FindSelectableOnUp();
        }
        if (dir.y < 0)
        {
            currentButton.FindSelectableOnDown();
        }
        
    }


    private void SetSelectedButton(Button button)
    {
        button?.Select();
    }

    public void Accept()
    {
        var buttonEvent = currentButton.onClick;
        buttonEvent?.Invoke();
    }

    private void OnDisable()
    {
        InputInterfacesStorage.menuAcceptPress = null;
        InputInterfacesStorage.menuMovePress = null;
    }
}



