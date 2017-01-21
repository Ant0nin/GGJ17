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

    private static WavesProperties instance;
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

    public float evalSlopeFromX(float X)
    {
        float slope = /*Mathf.Sin(pulsation * X + phase) +*/ amplitude * Mathf.Cos(pulsation + phase);
        //float slope = amplitude * Mathf.Cos(pulsation * X + phase);
        return slope;
    }

    public Vector2 evalForceToApply(Vector2 point)
    {
        if (isPointInWater(point))
        {
            float slope = evalSlopeFromX(point.x);
            return new Vector2(slope, 1.0f).normalized * 10f;
        }
        else
            return Vector2.zero;
    }
}
