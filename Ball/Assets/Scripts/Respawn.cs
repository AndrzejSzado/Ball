using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {

    public GameObject ballPrefab;
    public Camera cameraPrefab;
    public Light lightPrefab;
    public GameObject gameOverBase;
    public GameObject levelName;

	void Start () {
        GameObject sphere = GameObject.Instantiate(ballPrefab);
        sphere.name = "sphere";
        sphere.transform.position = transform.position + Vector3.up * 2f;

        Camera camera = GameObject.Instantiate(cameraPrefab);
        CameraController cameraController = camera.GetComponent<CameraController>();
        cameraController.sphere = sphere.transform;

        Light light = GameObject.Instantiate(lightPrefab);
        light.color = Color.white;
        light.intensity = 0.8f;
        RenderSettings.ambientMode = UnityEngine.Rendering.AmbientMode.Flat;
        RenderSettings.ambientLight = Color.white * 0.7f;

        GameObject.Instantiate(gameOverBase);
        GameObject.Instantiate(levelName);
    }
}
