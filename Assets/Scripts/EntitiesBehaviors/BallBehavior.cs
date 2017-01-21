using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : TemporaryEntity {


    private WavesProperties wavesProps;
    private IEnumerator coroutineKillMe;

    protected override void Start () {
        base.Start();
        wavesProps = WavesProperties.getInstance();
    }

    void Update()
    {
        Vector2 pos = new Vector2(transform.position.x, transform.position.y);
        bool isInWater = wavesProps.isPointInWater(pos);
        if (!isInWater)
            DestroyImmediate(this.gameObject);
    }
}
