using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    public float moveSpeed;
    public float groundDrag;
    public float waterDrag;

    public float height;
    public LayerMask ground;
    bool onGround;

    bool underwater;

    public Transform orientation;
    float moveX;
    float moveZ;
    Vector3 movementDir;

    Rigidbody Rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
        Rigidbody.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        onGround =  Physics.Raycast(transform.position, Vector3.down, height * .5f + .2f, ground);

        moveX = Input.GetAxisRaw("Horizontal");
        moveZ = Input.GetAxisRaw("Vertical");

        SpeedControl();

        if (onGround)
            Rigidbody.drag = groundDrag;
        else
            Rigidbody.drag = 0;

        Swim();
    }
    private void FixedUpdate()
    {
        movementDir = orientation.forward * moveZ + orientation.right * moveX;
        Rigidbody.AddForce(movementDir.normalized * moveSpeed * 10f, ForceMode.Force);
    }
    private void SpeedControl()
    {
        Vector3 horizVel = new Vector3(Rigidbody.velocity.x, 0f, Rigidbody.velocity.z);
        if (horizVel.magnitude > moveSpeed)
        {
            Vector3 velLimit = horizVel.normalized * moveSpeed;
            Rigidbody.velocity = new Vector3(velLimit.x, Rigidbody.velocity.y, velLimit.z);
        }
    }
    private void Swim()
    {
        if (transform.position.y < 75)
        {
            Rigidbody.useGravity = false;
            if (Input.GetKey(KeyCode.Space))
                Rigidbody.velocity = new Vector3(Rigidbody.velocity.x, 5f, Rigidbody.velocity.z);
            else if (Input.GetKey(KeyCode.LeftShift))
                    Rigidbody.velocity = new Vector3(Rigidbody.velocity.x, -5f, Rigidbody.velocity.z);
            Vector3 swimSpeed = new Vector3(Rigidbody.velocity.x, Rigidbody.velocity.y, Rigidbody.velocity.z);
            if (swimSpeed.magnitude > 0f)
            {
                Vector3 swimDrag = swimSpeed * waterDrag;
                Rigidbody.velocity = new Vector3(swimDrag.x, swimDrag.y, swimDrag.z);
            }
        }
        else
            Rigidbody.useGravity = true;
    }
}
