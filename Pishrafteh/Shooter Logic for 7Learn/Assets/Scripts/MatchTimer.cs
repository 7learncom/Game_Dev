using UnityEngine;

[System.Serializable]
public class Clock
{
    public float seconds;
    public float minutes;
    public float hours;
}

[System.Serializable]
public class MatchTimer
{
    [SerializeField] public Clock timer { get; private set; }

    public void Countdown()
    {
        //if (timer <= 0)
           // return;

        //timer -= Time.deltaTime;
    }

    public void Zero()
    {
        //timer = 0;
    }

    public void SetTime(Clock time)
    {
        timer = time;
    }
}
