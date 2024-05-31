using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField] private GameObject zombie;
    [SerializeField] private int round = 1;
    [SerializeField] private float roundTime = 20;
    [SerializeField] private int baseRoundZombies = 5;
    [SerializeField] private int zombiesPerRound = 4;
    [SerializeField] private Transform[] spawnPoints;

    private float spawnedTime;

    private void Update()
    {
        float spawnRatio = roundTime / ((zombiesPerRound * round) + baseRoundZombies);

        if (Time.time >= spawnedTime + spawnRatio)
        {
            SpawnZombie();
            spawnedTime = Time.time;
        }

        if (Time.time > roundTime * round)
            NextRound();
    }

    private void NextRound()
    {
        baseRoundZombies += zombiesPerRound;
        round++;
    }

    private void SpawnZombie()
    {
        var z = Instantiate(zombie, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
        z.transform.GetChild(Random.Range(1, z.transform.childCount)).gameObject.SetActive(true);
    }
}
