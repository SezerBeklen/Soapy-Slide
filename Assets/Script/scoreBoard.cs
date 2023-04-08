using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class scoreBoard : MonoBehaviour
{

    public Material[] material;
    private int matCount;
    private new Renderer renderer;
  
    private void Start()
    {
        renderer = GetComponent<Renderer>();
        renderer.enabled = true;
        renderer.sharedMaterial = material[0];
        
    }
    
    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.CompareTag("finishcube"))
        {
            matCount = Random.Range(1, material.Length);
            renderer.sharedMaterial = material[matCount];
            Vector3 quadScale = new Vector3(4, 0.5f, 1.5f);
            quadScale *= 1.2f;
            transform.DOScale(quadScale, 0.1f).OnComplete(() =>
            transform.DOScale(new Vector3(4, 0.5f, 1.5f), 0.1f));
        }
    }
}
