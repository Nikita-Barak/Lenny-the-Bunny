using UnityEngine;
using UnityEngine.SceneManagement;

public class Die : MonoBehaviour
{
    NewMover mover;
    Collider2D playerCollider;
    Rigidbody2D rb;
    AnimationController animator;
    [SerializeField] private float resetDelay = 1.0f;

    void Start()
    {
        mover = GetComponent<NewMover>();
        playerCollider = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<AnimationController>();
    }

    public void Execute()
    {
        if (animator != null && mover != null && playerCollider != null && rb != null)
        {
            mover.enabled = false;
            playerCollider.enabled = false;
            rb.simulated = false;
            animator.HandleDeath();
        }

        Invoke(nameof(ResetScene), resetDelay);
    }

    private void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}