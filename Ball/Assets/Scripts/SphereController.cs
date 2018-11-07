using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour {

    int layer = -1;
    Rigidbody rigidBody;

    public void Start()
    {
        rigidBody = transform.GetComponent<Rigidbody>();
    }

    void Update () {
        ChangePosition();
        ChangeLayer();
    }

    void ChangeLayer()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            bool isSomething = Physics.Raycast(transform.position, Vector3.forward, 2f);
            if (!isSomething)
            {
                layer = 1;
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            bool isSomething = Physics.Raycast(transform.position, Vector3.back, 2f);
            if (!isSomething)
            {
                layer = -1;
            }
        }

        float delta = (layer) - rigidBody.position.z;
        Vector3 velocity = rigidBody.velocity;
        velocity.z = delta * 3;
        rigidBody.velocity = velocity;
    }

    void ChangePosition()
    {
        Vector3 vector = Vector3.zero;
        float speed = 10f;


        if (Input.GetKey(KeyCode.LeftArrow))
        {
            vector = Vector3.forward;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            vector = -Vector3.forward;
        }
        rigidBody.AddTorque(vector * speed);
    }
}
