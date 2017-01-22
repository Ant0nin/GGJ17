using UnityEngine;
using System.Collections;

public class PollutingRubbishBehavior : RubbishBehavior
{
    public float tempo;
    public float spawnOffsetY;

    protected override void Start()
    {
        base.Start();
        InvokeRepeating("SpawnBall", 0f, tempo);
    }

    private void SpawnBall()
    {
        Vector3 spawnPosition = new Vector3(
            transform.position.x,
            transform.position.y - spawnOffsetY,
            transform.position.z
        );

        GameObject.Instantiate<BallBehavior>(ballPrefab, spawnPosition, transform.rotation);
    }
}
