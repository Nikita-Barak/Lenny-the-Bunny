using UnityEngine;

public class Scaler : MonoBehaviour
{
    [Tooltip("Minimum scale.")]
    [SerializeField] Vector3 minScale = new Vector3(0.8f, 0.8f, 1f);

    [Tooltip("Maximum scale.")]
    [SerializeField] Vector3 maxScale = new Vector3(1.2f, 1.2f, 1f);

    [Tooltip("Speed of the inflation-deflation cycle.")]
    [SerializeField] float speed = 2f;

    void Update()
    {
        // Use Sin to create a smooth oscillation between -1 and 1 over time
        float t = (Mathf.Sin(Time.time * speed) + 1f) / 2f; // Normalize to range [0, 1]

        // Interpolate the shadow's scale between minScale and maxScale
        transform.localScale = Vector3.Lerp(minScale, maxScale, t);
    }
}