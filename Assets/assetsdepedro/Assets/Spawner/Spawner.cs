using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    GameObject SpawnerRight, SpawnerLeft,t1,t2;
    [SerializeField]
    bool t1Right, t2Right, t1Left, t2Left;
    void Start()
    {
        
    }

    
    void Update()
    {
        if(t1Right){Instantiate(t1,SpawnerRight.transform);t1Right = false;}
        if(t2Right){Instantiate(t2,SpawnerRight.transform);t2Right = false;}
        if(t1Left){Instantiate(t1,SpawnerLeft.transform);t1Left = false;}
        if(t2Left){Instantiate(t2,SpawnerLeft.transform);t2Left = false;}
        
    }
}
