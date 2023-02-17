using UnityEngine;
using UnityEngine.InputSystem;

public class GameStateInput : InputBehaviour
{
    private IGameMovePress _gameMove;
    private IGameInteractionPress _gameInteraction;
    private IGameOptionalPress _gameOptional;

    public GameStateInput(IGameMovePress move, IGameOptionalPress optional, IGameInteractionPress interaction)
    {
        _gameMove = move;
        _gameInteraction = interaction;
        _gameOptional = optional;
    }


    public override void Start()
    {
        input.Game.Enable();
        input.Paused.Disable();
        input.Menu.Disable();
        input.Game.Optional.performed += OnOptioanPressed;
        input.Game.Using.performed += OnUsingPressed;
    }

    public override void Stop()
    {
        input.Game.Optional.performed -= OnOptioanPressed;
        input.Game.Using.performed -= OnUsingPressed;
        input.Game.Disable();
    }

    public override void Move()
    {
        Vector2 InputVector = input.Game.Move.ReadValue<Vector2>();
        _gameMove?.Move(InputVector);
    }


    private void OnUsingPressed(InputAction.CallbackContext context)
    {
        _gameInteraction?.Use();
        Debug.Log("Game using pressed");
    }


    private void OnOptioanPressed(InputAction.CallbackContext context)
    {
        _gameOptional?.OptionalUse();
        Debug.Log("Game Optional pressed");
    }
}




