using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterTriggers : MonoBehaviour
{
    public Animator Anim;
    public AudioClip whooshSound;
    void Start()
    {
        MenRigidbody(false);
        MenCollider(true);
        
    }

    private void OnTriggerEnter(Collider soap)
    {
        if (soap.gameObject.CompareTag("Soapy"))
        {
            AudioSource.PlayClipAtPoint(whooshSound, SoapyBehaviour.instance.cubes[0].transform.position,1);
            Anim.enabled = false;
            MenRigidbody(true);
            MenCollider(false);
            
        }
    }
    void MenRigidbody(bool situation)
    {
        Rigidbody[] rb = GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody childs in rb)
        {

            childs.useGravity = situation;
        }
    }
    
    void MenCollider(bool situation)
    {
        Collider[] cl = GetComponentsInChildren<Collider>();

        foreach (Collider childs in cl)
        {

            childs.isTrigger = situation;
        }
    }
}
