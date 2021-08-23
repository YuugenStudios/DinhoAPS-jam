using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDell : MonoBehaviour
{
    public GameObject objetoASerDestruido;
    
    void Destruir()
    {
        Destroy(objetoASerDestruido);
    }    
    
}
