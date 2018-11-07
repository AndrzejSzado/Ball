using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

    public Vector3 delta;
    Vector3 startPosition;
    Vector3 actualPosition;
    Vector3 endPosition;
    float change;
 
    void Start () {
        startPosition = transform.position;
	}
	
	void Update () {
        Rigidbody rigidbody = transform.GetComponent<Rigidbody>();
        float velocity = 50f / delta.sqrMagnitude;
        change = (Mathf.Sin(Time.timeSinceLevelLoad * velocity) + 1f) / 2f;
        actualPosition = rigidbody.position;
        rigidbody.position = Vector3.Lerp(startPosition, startPosition + delta, change);
        endPosition = rigidbody.position;
    }

#if UNITY_EDITOR
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.grey;
        if(UnityEditor.Selection.activeTransform == transform)
        {
            Gizmos.color = Color.yellow;
        }

        Vector3 ghostPosition = transform.position + delta;
        Vector3 ghostSize = transform.rotation * transform.localScale * 2f;

        Gizmos.DrawWireCube(ghostPosition, ghostSize);
    }
#endif

    public void OnTriggerStay(Collider other)
    {
        GameObject thing = other.gameObject;
        float time = Time.deltaTime;
        if (thing.name == "sphere")
        {
            Rigidbody rigidbody = thing.GetComponent<Rigidbody>();
            rigidbody.position = rigidbody.position + (endPosition - actualPosition);
        }
    }
}
