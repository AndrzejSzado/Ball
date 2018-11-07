using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelItem : MonoBehaviour {

    public string levelName;
    public TextMesh textMesh;
    public GameObject okey;

	void Start ()
    {
        textMesh.text = levelName;
        if (PlayerPrefs.GetInt(levelName+"_finished", 0) == 0)
        {
            Destroy(okey);
        }
	}

    void OnMouseDown()
    {
        SceneManager.LoadScene(levelName);
    }
}
