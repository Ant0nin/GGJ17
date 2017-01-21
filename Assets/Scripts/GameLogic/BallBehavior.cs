using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : TemporaryEntity {

    protected override void Start()
    {
        base.Start();
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Vector2 pos = new Vector2(transform.position.x, transform.position.y);
        Vector2 initialForce = WavesCalculator.evalForceToApply(pos);
        rb.AddForce(initialForce);
    }

    void Update()
    {
        Vector2 pos = new Vector2(transform.position.x, transform.position.y);
        bool isInWater = WavesCalculator.isPointInWater(pos);
        if (!isInWater)
            DestroyImmediate(this.gameObject);
    }
}
