using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Die dieComponent = other.gameObject.GetComponent<Die>();

            if (dieComponent != null)
            {
                dieComponent.Execute();
            }
        }
    }
}