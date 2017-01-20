using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDestroyer : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject go = other.gameObject;
        if (go.tag == "Ball")
        {
            Destroy(go);
        }
    }
}
