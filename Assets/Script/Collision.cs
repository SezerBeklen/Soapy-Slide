using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 


public class Collision : MonoBehaviour
{
     

    private void Start()
    {
        
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
         
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "soap")
        {
            if (!SoapyBehaviour.instance.cubes.Contains(other.gameObject))
            {
                other.GetComponent<BoxCollider>().isTrigger = false;
                other.gameObject.tag = "Soapy";
                other.gameObject.AddComponent<Collision>();
                //other.gameObject.AddComponent<soapChecker>();
                other.gameObject.AddComponent<chacker>();
                other.gameObject.AddComponent<Rigidbody>();
                other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                other.gameObject.transform.GetChild(0).gameObject.SetActive(true);
                SoapyBehaviour.instance.StackSoapy(other.gameObject, SoapyBehaviour.instance.cubes.Count - 1);
                SoapyBehaviour.instance.SfxPlay(SoapyBehaviour.instance.cubes[0]);
                    
            }
        }
        if (other.gameObject.tag == "obstacle" )
        {
            int current›ndex;
             
            current›ndex = SoapyBehaviour.instance.cubes.IndexOf(gameObject);
            DecreaseSoapy(current›ndex);
            SoapyBehaviour.instance.SfxObstaclePlay(SoapyBehaviour.instance.cubes[0]);
            //Debug.Log("current›ndex"+ current›ndex);
            
        }
        
       
    }

    public void DecreaseSoapy(int Current›ndex)
    {
         SoapyBehaviour.instance.cubes[Current›ndex].SetActive(false);
        
        if (Current›ndex != 0)
        {
            SoapyBehaviour.instance.cubes.RemoveAt(Current›ndex);
        }

    }


}



         