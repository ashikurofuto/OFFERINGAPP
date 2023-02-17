using UnityEngine;
using UnityEngine.UI;

public class HintButton : MonoBehaviour , IHintButton
{
    [SerializeField] private Image currentHint;

    private void Start()
    {
        ButtonViewInteraction.Hint = this;
    }

    public void SetHintButton()
    {
        currentHint.sprite = ButtonViewInteraction.SetInteractionImage().sprite;
        gameObject.SetActive(true);   
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }
}
