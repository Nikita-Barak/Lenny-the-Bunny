using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    private Animator animator;
    private string currentAnimation;

    void Start()
    {
        animator = GetComponent<Animator>();
        SetAnimation("Idle_Left"); 
    }

    public void UpdateAnimation(float horizontal, bool isRunning)
    {
        string newAnimation;
 
        if (isRunning)
        {
            // Determine running animation based on horizontal direction
            newAnimation = horizontal < 0 ? "Run_Left" : "Run_Right";
        }
        else
        {
            string current = currentAnimation[(currentAnimation.LastIndexOf('_') + 1)..];
            
            if(current.Equals("Right")) 
            {
                newAnimation = "Idle_Right";
            }
            else if(current.Equals("Left")) 
            {
                newAnimation = "Idle_Left";
            }
            else
            {
            newAnimation = "Idle_Right";
            } 
        }

        SetAnimation(newAnimation);
    }

    // Set animation if it's not the current one
    private void SetAnimation(string anim)
    {
        if (anim == currentAnimation) return;
        animator.Play(anim);
        currentAnimation = anim;
    }
}
