using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinusTrajectory : MonoBehaviour {

    public float amplitude = 5f;
    public float pulsation = 1f;
    public float phase = 0f;

	void Update () {
        float X = Mathf.Cos(Time.time) * 20f;
        float Y = amplitude * Mathf.Sin(pulsation * X + phase);
        transform.position = new Vector3(X, Y, transform.position.z);
	}
}
