using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBehavior : MonoBehaviour {
	
	void OnTriggerStay2D(Collider2D other)
    {
        GameObject go = other.gameObject;
        if (go.tag == "Rubbish")
        {
            Rigidbody2D rb = go.GetComponent<Rigidbody2D>();
            rb.AddForce(Vector2.up * 9.4f);
        }
    }
}
