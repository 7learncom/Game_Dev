using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarsiMaker : MonoBehaviour
{
    [TextArea(8, 8)][SerializeField] private string input;
    [TextArea(8, 8)][SerializeField] private string output;

    public void ConvertToFarsi()
    {
        output = input.faConvert();
    }
}
