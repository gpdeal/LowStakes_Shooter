using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 6;

    private Vector3 movementVec;
    private Rigidbody playerRigidBody;
    private int floorMask;
    private float camRayLength = 100;

    private readonly string HORIZONTAL_MOVE_AXIS = "Horizontal";
    private readonly string VERTICAL_MOVE_AXIS = "Vertical";

    // Start is called before the first frame update
    void Start()
    {
        floorMask = LayerMask.GetMask("Floor");
        playerRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxisRaw(HORIZONTAL_MOVE_AXIS);
        float verticalInput = Input.GetAxisRaw(VERTICAL_MOVE_AXIS);

        Move(horizontalInput, verticalInput);
        Turning();
    }

    private void Move(float horizontalInput, float verticalInput)
    {
        movementVec.Set(horizontalInput, 0, verticalInput);
        movementVec = movementVec.normalized * speed * Time.fixedDeltaTime;
        playerRigidBody.MovePosition(transform.position + movementVec);
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
}
