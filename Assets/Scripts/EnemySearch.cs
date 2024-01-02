using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemySearch : MonoBehaviour
{
    [SerializeField] private GameObject[] tagObjects;
    [SerializeField] private List<GameObject> enemies = new List<GameObject>();
    [SerializeField] private float dist;
    [SerializeField] private float[] terms;
    public GameObject triggerEnemy;

    void Update()
    {
        tagObjects = GameObject.FindGameObjectsWithTag("Gladiator");
        
        foreach(GameObject i in tagObjects) {
            if(i != gameObject && !enemies.Contains(i))
                enemies.Add(i);
        }
        
        foreach(GameObject i in enemies) {
            if(i == null)
                enemies.Remove(i);
        }
        
        terms = new float[enemies.Count];

        for (int runs = 0; runs < enemies.Count; runs++)
        {
            terms[runs] = Vector3.Distance(enemies[runs].transform.position, transform.position);
        }
        
        for (int runs = 0; runs < terms.Length; runs++)
        {       
            if (Vector3.Distance(enemies[runs].transform.position, transform.position) == terms.Min())
            {
                dist = Vector3.Distance(enemies[runs].transform.position, transform.position);
                
                triggerEnemy = enemies[runs];
            }
        }
        
        Debug.Log(triggerEnemy.name);
        
    }
}
