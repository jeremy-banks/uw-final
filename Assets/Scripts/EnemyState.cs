using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour
{
    /* very str8 fwd
     * checks if an enemy has already been slain, and marks an enemy slain
     * dictionary included to store the data, singleton to keep it persistent
     */
    public static EnemyState Instance { get; private set; }
    private Dictionary<int, bool> enemyStates = new Dictionary<int, bool>();

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
    }

    public bool IsEnemyDead(int enemyID)
    {
        return enemyStates.ContainsKey(enemyID) && enemyStates[enemyID];
    }

    public void MarkEnemyDead(int enemyID)
    {
        enemyStates[enemyID] = true;
    }
}
