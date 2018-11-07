using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrystalTrigger : MonoBehaviour {

    public GameObject particles;

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name != "sphere")
        {
            return;
        }
        if(LeaveCrystals() == 1)
        {
            string levelName = SceneManager.GetActiveScene().name;
            PlayerPrefs.SetInt(levelName + "_finished", 1);
            SceneManager.LoadScene("menu");
        }
        else
        {
            Instantiate(particles, transform.position, Quaternion.identity);
            Destroy(gameObject, 0.1f);
        }
    }

    int LeaveCrystals()
    {
        CrystalTrigger[] crystals = Component.FindObjectsOfType<CrystalTrigger>();
        return crystals.Length;
    }
}
