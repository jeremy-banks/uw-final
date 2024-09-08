using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropFlame : MonoBehaviour
{
    [SerializeField] GameObject flameGO;
    [SerializeField] float dropCooldown;
    float dropCooldownInitial = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        dropCooldown = dropCooldownInitial;
    }

    // Update is called once per frame
    void Update()
    {
        if (dropCooldown >= 0f)
        {
            dropCooldown -= Time.deltaTime;
        }
        else
        {
            dropCooldown = dropCooldownInitial;
            DropFlameNow();
        }
    }

    void DropFlameNow()
    {
        // Drop flame prefab
        GameObject droppedFlame = Instantiate(flameGO, transform);

        // Unparent object
        droppedFlame.transform.parent = null;

        // Destroy flame after 5 seconds
        Destroy(droppedFlame, 5.0f);
    }
}
