using TMPro;
using Unity.PlasticSCM.Editor.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EatCarrot : MonoBehaviour
{
    [Tooltip("Optional delay before the object disappears (in seconds).")]
    [SerializeField] TMP_Text counterText;
    [SerializeField] float winDelay = 1.0f;
    [SerializeField] float winCount = 10.0f;
    int counter = 0;

    void Start()
    {
        counterText.text = "" + counter;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the colliding object has the "Player" tag
        if (other.CompareTag("Carrot"))
        {
            counter++;
            Destroy(other.gameObject);
            counterText.text = "" + counter;
        }

        if(counter == winCount)
        {
            Invoke(nameof(ResetScene), winDelay);
        }
    }

    private void ResetScene()
    {
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Reset()
    {
        counter = 0;
    }
}