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
        // Reset enemy state data
        EnemyState.Instance.ResetEnemyStates();

        // Switch to menu scene
        SceneManager.LoadScene(0);
    }
}
