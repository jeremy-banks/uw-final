using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReturnToMainMenu : MonoBehaviour
{
    public Button button;

    private void Start()
    {
        // Add a click listener
        button.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        // Switch to menu scene
        SceneManager.LoadScene(0);

        // Need to add logic here to reset singleton data
        // otherwise you'd need to restart app for enemies to come alive
    }
}
