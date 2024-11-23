using UnityEngine;

public class AIChaser : MonoBehaviour
{
    private EnemyAnimationController animator;
    [SerializeField] GameObject player;
    [SerializeField] float speed = 2.0f; 
    [SerializeField] float aggroWidth = 7.0f;
    [SerializeField] float aggroHeight = 4.0f;

    void Start()
    {
        animator = GetComponent<EnemyAnimationController>();        
    }

    void Update()
    {
        Vector2 direction = player.transform.position - transform.position;

        if (Mathf.Abs(direction.x) < aggroWidth / 2 && Mathf.Abs(direction.y) < aggroHeight / 2)
        {
            direction.Normalize();
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

            animator.UpdateAnimation(direction.x, true);
        }
        else
        {
            animator.UpdateAnimation(0, false);
        }
    }
}