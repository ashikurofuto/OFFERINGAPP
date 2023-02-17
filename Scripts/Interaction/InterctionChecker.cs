using UnityEngine;

public class InterctionChecker : MonoBehaviour
{
    [SerializeField] private InteractionBehaviour currentInteraction;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.TryGetComponent<PlayerInteraction>(out var player))
        {
            player.SetInteraction(currentInteraction);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        
        if (collision.gameObject.TryGetComponent<PlayerInteraction>(out var player))
        {
            player.SetInteraction(null);
            currentInteraction.Deselected();
        }
    }

}


