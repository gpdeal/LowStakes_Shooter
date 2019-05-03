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
        if (Input.GetButton("Fire1"))
        {
            // increase speed and rate of hose particles
            hoseParticles.startSpeed = 60;
            ParticleSystem.EmissionModule emission = hoseParticles.emission;
            emission.rateOverTime = 300;
        } else
        {
            // decrease speed and rate of hose particles
            hoseParticles.startSpeed = 3;
            ParticleSystem.EmissionModule emission = hoseParticles.emission;
            emission.rateOverTime = 20;
        }
    }
}
