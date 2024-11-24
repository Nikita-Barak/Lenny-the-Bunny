using UnityEngine;

public class StayPut : MonoBehaviour
{
    private Vector3 initPosition;

    void Start()
    {
        initPosition = transform.position;
    }

    void Update()
    {
        transform.position = initPosition;
    }
}
