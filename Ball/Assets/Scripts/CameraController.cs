using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform sphere;

	void Update () {
        Rigidbody rigidbody = sphere.GetComponent<Rigidbody>();

        Vector3 cameraStartPosition = new Vector3(0, 3f, -5f);
        float velocity = rigidbody.velocity.sqrMagnitude;
        cameraStartPosition *= 1.5f + velocity / 50f;

        Vector3 newCameraPosition = sphere.position + cameraStartPosition;
        transform.position = Vector3.Lerp(transform.position, newCameraPosition, Time.deltaTime);
        transform.LookAt(sphere);
	}
}
