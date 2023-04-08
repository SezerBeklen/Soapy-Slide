using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionEffect : MonoBehaviour
{
     
    public ParticleSystem colleffect;
   


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Soapy"))
        {
            colleffect.Play();
        }
         
    }
}
