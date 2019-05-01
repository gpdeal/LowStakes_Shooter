using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 6f;

    private Vector3 movement;
    private Rigidbody playerRigidBody;
    private int floorMask;
    private float camRayLength = 10000f;

    private Actions playerActions;


    // Start is called before the first frame update
    void Awake()
    {
        floorMask = LayerMask.GetMask("Floor");
        playerRigidBody = GetComponent<Rigidbody>();
        playerActions = GetComponent<Actions>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizMoveValue = Input.GetAxisRaw("Horizontal");
        float vertMoveValue = Input.GetAxisRaw("Vertical");

        Move(horizMoveValue, vertMoveValue);
        Turning();
        Animating(horizMoveValue, vertMoveValue);
    }

    void Move(float horizMoveValue, float vertMoveValue)
    {
        movement.Set(horizMoveValue, 0f, vertMoveValue);
        movement = movement.normalized * speed * Time.deltaTime;
        playerRigidBody.MovePosition(transform.position + movement);
    }

    void Turning()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit floorHit;

        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0f;

            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            playerRigidBody.MoveRotation(newRotation);
        }
    }

    void Animating(float horizMoveValue, float vertMoveValue)
    {
        if (horizMoveValue != 0 || vertMoveValue != 0)
        {
            playerActions.Run();
        } else
        {
            playerActions.Aiming();
        }
    }
}
