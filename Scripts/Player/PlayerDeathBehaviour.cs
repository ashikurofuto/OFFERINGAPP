using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PlayerDeathBehaviour : MonoBehaviour
{
    public UnityEvent changeLevel = new UnityEvent();
    private Animator animator;
    private bool canChange;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        canChange = false;
    }

    public bool SetAnimation(string animName, float delay)
    {
        animator.StopPlayback();
        animator.Play(animName);
        StartCoroutine(StartLevelChanger(delay));
        return canChange;
    }

    private IEnumerator StartLevelChanger(float delay)
    {
        yield return new WaitForSeconds(delay);
        changeLevel?.Invoke();
        canChange = true;
    }
}

