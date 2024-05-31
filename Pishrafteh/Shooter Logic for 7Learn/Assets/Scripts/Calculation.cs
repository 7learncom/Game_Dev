using UnityEngine;

public static class Calculation
{
    public const float PI = 3.14f;

    public static float GetP()
    {
        float p = 45;
        p += 2;
        return p;
    }

    public static float GhadreMotalgh(float num)
    {
        if (num < 0)
            return -num;
        else
            return num;
    }
}
