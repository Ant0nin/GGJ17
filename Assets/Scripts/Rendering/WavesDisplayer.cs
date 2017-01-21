using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavesDisplayer : MonoBehaviour {

    private Material mat;
	
    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }
    
	void Update ()
    {
        mat.SetFloat("_Amplitude", WavesProperties.amplitude);
        mat.SetFloat("_Pulsation", WavesProperties.pulsation);
        mat.SetFloat("_Phase", WavesProperties.phase);
	}
}
