using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameController : MonoBehaviour
{
	public int currentLevel;
	public int score = 5;
	public int maxScore;
	[SerializeField] private float timer;
	public bool isGameFinished;

	public GameObject win_Dialuge;
	public GameObject lose_Dialuge;
	public Text timer_Text;
	public Text score_Text;
	public Image scoreProgBar;

	void Update()
	{
		if (isGameFinished == false)
		{
			Timer();

			if (score >= maxScore)
				Win();

			UpdateUI();
		}
	}

	public void Timer()
	{
		timer += Time.deltaTime;
	}

	private void UpdateUI()
	{
		timer_Text.text = timer.ToString("0.0");
		score_Text.text = score.ToString();
		scoreProgBar.fillAmount = ((float)score / (float)maxScore); 
	}

	void Win()
	{
		Debug.Log(timer);
		win_Dialuge.SetActive(true);
		isGameFinished = true;
	}

	public void Lose()
	{
		lose_Dialuge.SetActive(true);
		isGameFinished = true;
	}

	public void NextLevel()
	{
		SceneManager.LoadScene(currentLevel + 1);
	}

	public void Restart()
	{
		SceneManager.LoadScene(currentLevel);
	}
}
