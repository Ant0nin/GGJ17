using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavesProperties
{
    public float amplitude;
    public float pulsation;
    public float phase;

    private WavesProperties()
    {
        // TODO : default values
    }

    public static WavesProperties instance;
    public static WavesProperties getInstance()
    {
        if (instance == null)
            instance = new WavesProperties();
        return instance;
    }

    public float evalYFromX(float X)
    {
        return amplitude* Mathf.Sin(pulsation * X + phase) + 0.5f;
    }

    public bool isPointInWater(Vector2 point)
    {
        float thresholdY = evalYFromX(point.x);

        if (point.y > thresholdY)
            return false;
        else
            return true;
    }

    public float getSlopeFromX(float X)
    {
        return amplitude * Mathf.Cos(pulsation + X) + Mathf.Sin(pulsation * X + phase);
    }

    public Vector2 getForceToApply(Vector2 point)
    {
        if (isPointInWater(point))
        {
            float slope = getSlopeFromX(point.x);
            if (slope > 0)
                return Vector2.up; // TODO
            else if (slope > 0)
                return Vector2.up; // TODO
            else
                return Vector2.up;
        }
        else
            return Vector2.zero;
    }
}
