using UnityEngine;

public class AngleClamp
{
    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360.0f)
        {
            angle += 360.0f;
        }
        else if (angle > 360.0f)
        {
            angle -= 360.0f;
        }
        return Mathf.Clamp(angle, min, max);
    }
}
