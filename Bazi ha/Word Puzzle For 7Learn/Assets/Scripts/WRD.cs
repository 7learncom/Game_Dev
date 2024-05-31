using UnityEngine;
using UnityEngine.UI;

public class WRD : MonoBehaviour
{
    private const string glyphs = "ضصثقفغعهخحجچپشسیبلاتنمکگظطزرذدئوژ";
    [SerializeField] private string targetWord;
    [SerializeField] private Transform keyParents;

    public void Execute()
    {
        for (int i = 0; i < keyParents.childCount; i++)
        {
            if (i <= (targetWord.Length - 1))
                keyParents.GetChild(i).GetChild(0).gameObject.GetComponent<Text>().text = targetWord[i].ToString();
            else
            {
                keyParents.GetChild(i).GetChild(0).gameObject.GetComponent<Text>().text = glyphs[Random.Range(0, glyphs.Length)].ToString();
            }
        }

        Transform[] keyTemps = new Transform[keyParents.childCount];
        for (int i = 0; i < keyTemps.Length; i++)
            keyTemps[i] = keyParents.GetChild(i);

        for (int i = 0; i < keyParents.childCount; i++)
            keyTemps[i].SetSiblingIndex(Random.Range(0, keyParents.childCount));
    }
}
