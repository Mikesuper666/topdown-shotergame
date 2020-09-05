using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public enum FireMode { Auto, Burst, Single };
    public FireMode fireMode;

    public Transform[] projectileSpawn;
    public Projectile projectile;
    public float msBetweenProjectile = 100f;
    public float muzzleVelocity = 35;
    public int burstCount;

    public Transform shell;
    public ParticleSystem flash;
    public Transform shellEjection;

    float nextShotTime;

    bool triggerReleasedSinceLastShot;
    int shotsRemaingInBurst;

    private void Start()
    {
        shotsRemaingInBurst = burstCount;
    }

    void Shoot()
    {
        if (Time.time > nextShotTime)
        {
            if (fireMode == FireMode.Burst)
            {
                if(shotsRemaingInBurst == 0)
                {
                    return;
                }
                shotsRemaingInBurst--;
            }
            else if(fireMode == FireMode.Single)
            {
                if(!triggerReleasedSinceLastShot)
                {
                    return;
                }
            }

            for (int i = 0; i < projectileSpawn.Length; i++)
            {
                nextShotTime = Time.time + msBetweenProjectile / 1000;
                Projectile newProjectile = Instantiate(projectile, projectileSpawn[i].position, projectileSpawn[i].rotation) as Projectile;
                newProjectile.SetSpeed(muzzleVelocity);
            }
            Instantiate(shell, shellEjection.position, shellEjection.rotation);
            Instantiate(flash, projectileSpawn[0].position, projectileSpawn[0].rotation);
        }
    }

    public void OnTriggerHold()
    {
        Shoot();
        triggerReleasedSinceLastShot = false;
    }

    public void OnTriggerRelease()
    {
        triggerReleasedSinceLastShot = true;
        shotsRemaingInBurst = burstCount;
    }
}
