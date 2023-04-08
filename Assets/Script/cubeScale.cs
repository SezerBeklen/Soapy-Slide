using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class cubeScale : MonoBehaviour
{
    public float scaleY;
    public float positonY;
    public float soapCounter;
    public float finishCube_Distance;
    public static cubeScale cubeScale_instance;

    public GameObject winnScreen;

    [HideInInspector] 
    public GameObject cube0;


    public GameObject finisObject;
    
    public camFollow cam;
    public AudioClip Finish_Cube_Collision_Sound;
    public bool obstacle_Coll_Control;

    private void Awake()
    {
        if (cubeScale_instance == null)
        {
            cubeScale_instance = this;
        }
    }

    private void Start()
    {
        cube0 = SoapyBehaviour.instance.cubes[0];
        obstacle_Coll_Control = false;
    }
    private void Update()
    {

        scaleY = transform.localScale.y;
        positonY = scaleY / 2 + 0.38f;
        scaleY = soapCounter;
        transform.position = new Vector3(transform.position.x, positonY, transform.position.z);
        transform.DOScaleY(scaleY, 2f);
        //transform.localScale = new Vector3(transform.localScale.x, scaleY, transform.localScale.z);

         
        finisObject.transform.position = new Vector3(SoapyBehaviour.instance.cubes[0].transform.position.x, finisObject.transform.position.y, finisObject.transform.position.z);
        //LastStackSoap = SoapyBehaviour.instance.cubes[SoapyBehaviour.instance.cubes.Count - 1];
        cube0 = SoapyBehaviour.instance.cubes[0];
        finishCube_Distance = Vector3.Distance(cube0.transform.position, finisObject.transform.position);
        
        if (finishCube_Distance <= SoapyBehaviour.instance.cubes.Count+4)
        {
            Movement.mov_instance.enabled = false;
            Vector3 cube0Pos = SoapyBehaviour.instance.cubes[0].transform.localPosition;
            SoapyBehaviour.instance.cubes[0].transform.localPosition = new Vector3(0, cube0Pos.y, cube0Pos.z);
            SoapyBehaviour.instance.cubes[0].GetComponent<BoxCollider>().isTrigger = false;
            StartCoroutine(FinishMovement());
        }

       
        
           
       
       
    }
    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.tag == "Soapy")
        {
            soapCounter += 0.5f;
            collision.gameObject.SetActive(false);
            AudioSource.PlayClipAtPoint(Finish_Cube_Collision_Sound, transform.position);
            obstacle_Coll_Control = true;
        }
    }

    IEnumerator FinishMovement()
    {
        
        yield return new WaitForSeconds(2f);
        Movement.mov_instance.enabled = true;
        Movement.mov_instance.Update();
        Movement.mov_instance.swipeSpeed = 0;
        
        cam.GetComponent<camFollow>().enabled = false;
        Vector3 finishObjePos = new Vector3(transform.position.x, scaleY+2, transform.position.z-13);
        cam.transform.DOMove(finishObjePos, 4f);
        yield return new WaitForSeconds(6f);
        winnScreen.SetActive(true);
    }




}
