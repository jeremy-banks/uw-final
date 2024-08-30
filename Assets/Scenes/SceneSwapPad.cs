using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwapPad : MonoBehaviour
{
    public int SceneToSwapTo;

    void OnTriggerEnter(Collider other)
    {
        // Check if the object colliding with the pad is tagged as "Player"
        if (other.CompareTag("Player"))
        {
            // Load the scene with the index specified in the public variable
            SceneManager.LoadScene(SceneToSwapTo);
        }
    }
}
