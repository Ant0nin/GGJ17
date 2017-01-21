using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavesController : MonoBehaviour {

    private WavesProperties props;

    void Start()
    {
        props = WavesProperties.getInstance();
    }

	void Update () {
        // TODO : ajust
        props.amplitude = Input.GetAxis("Vertical") * 0.2f + 0.025f;
        props.pulsation = Input.GetAxis("Horizontal") * 2f + 10f;
        props.phase = Time.time * -20f;
    }
}
