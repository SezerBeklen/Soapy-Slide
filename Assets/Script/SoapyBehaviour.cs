using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class SoapyBehaviour : MonoBehaviour
{
    public static SoapyBehaviour instance;
    public List<GameObject> cubes = new List<GameObject>();
    public AudioClip collectSfx;
    public AudioClip ObstacleCollisionSfx;
    private float movementDelay;
     
    

    private void Start()
    {
        movementDelay = 0.13f;
        DOTween.SetTweensCapacity(7812, 50);
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    
    private void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            MoveListElements();
        }
        else 
        {
            
                MoveOrigin();
        }

    


    }
    public void StackSoapy(GameObject other, int index)
    {
        other.transform.parent = transform;
        Vector3 newPos= cubes[index].transform.localPosition;
        newPos.z += 1;
        other.transform.localPosition = newPos;
        cubes.Add(other);
       // StartCoroutine(MakeObjectsBigger());
    }
 

   /* private IEnumerator MakeObjectsBigger()
    {
        for (int i = cubes.Count - 1; i > 1; i--) 
        {

            int indexCoroutine = i;
            Vector3 scale = new Vector3(1000, 1000, 1000);
            
            //scale *= 1.5f;


            //cubes[indexCoroutine].transform.DOScale(scale, 0.1f).OnComplete(() =>
            //cubes[indexCoroutine].transform.DOScale(new Vector3(1000, 1000, 1000), 0.1f));
            
            yield return new WaitForSeconds(0.05f);
           

        }

    }*/

    private void MoveListElements()
    {
        for (int i = 1; i < cubes.Count; i++)
        {
           
            Vector3 pos = cubes[i].transform.localPosition;
            pos.x = cubes[i - 1].transform.localPosition.x;
            cubes[i].transform.DOLocalMove(pos, movementDelay);
        }
    }


    public void MoveOrigin()
    {

        for (int i = 1; i < cubes.Count; i++)
        {
            Vector3 pos = cubes[i].transform.localPosition;
            pos.x = cubes[0].transform.localPosition.x;
            cubes[i].transform.DOLocalMove(pos, 0.90f);

            Vector3 poss = cubes[i].transform.localPosition;
            poss.x = cubes[i - 1].transform.localPosition.x;
            cubes[i].transform.DOLocalMove(poss, movementDelay);
        }
     

    }
   
    public void SfxPlay(GameObject obj)
    {
        AudioSource.PlayClipAtPoint(collectSfx, obj.transform.position,1);
        
    }
    public void SfxObstaclePlay(GameObject obj)
    {
        AudioSource.PlayClipAtPoint(ObstacleCollisionSfx, obj.transform.position, 1);

    }

     


}
