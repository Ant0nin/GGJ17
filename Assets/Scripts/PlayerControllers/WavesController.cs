using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavesController : MonoBehaviour
{
    public float amplitudeCoef = 0.2f;
    public float amplitudeOffset = 0.025f;

    public float pulsationCoef = 2f;
    public float pulsationOffset = 10f;

    public float phaseCoef = -20f;
    public float archimedeCoef = 100f;

	void Update () {
        // TODO : ajust
        WavesProperties.amplitude = /*Input.GetAxis("Vertical") **/ amplitudeCoef + amplitudeOffset;
        WavesProperties.pulsation = /*Input.GetAxis("Horizontal") **/ pulsationCoef + pulsationOffset;
        WavesProperties.phase = Time.time * phaseCoef;
        WavesProperties.horizontalWind = -phaseCoef;
        WavesProperties.archimedeCoef = archimedeCoef;
    }
}
