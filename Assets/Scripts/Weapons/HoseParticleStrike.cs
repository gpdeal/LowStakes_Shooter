using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoseParticleStrike : MonoBehaviour
{

    public ParticleSystem part;
    public List<ParticleCollisionEvent> collisionEvents;
    public float appliedTorque;
    
    
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
        //int numCollisionEvents = part.GetCollisionEvents(other, collisionEvents);

        Rigidbody otherRb = other.GetComponent<Rigidbody>();
        Vector3 torqueVec = new Vector3(0, appliedTorque, 0);

        //for (int i = 0; i < numCollisionEvents; i++)
        //{
        //if (otherRb)
        //{
                otherRb.AddTorque(torqueVec, ForceMode.VelocityChange);
            //}
        //}
    }
}
