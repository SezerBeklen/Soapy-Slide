using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class soapChecker : MonoBehaviour
{
    Vector3 offset;

    private void Start()
    {
        offset = new Vector3(0, 0, -0.8f);
    }
    void FixedUpdate()
    {
        Ray ray = new Ray(transform.position, transform.TransformDirection(Vector3.right));
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit, 0.7f))
        {
            Debug.DrawRay(ray.origin, ray.direction * 0.7f, Color.green);
            if (hit.collider.gameObject == null)
            {
                SoapOfsset(ray);
            }
        }
        else
        {
            SoapOfsset(ray);
            
        }        
         
       

        
       
    }

    public void SoapOfsset(Ray Sray)
    {
        Debug.DrawRay(Sray.origin, Sray.direction * 1, Color.red);
        Vector3 SoapOffset = gameObject.transform.position;
        SoapOffset = new Vector3(transform.position.x, transform.position.y, transform.position.z) + offset;
        transform.DOMove(SoapOffset, 0.1f);
    }

}
