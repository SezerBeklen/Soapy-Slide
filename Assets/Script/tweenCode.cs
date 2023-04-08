using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tweenCode : MonoBehaviour
{
    //public Transform start, end;
    public float actionDuration;
    private float timer = 0;
    private bool isTweening;
    public static tweenCode instance_tween;

    private void Awake()
    {
        if (instance_tween == null)
        {
            instance_tween = this;
        }
    }

    private void Start()
    {
        isTweening = true;
    }
    public IEnumerator Tween(Transform objtrans, Vector3 start, Vector3 endPos)
    {


        if (isTweening)
        {
            timer += Time.deltaTime;
            float percent = timer / actionDuration;
            objtrans.position=Vector3.Lerp(start, endPos, percent);
            if (timer >= actionDuration)
            {
                isTweening = false;
            }
            yield return null;
        }
        
    }

}
