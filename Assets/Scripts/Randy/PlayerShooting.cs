using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    private ParticleSystem hoseParticles;
    private bool firing;

    // Start is called before the first frame update
    void Start()
    {
        hoseParticles = GetComponentInChildren<ParticleSystem>();
        firing = false;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHoseLevel();
    }

    private void UpdateHoseLevel()
    {
        ParticleSystem.MainModule mainModule = hoseParticles.main;
        ParticleSystem.EmissionModule emissionModule = hoseParticles.emission;
        ParticleSystem.CollisionModule collisionModule = hoseParticles.collision;

        if (Input.GetButton("Fire1"))
        {
            // increase speed and rate of hose particles and enable collisions
            mainModule.startSpeed = 60;
            emissionModule.rateOverTime = 300;
            collisionModule.enabled = true;
        } else
        {
            // decrease speed and rate of hose particles
            mainModule.startSpeed = 3;
            emissionModule.rateOverTime = 20;
            collisionModule.enabled = false;
        }
    }
}
