using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSpawner : MonoBehaviour {

    private GameObject targetCanvasGameobj;
    private int countGulls;
    private bool hasWon = false;

    void Start()
    {
        targetCanvasGameobj = GameObject.Find("UI_Menu");
    }

	void Update () {

        if(!hasWon)
        {
            countGulls = GameObject.FindGameObjectsWithTag("Gull").Length;
            if (countGulls == 0)
                hasWon = true;
        }

        if(hasWon)
        {
            targetCanvasGameobj.GetComponent<Canvas>().enabled = true;
            DestroyImmediate(this.gameObject);
        }
	}
}
