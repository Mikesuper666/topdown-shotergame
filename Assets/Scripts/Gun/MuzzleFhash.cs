using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleFhash : MonoBehaviour
{
    ParticleSystem flash;
    void Start()
    {
        flash = GetComponent<ParticleSystem>();
        flash.Play();
        Destroy(gameObject, .5f);
    }
}
