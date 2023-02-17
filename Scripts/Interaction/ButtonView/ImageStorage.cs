using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ButtonImageStorage", menuName = "Data/ButtonImageStorage", order = 0)]
public class ImageStorage : ScriptableObject
{
    [SerializeField] private Image keyboardImage;
    [SerializeField] private Image gamepadImage;

    public void SetImages()
    {
        ButtonViewInteraction.standartImage = keyboardImage;
        ButtonViewInteraction.gamepadImage = gamepadImage;
    }

}
