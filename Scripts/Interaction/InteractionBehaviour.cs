
using UnityEngine;

public abstract class InteractionBehaviour : MonoBehaviour
{
    private bool canStartPause = true;

    public abstract bool CanCloseInteraction();

    public virtual void Selected()
    {
        ButtonViewInteraction.Hint?.SetHintButton();
    }
    public virtual void Deselected()
    {
        ButtonViewInteraction.Hint.Close();
    }


    public virtual void Activate()
    {
        if (canStartPause == true)
        {
            StateHandler.StartPausedState();
            canStartPause = false;
            
        }
    }


    public virtual void Close()
    {
        StateHandler.BackToPreviousState();
        canStartPause = true;
    }
}
