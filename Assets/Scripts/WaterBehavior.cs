using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBehavior : MonoBehaviour {
	
	void OnTriggerEnter2D(Collider2D other)
    {
        GameObject go = other.gameObject;
        if (go.tag == "Rubbish")
        {
            Rigidbody2D rb = go.GetComponent<Rigidbody2D>();
            rb.AddForce(Vector2.up * 180f);
        }
    }
}
