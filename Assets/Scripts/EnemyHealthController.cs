using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
    public float hp = 3;

    private void Update()
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
