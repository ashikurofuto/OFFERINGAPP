using UnityEngine;
using UnityEngine.InputSystem;

public class PausedInput : InputBehaviour
{
    private IPausedUsingPress _pausedUsing;
    private IPausedBackPress _pausedBack;

    public PausedInput(IPausedUsingPress usep, IPausedBackPress backp)
    {
        _pausedBack = backp;
        _pausedUsing = usep;
    }

    public override void Start()
    {
        input.Game.Disable();
        input.Paused.Enable();
        input.Menu.Disable();
        
        input.Paused.Back.performed += OnPausedBackPress;
        input.Paused.Using.performed += OnPausedUsingPress;
    }

    public override void Stop()
    {
        input.Paused.Back.performed -= OnPausedBackPress;
        input.Paused.Using.performed -= OnPausedUsingPress;
        input.Paused.Disable();
    }

    private void OnPausedUsingPress(InputAction.CallbackContext context)
    {
        _pausedUsing?.Using();
        Debug.Log("Paused Using pressed");
    }

    private void OnPausedBackPress(InputAction.CallbackContext context)
    {
        _pausedBack?.Back();
        Debug.Log("Paused Back pressed");
    }

}


