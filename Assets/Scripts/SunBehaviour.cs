using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunBehaviour : MonoBehaviour
{
    [Header("sun Rotation")]
    [SerializeField] private float sunVelocity, slowdowRate;
    [SerializeField] private Vector3 sunDirection;
    [SerializeField] private Transform planet;

    [Header("plantInteractions")]
    [SerializeField] float sunRange;
    [SerializeField] LayerMask plantLayer;

    //flags
    private bool canRotate;

    private void Start()
    {
        canRotate = true;
    }
    void Update() {

        Ray upray = new Ray();
        upray.origin = transform.position;
        upray.direction = new Vector3(0, -1, 0);

        Ray downRay = new Ray();
        downRay.origin = transform.position;
        downRay.direction = new Vector3(0, 1, 0);
        RaycastHit hit;

        if(Physics.Raycast(upray, out hit, sunRange, plantLayer)  || Physics.Raycast(downRay, out hit, sunRange, plantLayer)) {
            
            StartCoroutine(LockRotate());
        }

        RotateSun();   
    }

    void RotateSun() {
        if(canRotate)
        transform.RotateAround(planet.position, sunDirection, sunVelocity);
        else if(!canRotate) {
            transform.RotateAround(planet.position, sunDirection, sunVelocity * slowdowRate);
        }
    }
    
    IEnumerator LockRotate() {
        canRotate = false;
        yield return new WaitForSeconds(10);
        canRotate = true;
    }

    private void OnDrawGizmos() {
        Gizmos.DrawRay(transform.position, new Vector3(0,-1,0) * sunRange);
        Gizmos.color = Color.red;
    }
}
