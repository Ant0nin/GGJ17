using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class RubbishDispenser : MonoBehaviour
{
    public float tempo = 2f;
    public RubbishBehavior rubbishPrefab;

    void Start()
    {
        InvokeRepeating("SpawnRubbish", 0f, tempo);
    }

    private void SpawnRubbish()
    {
        GameObject.Instantiate<RubbishBehavior>(rubbishPrefab, transform.position, transform.rotation);
    }
}
