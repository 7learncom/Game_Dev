using UnityEngine;
using UnityEngine.UI;

public class GC : MonoBehaviour
{
    [SerializeField] private string result;
    [SerializeField] private int level = 1;
    [SerializeField] private Transform levelResultShowerImages;
    [SerializeField] private Transform levelKeysParent;
    [SerializeField] private Transform levelParent;

    private string levelWord;
    private GameObject levelObj;

    private void Start()
    {
        if (PlayerPrefs.HasKey("level"))
            level = PlayerPrefs.GetInt("level");

        LoadLevel();
    }

    private void LoadLevel()
    {
        levelObj = levelParent.GetChild(level - 1).gameObject;
        levelObj.SetActive(true);
        levelWord = levelObj.GetComponent<LevelManager>().levelWord;
        levelResultShowerImages = levelObj.GetComponent<LevelManager>().levelResultShowerImages;
        levelKeysParent = levelObj.GetComponent<LevelManager>().levelKeysParent;
    }

    public void SetKeyWord(string key)
    {
        int resultLength = result.Length;
        if (resultLength >= levelResultShowerImages.childCount)
            return;
        levelResultShowerImages.GetChild((result.Length)).GetChild(0).gameObject.GetComponent<Text>().text = key;
        result += key;
    }

    public void CheckoutResult()
    {
        if (result == levelWord)
        {
            Debug.Log("yes");
            NextLevel();
        }
        else
            Debug.Log("no");
    }

    public void ResetLevel()
    {
        for (int i = 0; i < levelResultShowerImages.childCount; i++)
            levelResultShowerImages.GetChild(i).GetChild(0).gameObject.GetComponent<Text>().text = string.Empty;

        for (int i = 0; i < levelKeysParent.childCount; i++)
            levelKeysParent.GetChild(i).gameObject.GetComponent<Button>().interactable = true;

        result = string.Empty;
    }

    private void NextLevel()
    {
        ResetLevel();
        levelObj.SetActive(false);
        level++;
        PlayerPrefs.SetInt("level", level);
        LoadLevel();
    }
}
