using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float swipeSpeed;
    public float moveSpeed;
    public GameObject tapTo_Play;
    private Camera cam;

    public static Movement mov_instance;

    private void Awake()
    {
        if(mov_instance == null)
        {
            mov_instance = this;
        }
    }

    void Start()
    {
        cam = Camera.main;
        moveSpeed = 0;
        tapTo_Play.SetActive(true);
        swipeSpeed = 1;
    }

    
    public void Update()
    {
        transform.position += Vector3.forward * moveSpeed * Time.deltaTime;
        if (Input.GetButton("Fire1"))
        {
              Move();
            moveSpeed = 5;
            tapTo_Play.SetActive(false);

        }
    }




    private void Move()
    {
          Vector3 mousePos = Input.mousePosition;
          mousePos.z = cam.transform.localPosition.z;
          

          Ray ray = cam.ScreenPointToRay(mousePos);
          RaycastHit hit;
          if(Physics.Raycast(ray,out hit, 100f))
          {
              GameObject firstCube = SoapyBehaviour.instance.cubes[0];
              Vector3 hitVec = hit.point;
              hitVec.y = firstCube.transform.localPosition.y;
              hitVec.z = firstCube.transform.localPosition.z;
              hitVec.x=Mathf.Clamp(hitVec.x, -1.9f, 1.9f);
              firstCube.transform.localPosition = Vector3.MoveTowards(firstCube.transform.localPosition, hitVec,  swipeSpeed);
           
            
          }

          
       


    }
}
