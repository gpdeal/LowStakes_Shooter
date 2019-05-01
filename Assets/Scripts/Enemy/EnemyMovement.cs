using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    private Transform player;
    //private PlayerHealth playerHealth;
    //private EnemyHealth enemyHealth;
    private UnityEngine.AI.NavMeshAgent nav;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Debug.Log(player.name);
        //playerHealth = player.GetComponent <PlayerHealth> ();
        //enemyHealth = GetComponent <EnemyHealth> ();
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //if(enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
        //{
            nav.SetDestination(player.position);
        
        //}
        //else
        //{
        //    nav.enabled = false;
        //}
    }
}
