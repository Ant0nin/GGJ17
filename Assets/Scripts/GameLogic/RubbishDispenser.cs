using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class RubbishDispenser : MonoBehaviour
{
    public float tempo = 5f;
    public Vector2 initialForce = new Vector2(0f, 0f); // TODO : ajust
    public RubbishBehavior rubbishPrefab;

    void Start()
    {
        InvokeRepeating("SpawnRubbish", 0f, tempo);
    }

    private void SpawnRubbish()
    {
        RubbishBehavior rub = GameObject.Instantiate<RubbishBehavior>(rubbishPrefab, transform.position, transform.rotation);
        rub.GetComponent<Rigidbody2D>().AddForce(initialForce);
    }
}
