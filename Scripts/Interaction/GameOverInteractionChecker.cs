using UnityEngine;
using UnityEngine.Events;

public class GameOverInteractionChecker : MonoBehaviour, IGameOverStartInteracion, IGameOverPlayInteracion
{
    public UnityEvent SetDeathEvent = new UnityEvent();


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerDeathBehaviour>(out var player))
        {
            StateHandler.gameOverInteraction = this;
            StateHandler.gameOverStartInteracion = this;
            StateHandler.StartGameOverState();
        }
    }

    private void OnDestroy()
    {
        StateHandler.gameOverInteraction = null;
        StateHandler.gameOverStartInteracion = null;
    }


    public void SetInteraction()
    {
        Debug.Log("Interaction Setted");
    }

    public void StartInteraction()
    {
        SetDeathEvent?.Invoke();
    }
}
