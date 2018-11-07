using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Direction : MonoBehaviour {

    public bool leftDirection = true;
    public void OnTriggerStay(Collider other)
    {
        GameObject thing = other.gameObject;
        Rigidbody rigidbody = thing.GetComponent<Rigidbody>();
        Vector3 velocity = rigidbody.velocity;
        
        if (leftDirection)
        {
            velocity.x = -5f;
        }
        else
        {
            velocity.x = 5f;
        }

        rigidbody.velocity = velocity;
    }
}
