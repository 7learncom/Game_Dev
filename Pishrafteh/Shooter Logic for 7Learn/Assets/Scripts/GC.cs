using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public enum GunType { Pistol, Shotgun, Rifle, Sniper }

public class GC : MonoBehaviour
{
    [SerializeField] private MatchTimer matchTime;
    [SerializeField] private Clock defaultTime;
    [SerializeField] private GunType gunType;
    
    [Header("UIs")]
    [SerializeField] private Text timeText;
    [SerializeField] private Text coinText;

    [Header("Sounds")]
    [SerializeField] private AudioSource shootingSound;
    [SerializeField] private AudioSource colletSound;

    [SerializeField] private GameObject[] player;

    private void Start()
    {

        matchTime.SetTime(defaultTime);
    }

    private void Update()
    {
        matchTime.Countdown();
        Clock clock = new Clock { hours = 1, minutes = 2, seconds = 25 };
        matchTime.SetTime(clock);
        if (Input.GetKeyDown(KeyCode.Z))
            matchTime.SetTime(defaultTime);
    }
}
