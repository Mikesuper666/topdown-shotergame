using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    Vector3 velocity;
    private Rigidbody playerRigidbody;
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }
    public void Move(Vector3 _velocity)
    {
        velocity = _velocity;
    }

    public void LookAt(Vector3 lookPoint)
    {
        Vector3 heightCorretPoint = new Vector3(lookPoint.x, transform.position.y, lookPoint.z);
        transform.LookAt(heightCorretPoint);
    }

    void FixedUpdate()
    {
        playerRigidbody.MovePosition(playerRigidbody.position + velocity * Time.fixedDeltaTime);
    }
}
