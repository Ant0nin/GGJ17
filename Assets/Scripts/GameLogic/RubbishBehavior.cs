using UnityEngine;
using System.Collections;

public class RubbishBehavior : TemporaryEntity
{
    public BallBehavior ballPrefab;

    private Rigidbody2D rb;

    protected override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody2D>();
    }

    protected void Update()
    {
        Vector2 waterForceToOutdoor = WavesCalculator.evalForceToOutdoor(transform.position);
        Vector2 waterHorizontalForce = WavesCalculator.evalHorizontalForce(transform.position);

        rb.AddForce(waterForceToOutdoor);
        if (rb.velocity.x < waterHorizontalForce.x)
            rb.AddForce(waterHorizontalForce);
    }
    
}
