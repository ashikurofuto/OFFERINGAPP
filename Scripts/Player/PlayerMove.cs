using UnityEngine;

public class PlayerMove : MonoBehaviour, IGameMovePress
{
    [Header("Settings")]
    [SerializeField] private float velocity = 0.1f;
    [SerializeField] private bool isHorizontalState = false;

    [Header("Movements")]
    [SerializeField] private bool movementPositiveX = true;
    [SerializeField] private bool movementNegativeX = true;
    [SerializeField] private bool movementPositiveY = true;
    [SerializeField] private bool movementNegativeY = true;

    [Header("Sounds")]
    [SerializeField] private AudioSource stepsAudioSource;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        if (isHorizontalState)
        {
            animator.SetBool("IsRunning", true);
            animator.SetFloat("DirectionX", 1f);
        }
    }



    public void MoveTransform(Vector2 direction)
    {
        if (movementPositiveX == false && direction.x > 0f)
            direction.x = 0f;
        if (movementNegativeX == false && direction.x < 0f)
            direction.x = 0f;
        if (movementPositiveY == false && direction.y > 0f)
            direction.y = 0f;
        if (movementNegativeY == false && direction.y < 0f)
            direction.y = 0f;

        transform.position += new Vector3(direction.x, direction.y, 0f) * velocity * Time.deltaTime;

        bool isRunning = MoveAnomation(direction);
        MoveSound(isRunning);
    }

    private bool MoveAnomation(Vector2 direction)
    {
        var isRunning = direction.x != 0 || direction.y != 0;
        animator.SetBool("IsRunning", isRunning);
        if (isRunning)
        {
            animator.SetFloat("DirectionX", direction.x);
            animator.SetFloat("DirectionY", direction.y);
        }

        return isRunning;
    }

    private void MoveSound(bool isRunning)
    {
        if (stepsAudioSource.isPlaying != isRunning)
        {
            if (isRunning)
                stepsAudioSource.Play();
            else
                stepsAudioSource.Stop();
        }
    }

    public void Move(Vector2 inputDirection)
    {
        MoveTransform(inputDirection);
    }
}


