using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour {

    public Vector2 startForce = new Vector2(0, -100);

	void Start () {
        Rigidbody2D rg = GetComponent<Rigidbody2D>();
        rg.AddForce(startForce);
	}
}
