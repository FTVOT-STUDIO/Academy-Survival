using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public Transform[] spawnPoint;
    public SpawnDate[] spawnDates;
    public float levelTime;

    int level;
    float timer;

    private void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>();
        levelTime = GameManager.Instance.maxGameTime / spawnDates.Length;
    }


    void Update()
    {
        if (!GameManager.Instance.isLive)
            return;

        timer += Time.deltaTime;
        level = Mathf.Min(Mathf.FloorToInt(GameManager.Instance.gameTime / levelTime), spawnDates.Length - 1); 

        if (timer > spawnDates[level].spawnTime)
        {
            timer = 0;
            Spawn();
        }

        void Spawn()
        {
            GameObject enemy = GameManager.Instance.pool.Get(0);
            enemy.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;
            enemy.GetComponent<Enemy>().Init(spawnDates[level]);
        }
    }
}


[System.Serializable]
public class SpawnDate
{
    public float spawnTime;
    public int spriteType;
    public int health;
    public float speed;
}