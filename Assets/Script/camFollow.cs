using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    void LateUpdate()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z - 10)+offset;
    }
}
