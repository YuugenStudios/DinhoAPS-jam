using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    int health = 3;

    public void takeDamage()
    {
        health--;

        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
