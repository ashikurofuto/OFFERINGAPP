using UnityEngine;

public class PlayerDeathAnimation : MonoBehaviour
{
    private Animator animator;
    private LevelService levelService;

    public IDeathAnimationHandler DeathAnimation
    {
        get
        {
            return DeathAnimation;
        }
        set
        {
            if (DeathAnimation != null)
            {
                DeathAnimation.OnDeathStartedEvent += StartDeath;
            }
        }
        
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        levelService = ServiceLocatorGame.serviceLocatorGame.GetGameService<LevelService>();
    }


    private void StartDeath()
    {
       var animationName = DeathAnimation.SetAnimationClip();
        animator.Play(animationName);
        StageHandler.StartGameOverStage();
        
    }

    public void SetGameOverState(int levelDeathIndex)
    {
        levelService.LoadDeathScene(levelDeathIndex);
    }


    private void OnDestroy()
    {
        DeathAnimation.OnDeathStartedEvent -= StartDeath;
    }

}
