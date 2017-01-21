using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavesDisplayer : MonoBehaviour {

    private Material mat;
    private WavesProperties props;
	
    void Start()
    {
        mat = GetComponent<Renderer>().material;
        props = WavesProperties.getInstance();
    }
    
	void Update ()
    {
        mat.SetFloat("_Amplitude", props.amplitude);
        mat.SetFloat("_Pulsation", props.pulsation);
        mat.SetFloat("_Phase", props.phase);
	}
}
