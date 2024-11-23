using UnityEngine;

public class CameraScaler : MonoBehaviour
{
    Camera main_camera;              // The main camera object
    private float init_orto_size;    // The initial orthographic size of the camera
    private float init_ratio;        // The initial aspect ratio of the camera

    void Start()
    {
        // Get the main camera object, original orthographic size and aspect ratio of the screen
        main_camera = Camera.main;
        init_orto_size = main_camera.orthographicSize;
        init_ratio = (float)Screen.width / (float)Screen.height;
    }

    void Update()
    {
        float curr_ratio = (float)Screen.width / (float)Screen.height;

        if (curr_ratio != init_ratio)
        {
            main_camera.orthographicSize = init_orto_size * (init_ratio / curr_ratio);
        }
    }
}