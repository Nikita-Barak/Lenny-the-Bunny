using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator animator;
    private string currentAnimation;
    private bool isDead = false;
    private readonly List<string> UNIT_IDLE = new List<string> {"Idle_Up", "Idle_Down", "Idle_Right", "Idle_Left"}; 
    private readonly List<string> UNIT_WALK = new List<string> {"Walk_Up", "Walk_Down", "Walk_Right", "Walk_Left"};
    private readonly List<string> UNIT_RUN = new List<string> {"Run_Up", "Run_Down", "Run_Right", "Run_Left"};
    private readonly List<string> UNIT_DIE = new List<string> {"Die_Up", "Die_Down", "Die_Right", "Die_Left"}; 

    void Start()
    {
        animator = GetComponent<Animator>();
        SetAnimation(UNIT_IDLE[1]);
    }

    // Update the animation based on the player's movement direction
    public void UpdateAnimation(float horizontal, float vertical, bool isRunning)
    {
        if(!isDead && (horizontal != 0 || vertical != 0) )
        {
            List<string> animationSet = DetermineMoveSet(isRunning);
            HandleMovement(animationSet, horizontal, vertical);
        }
        else HandleIdle();
    }

    public void HandleMovement(List<string> animationSet, float horizontal, float vertical)
    {
        string newAnimation;

        if (vertical > 0) newAnimation = animationSet[0];
        else if (vertical < 0) newAnimation = animationSet[1];
        else if (horizontal > 0 && vertical == 0) newAnimation = animationSet[2];
        else if (horizontal < 0 && vertical == 0) newAnimation = animationSet[3];
        else return;

        SetAnimation(newAnimation);
    }

    public List<string> DetermineMoveSet(bool isRunning)
    {
        if(isRunning) return UNIT_RUN;
        else return UNIT_WALK;
    }

    public void HandleIdle()
    {
        string current = currentAnimation[(currentAnimation.LastIndexOf('_') + 1)..];
        string next = UNIT_IDLE[1];
        
        if(current.Equals("Up")) next = UNIT_IDLE[0];
        else if(current.Equals("Down")) next = UNIT_IDLE[1];
        else if(current.Equals("Right")) next = UNIT_IDLE[2];
        else if(current.Equals("Left")) next = UNIT_IDLE[3];

        SetAnimation(next);
    }

    public void HandleDeath()
    {
        isDead = true;

        string current = currentAnimation[(currentAnimation.LastIndexOf('_') + 1)..];
        string death = UNIT_DIE[1];
        
        if(current.Equals("Up")) death = UNIT_DIE[0];
        else if(current.Equals("Down")) death = UNIT_DIE[1];
        else if(current.Equals("Right")) death = UNIT_DIE[2];
        else if(current.Equals("Left")) death = UNIT_DIE[3];

        SetAnimation(death);
    }

    // Set animation if it's not the current one
    public void SetAnimation(string anim)
    {
        if (anim == currentAnimation) return;
        animator.Play(anim);
        currentAnimation = anim;
    }
}