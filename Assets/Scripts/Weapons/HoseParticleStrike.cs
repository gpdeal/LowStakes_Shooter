using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoseParticleStrike : MonoBehaviour
{

    public ParticleSystem part;
    public List<ParticleCollisionEvent> collisionEvents;
    public float appliedTorque;
    public float cleaningAmount = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        part = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.tag.Equals("Enemy"))
        {
            Rigidbody otherRb = other.GetComponent<Rigidbody>();
            Vector3 torqueVec = new Vector3(0, appliedTorque, 0);
            otherRb.AddTorque(torqueVec, ForceMode.VelocityChange);
            DogHealth dogHealth = other.GetComponent<DogHealth>();
            if (dogHealth) 
            {
                dogHealth.Clean(cleaningAmount);
            }
        }
    }
}
