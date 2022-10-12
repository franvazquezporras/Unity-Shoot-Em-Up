using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public float rango;
    public GameObject[] enemigos;
    public GameObject boss;
    public int oleada= 1;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnearEnemigo", rango,rango);    
    }
    void Update()
    {
        oleada = PlayerPrefs.GetInt("Puntuacion") / 1000 +1;    
    }
    void SpawnearEnemigo()
    {
        
            for (int i = 0; i < oleada; i++)
            {
                if (PlayerPrefs.GetInt("Puntuacion") >= 3000)
                {
                    Instantiate(boss, new Vector3(0, 5, 0), Quaternion.identity);
                     
                }
                else
                {
                    Instantiate(enemigos[Random.Range(0, enemigos.Length)], new Vector3(Random.Range(-8, 8), 7, 0), Quaternion.identity);
                }
            }
        
        
    }

}
