using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int EnemyID;
    int healthCurrent;
    public int healthStarting;

    // Start is called before the first frame update
    void Start()
    {
        // check if enemy is dead
        if (EnemyState.Instance.IsEnemyDead(EnemyID))
        {
            // enemy is dead so deactivate
            gameObject.SetActive(false);
            return;
        }
        else
        {
            // enemy is not dead so give him health
            healthCurrent = healthStarting;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if hp less than 1 then die
        if (healthCurrent < 1) Die();
    }

    void Die()
    {
        EnemyState.Instance.MarkEnemyDead(EnemyID);
        gameObject.SetActive(false);
        return;
    }

    public void DealDamage()
    {
        healthCurrent -= 1;
    }
}
