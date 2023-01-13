using UnityEngine;
using UnityEngine.Events;

public class InteractionTrigger : MonoBehaviour
{
    public UnityAction OnTriggerEnterEvent;
    public UnityAction OnTriggerExitEvent;

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<GamePlayer>(out var player))
        {
            OnTriggerEnterEvent?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<GamePlayer>(out var player))
        {
            OnTriggerExitEvent?.Invoke();
        }
    }

}

