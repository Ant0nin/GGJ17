using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class RubbishDispenser : MonoBehaviour
{
    public float tempo = 2f;
    public RubbishController rubbishPrefab;

    void Start()
    {
        InvokeRepeating("SpawnRubbish", 0f, tempo);
    }

    private void SpawnRubbish()
    {
        GameObject.Instantiate<RubbishController>(rubbishPrefab, transform.position, transform.rotation);
    }
}
