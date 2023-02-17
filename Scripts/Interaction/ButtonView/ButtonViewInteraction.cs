using UnityEngine.UI;

public static class ButtonViewInteraction 
{
    public static Image standartImage;
    public static Image gamepadImage;
    public static IHintButton Hint { get; set; }

    public static Image SetInteractionImage()
    {
        if (InputMain.IsGamepadActive())
        {
            return gamepadImage;
        }
        return standartImage;
    }
}
