using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverTrigger : MonoBehaviour {

    public void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.name == "sphere")
        {
            string levelName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(levelName);            
        }
    }
}
