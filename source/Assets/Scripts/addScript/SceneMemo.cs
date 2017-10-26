using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMemo : MonoBehaviour {


    //public static string sceneName = SceneManager.GetActiveScene().name;

        //リスタートの為に前のシーン保存
    public static string playScene()
    {
        return SceneManager.GetActiveScene().name;

    }

    // Use this for initialization
    void Start () {

         


    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
