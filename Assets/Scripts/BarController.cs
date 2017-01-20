using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarController : MonoBehaviour {

    public float bounceForce = 10f;

	void Update ()
    {
        float offset = Input.GetAxis("Horizontal");

        transform.position = new Vector3(
            transform.position.x + offset,
            transform.position.y,
            transform.position.z
        );
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        GameObject go = other.gameObject;
        if(go.tag == "Ball")
        {
            Vector3 dir = -Vector3.Normalize(transform.position - go.transform.position);
            Rigidbody2D rb = go.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(dir.x, dir.y) * bounceForce;
        }
    }
}
