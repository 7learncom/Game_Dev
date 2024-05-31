using UnityEngine;

public class Test : MonoBehaviour
{
    private void Start()
    {
        var ghad = 1.80f;
        HeightCalc(ghad);
    }

    private void HeightCalc(int ghad)
    {
        int a = ghad + 2;
        Debug.Log("ertefaye mored niaz " + ghad + " hast");
    }

    private void HeightCalc(float ghad)
    {
        float a = ghad + 2;
        Debug.Log("ertefaye mored niaz " + ghad + " hast");
    }

    private void HeightCalc(double ghad)
    {
        double a = ghad + 2;
        Debug.Log("ertefaye mored niaz " + ghad + " hast");
    }

    private void HeightCalc(string ghad)
    {
        float a = float.Parse(ghad) + 2;
        Debug.Log("ertefaye mored niaz " + ghad + " hast");
    }
}