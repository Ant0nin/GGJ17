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
        return amplitude * Mathf.Cos(pulsation + X) + Mathf.Sin(pulsation * X + phase);
    }

    public Vector2 evalForceToApply(Vector2 point)
    {
        if (isPointInWater(point))
        {
            float tangent = evalTangentFromX(point.x);
            return new Vector2(tangent, 1.0f).normalized;
        }
        else
            return Vector2.zero;
    }

    public float evalTangentFromX(float X)
    {
        float Y = evalYFromX(X);
        float derivative_X = evalSlopeFromX(X);

        if (derivative_X == 0)
            return 0f;
        else
            return Y / derivative_X;
    }
}
