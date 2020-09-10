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
        if (playerT != null)
        {
            float yTarget = transform.position.y;
            float speed = Mathf.Abs(Input.GetAxis("Horizontal")) + Mathf.Abs(Input.GetAxis("Vertical"));
            if (speed > 0.1f)
            {
                speed = Mathf.Clamp(speed, 0, 1f);
                yTarget += (speed*.2f);
                if (yTarget > 20)
                    yTarget = 20;
            }
            else
            {
                yTarget = Mathf.MoveTowards(yTarget, 14f, Time.deltaTime * 3f);
            }

            transform.position = new Vector3(playerT.position.x, yTarget, playerT.position.z - 5);
        }
    }
}
