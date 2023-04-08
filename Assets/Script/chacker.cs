using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class chacker : MonoBehaviour
{
    public float betweenÝndexs_distance;
    private Vector3 offset;
    private int indx;

   
    private void Start()
    {
        offset = new Vector3(0, 0, -1f);
       
    }


    void FixedUpdate()
    {
        indx = SoapyBehaviour.instance.cubes.IndexOf(gameObject);

        if (indx > 0)
        {

            Vector3 Current_Obj = SoapyBehaviour.instance.cubes[indx].gameObject.transform.position;
            Vector3 Current_Obj_previous = SoapyBehaviour.instance.cubes[indx - 1].gameObject.transform.position;
            betweenÝndexs_distance = Mathf.Abs(Current_Obj.z - Current_Obj_previous.z);
 
        }
        if (betweenÝndexs_distance > 1.01f)
        {
            SoapOfsset();
            
        }
        
      
    }

    public void SoapOfsset()
    {

        Vector3 Soap_Offset = gameObject.transform.position;
        Vector3 SoapOffset = new Vector3(Soap_Offset.x, Soap_Offset.y, Soap_Offset.z) + offset;

        float lerp = Mathf.Lerp(Soap_Offset.z, SoapOffset.z, Time.deltaTime * 10f);
        transform.position = new Vector3(SoapOffset.x, SoapOffset.y, lerp);


        //transform.position = Vector3.Lerp(Soap_Offset, SoapOffset, 0.6f);
        //transform.DOMove(SoapOffset, 0.1f);
        //transform.position = Vector3.MoveTowards(Soap_Offset, SoapOffset, 0.5f);





    }
}
