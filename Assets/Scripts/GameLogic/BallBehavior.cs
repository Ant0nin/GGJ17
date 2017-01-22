using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : TemporaryEntity {

    public Vector2 initialForce = new Vector2(0f, -100f);

    protected override void Start()
    {
        base.Start();
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Vector2 pos = new Vector2(transform.position.x, transform.position.y);
        //Vector2 initialForce = WavesCalculator.evalDirToIndoor(pos) * initialForcePower;
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
