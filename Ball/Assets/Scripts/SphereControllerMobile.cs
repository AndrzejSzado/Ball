using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereControllerMobile : MonoBehaviour {

    int layer = -1;
    Rigidbody rigidBody;

    public void Start()
    {
        if(Application.platform != RuntimePlatform.Android)
        {
            this.enabled = false; 
        }

        rigidBody = transform.GetComponent<Rigidbody>();
    }

    void Update () {
        ChangePosition();
        ChangeLayer();
        updateControllers();
    }

    Vector3 gestureStartPosition;
    Vector3 gestureDelta;

    void updateControllers()
    {
        if (Input.GetMouseButtonDown(0))
        {
            gestureStartPosition = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            gestureDelta = gestureStartPosition - Input.mousePosition;
            gestureDelta /= Screen.dpi;
        }
        else
        {
            gestureDelta = Vector3.zero;
        }
    }

    void ChangeLayer()
    {
        if (gestureDelta.y < -0.5f)
        {
            bool isSomething = Physics.Raycast(transform.position, Vector3.forward, 2f);
            if (!isSomething)
            {
                layer = 1;
            }
        }
        if (gestureDelta.y > 0.5f)
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
        Vector3 vector = Vector3.forward;
        float speed = 40f;
        vector *= gestureDelta.x;

        rigidBody.AddTorque(vector * speed);
    }
}
