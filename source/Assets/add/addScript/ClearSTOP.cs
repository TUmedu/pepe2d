using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearSTOP : MonoBehaviour {

    public float timeOut;

    void Start()
    {
        StartCoroutine(FuncCoroutine());
    }

    IEnumerator FuncCoroutine()
    {
        while (true)
        {
            // Do anythings

            

            yield return new WaitForSeconds(timeOut);

            Application.LoadLevel("Menu2");
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
