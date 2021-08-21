using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityPoint : MonoBehaviour
{
    public float gravityScale, plannetRadius;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerStay(Collider obj)
    {
        Vector3 dir = (transform.position - obj.transform.position) * gravityScale;
        obj.GetComponent<Rigidbody>().AddForce(dir);

        if (obj.CompareTag("Player"))
        {
            obj.transform.up = Vector3.MoveTowards(obj.transform.up, -dir, gravityScale * Time.deltaTime);
        }
    }
}
