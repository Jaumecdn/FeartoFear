using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{

    public float rate;
    public GameObject[] enemies;
    public int waves = 1;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawmEnemy1", rate, rate);

        InvokeRepeating("SpawmEnemy2", rate, rate);
    }

    // Update is called once per frame
    void SpawmEnemy1()
    {
       for(int i = 0; i < waves; i++){
            Instantiate(enemies[(int)Random.Range(0, enemies.Length)], new Vector3(Random.Range(-7.6f, 7.6f), Random.Range(7,9), 0), Quaternion.identity);
        }

    }

    void SpawmEnemy2()
    {
        for (int i = 0; i < waves; i++)
        {
            Instantiate(enemies[(int)Random.Range(0, enemies.Length)], new Vector3(9, Random.Range(-5f, 5f), 0), Quaternion.identity);
        }

    }
}
