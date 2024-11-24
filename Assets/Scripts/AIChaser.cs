using UnityEngine;

public class AIChaser : MonoBehaviour
{
    private EnemyAnimationController animator;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private float speed = 2.0f;

    [SerializeField]
    private float aggroWidth = 7.0f;

    [SerializeField]
    private float aggroHeight = 4.0f;

    private void Start()
    {
        animator = GetComponent<EnemyAnimationController>();
    }

    private void Update()
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