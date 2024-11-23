using UnityEngine;

public class StayPut : MonoBehaviour
{
    private Vector3 initPosition;

    void Start()
    {
        initPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = initPosition;
    }
}
