using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] int healthCurrent;
    public int healthStarting;

    // Start is called before the first frame update
    void Start()
    {
        healthCurrent = healthStarting;
    }

    // Update is called once per frame
    void Update()
    {
        //if hp less than 1 then die
        if (healthCurrent < 1) Die();
    }

    void HidePlayerMeshRenderer(GameObject obj)
    {
        MeshRenderer meshRenderer = obj.GetComponent<MeshRenderer>();
        if (meshRenderer != null)
        {
            meshRenderer.enabled = false;
        }
    }

    void Die()
    {
        Debug.Log("argh!!!");

        // Disable mesh renderer of player so they are not visible
        foreach (Transform child in transform)
        {
            HidePlayerMeshRenderer(child.gameObject);
        }
        HidePlayerMeshRenderer(gameObject);

        // Load gameover scene
        SceneManager.LoadScene(1);
    }

    public void Damage()
    {
        Debug.Log("ouch!");
        healthCurrent -= 1;
    }
}
