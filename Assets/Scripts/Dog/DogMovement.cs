using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogMovement : MonoBehaviour
{

    public float maxAngularVelocity = 50f;

    private Transform player;
    private Vector3 retreatDestination;
    //private PlayerHealth playerHealth;
    private DogHealth dogHealth;
    private UnityEngine.AI.NavMeshAgent navMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        dogHealth = GetComponent<DogHealth>();
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        GameObject[] retreatPoints = GameObject.FindGameObjectsWithTag("DogSpawnPoint");
        int retreatPointIndex = Random.Range(0, retreatPoints.Length);
        retreatDestination = retreatPoints[retreatPointIndex].transform.position;

        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.maxAngularVelocity = maxAngularVelocity;
    }

    // Update is called once per frame
    void Update()
    {
        if (dogHealth.currentHealth > 0)
        {
            navMeshAgent.SetDestination(player.position);
        } else
        {
            tag = "Friend";
            navMeshAgent.SetDestination(retreatDestination);
        }
    }
}
