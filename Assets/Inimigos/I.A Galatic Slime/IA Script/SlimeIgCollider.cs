using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeIgCollider : MonoBehaviour
{
    
  private void OnCollisionStay(Collision other) {
      if(other.gameObject.tag == "Slimer")
      {
          Physics.IgnoreCollision(other.gameObject.GetComponent<Collider>(),GetComponent<Collider>());
      }
  }

    
}
