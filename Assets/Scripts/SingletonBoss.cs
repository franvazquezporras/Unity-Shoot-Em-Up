using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonBoss : MonoBehaviour
{
    public static SingletonBoss singleton;
    private void Awake()
    {
        if (singleton == null)
        {
            singleton = this;
        }
        else
        {
            Destroy(gameObject);

        }
        //DontDestroyOnLoad(gameObject);
    }
}
