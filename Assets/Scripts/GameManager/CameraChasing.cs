using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChasing : MonoBehaviour
{
    Transform playerT;
    void Start()
    {
        playerT = FindObjectOfType<Player>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerT != null )
            transform.position = new Vector3(playerT.position.x, transform.position.y, playerT.position.z - 5);
    }
}
