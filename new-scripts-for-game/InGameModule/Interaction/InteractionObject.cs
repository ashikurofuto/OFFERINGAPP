using UnityEngine;
using UnityEngine.Events;

public class InteractionObject : MonoBehaviour, IInteractable
{
    public UnityAction OnInteractionEvent;


    public void Activate()
    {
        OnInteractionEvent?.Invoke();
    }

    public void OnDeselected()
    {
        throw new System.NotImplementedException();
    }

    public void OnSelected()
    {
        throw new System.NotImplementedException();
    }
}
