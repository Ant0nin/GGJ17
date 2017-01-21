using UnityEngine;
using System.Collections;

public class WavesCalculator
{
    public static float evalYFromX(float X)
    {
        return WavesProperties.amplitude * Mathf.Sin(WavesProperties.pulsation * X + WavesProperties.phase) + 0.5f;
    }

    public static bool isPointInWater(Vector2 point)
    {
        float thresholdY = evalYFromX(point.x);

        if (point.y > thresholdY)
            return false;
        else
            return true;
    }

    public static float evalSlopeFromX(float X)
    {
        float slope = WavesProperties.amplitude * Mathf.Cos(WavesProperties.pulsation + WavesProperties.phase);
        return slope;
    }

    public static Vector2 evalForceToApply(Vector2 point)
    {
        if (isPointInWater(point))
        {
            float slope = evalSlopeFromX(point.x);
            return new Vector2(slope, 1.0f).normalized * WavesProperties.archimedeCoef;
        }
        else
            return Vector2.zero;
    }
}
