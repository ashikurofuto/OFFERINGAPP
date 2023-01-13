using UnityEngine;

public class PlayerKiller : MonoBehaviour, IDeathAnimationHandler
{
    [SerializeField] private string animationName;

    public event System.Action OnDeathStartedEvent;

    public string SetAnimationClip()
    {
        return animationName;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerDeathAnimation>(out var playerDeath))
        {
            playerDeath.DeathAnimation = this;
            OnDeathStartedEvent?.Invoke();
        }
    }
}
