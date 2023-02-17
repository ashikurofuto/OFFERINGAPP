using UnityEngine.InputSystem;
using UnityEngine;

public static class InputMain
{
    public static GameInput input = new GameInput();
    private static InputBehaviour currentInput;
    private static GameStateInput gameStateInput;
    private static PausedInput pausedInput;
    private static MenuInput menuInput;

    public static GameStateInput InputGameState { get => gameStateInput; }
    public static PausedInput PausedInputState { get => pausedInput; }
    public static MenuInput MenuInputState { get => menuInput; }


    public static void InitInputStates()
    {
        gameStateInput = new GameStateInput(InputInterfacesStorage.gameMovePress,
            InputInterfacesStorage.gameOptionalPress,
            InputInterfacesStorage.gameInteractionPress);
        pausedInput = new PausedInput(InputInterfacesStorage.pausedUsingPress,
            InputInterfacesStorage.pausedBackPress);
        menuInput = new MenuInput(InputInterfacesStorage.menuMovePress,
            InputInterfacesStorage.menuAcceptPress,
            InputInterfacesStorage.menuBackPress);
    }

    public static void SetInputState(InputBehaviour inputBehaviour)
    {
        currentInput?.Stop();
        currentInput = inputBehaviour;
        currentInput.input = input;
        currentInput?.Start();
    }

    public static void UpdateInput()
    {
        currentInput?.Move();
        
    }

    public static bool IsGamepadActive()
    {
        var gamepad = Gamepad.current;
        if (gamepad == null)
        {
            return false;
        }
        return true;
    }
}
