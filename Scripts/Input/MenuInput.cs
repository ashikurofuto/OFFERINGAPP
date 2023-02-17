using UnityEngine;
using UnityEngine.InputSystem;

public class MenuInput : InputBehaviour
{
    private IMenuMovePress _menuMove;
    private IMenuBackPress _menuBack;
    private IMenuAcceptPress _menuAccept;

    public MenuInput(IMenuMovePress move, IMenuAcceptPress accept, IMenuBackPress back)
    {
        _menuAccept = accept;
        _menuMove = move;
        _menuBack = back;
    }


    public override void Start()
    {
        input.Game.Disable();
        input.Paused.Disable();
        input.Menu.Enable();
        input.Menu.Accept.performed += OnMenuAcceptPressed;
        input.Menu.Back.performed += OnMenuBackPressed;
    }

    public override void Move()
    {
        var menuDirection = input.Menu.ButtonsUsage.ReadValue<Vector2>();
        _menuMove?.MoveButtons(menuDirection);
    }

    public override void Stop()
    {
        input.Menu.Accept.performed -= OnMenuAcceptPressed;
        input.Menu.Back.performed -= OnMenuBackPressed;
        input.Menu.Disable();
    }

    private void OnMenuBackPressed(InputAction.CallbackContext context)
    {
        _menuBack?.Back();
        Debug.Log("Menu Back pressed");
    }

    private void OnMenuAcceptPressed(InputAction.CallbackContext context)
    {
        _menuAccept?.Accept();
        Debug.Log("Menu accept pressed");
    }

}
