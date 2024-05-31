using UnityEngine;
using UnityEngine.UI;

public class KeyWords : MonoBehaviour
{
    public void SetKeyWord()
    {
        GameObject.Find("GC").GetComponent<GC>().SetKeyWord(transform.GetChild(0).GetComponent<Text>().text);
        GetComponent<Button>().interactable = false;
    }
}
