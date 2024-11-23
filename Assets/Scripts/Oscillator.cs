using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 start_pos;
    
    [Tooltip("Distance of movement from starting point in each direction.")]
    [SerializeField] float radius = 0.2f;
    
    [Tooltip("Speed of the object in either direction")]
    [SerializeField] float speed = 2.5f;

    [Tooltip("Step size for the y-axis movement (for pixel-art effect).")]
    private float stepSize = 0.03f;
    
    void Start()
    {
        start_pos = transform.position;
    }

    void Update()
    {
        // Since we need to move between 2 points, we need a function that's changing between -1 and 1 constantly and in different slopes.
        // Also, because we want the object to start at 0 when initializing the game, Sin() is the best option to do so.
        float offset = Mathf.Sin(Time.time * speed) * radius;

        // Snap the offset to the nearest step
        offset = Mathf.Round(offset / stepSize) * stepSize;

        // All that is left is to add the calculated offset to the object's current position.
        transform.position = new Vector3(start_pos.x, start_pos.y + offset, start_pos.z);
    }
}
