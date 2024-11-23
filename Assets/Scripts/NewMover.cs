using UnityEngine;
using UnityEngine.InputSystem;

public class NewMover : MonoBehaviour
{
    public Rigidbody2D rb;
    AnimationController animator;
    [SerializeField] float moveSpeed = 3.0f;
    [SerializeField] float runMultiplier = 2.0f;
    [SerializeField] float diagonalFactor = 0.7f;
    [SerializeField] InputAction playerMovement;
    [SerializeField] InputAction Run;

    Vector2 moveDirection = Vector2.zero;

    void Start()
    {
        animator = GetComponent<AnimationController>();
    }

    void OnEnable()
    {
        playerMovement.Enable();
        Run.Enable();
    }

    void OnDisable()
    {
        playerMovement.Disable();
        Run.Disable();
    }

    void Update() 
    {
        moveDirection = playerMovement.ReadValue<Vector2>();
        float currentSpeed = moveSpeed;
        bool isRunning = Run.IsPressed();
        
        if(isRunning) currentSpeed *= runMultiplier;


        if(moveDirection.x != 0 && moveDirection.y != 0) 
        {
            rb.linearVelocity = new Vector2(moveDirection.x * currentSpeed * diagonalFactor, moveDirection.y * currentSpeed);
        }
        else
        {
            rb.linearVelocity = new Vector2(moveDirection.x * currentSpeed, moveDirection.y * currentSpeed);
        }

        animator.UpdateAnimation(moveDirection.x, moveDirection.y, isRunning);
    }
}