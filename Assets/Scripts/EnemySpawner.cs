using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemies;
    public float leftX, rightX;
    public float maxY, minY;
    
    void Start()
    {
        InvokeRepeating("spawner", 1, 1.6f);
    }

    
    void spawner()
    {
        Instantiate(enemies[0], randomSelect(leftX,rightX),Quaternion.identity);
    }
    Vector3  randomSelect(float  value1, float value2)
    {
        
        var value = Random.value;
        if (value < 0.5)
        {
            return new Vector3(value2, maxY, 0);
        }
        else
        {
            return new Vector3(value1,minY,0);
        }
        
    }

}
