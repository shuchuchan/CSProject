//This code is to hold all of the information of the player.
//The player and its equipment/values are the only things that should change throughout the levels

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{

   
   
    public GameObject[] Enemy;
    public GameObject[] BossOne;
    public GameObject[] BossTwo;
    public int currentEnemyCount = 0;
    public int currentKueiCount = 0;
    public int currentLiuCount = 0;
    public float enemyTimer;
    public float KueiTimer;
    public float LiuTimer;
    public int score;
    public bool inGame;
    
    // Start is called before the first frame update
    void Start()
    {
      score = 0;
      LiuTimer = KueiTimer = enemyTimer = (int) Math.Floor(Time.time);
    
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(score);
        Debug.Log(currentEnemyCount);
        spawnEnemy();
        spawnRoundTwo();
        spawnBossKuei();  
        spawnBossLiu();
        
             
    }

    private void spawningEnemy()
    {
        if (Time.time > enemyTimer)
        {
            PlayerPrefs.SetInt("score", score);
            enemyTimer += 1.75f;
            Vector3 position = new Vector3(Random.Range(-4f, 6f), 2, 0);
            Instantiate(Enemy[0], position, transform.rotation);
            currentEnemyCount++;
        }
    }

    private void spawningKuei()
    {
        if(Time.time > KueiTimer)
        {
            KueiTimer += 7f;
            Vector3 position = new Vector3(Random.Range(6f, 7f), 2, 0);
            Instantiate(BossOne[0], position, transform.rotation);
            currentKueiCount++;
        }
    }


    private void UpdateScore()
    {
        score = PlayerPrefs.GetInt("score", score);
            
    }

    private void spawnEnemy()
    {
        if(score <= 56 && currentEnemyCount <=13)
        {
            spawningEnemy();
        }
    }

    private void spawnBossKuei()
    {
        if(score == 60)
        {
            if(currentKueiCount == 0)
            {
                Vector3 position = new Vector3(Random.Range(6f, 7f), 2, 0);
                Instantiate(BossOne[0], position, transform.rotation);
                currentKueiCount++;
            }
        }
    }
    
    private void spawnRoundTwo()
    {
        if(score >= 74 && score < 82 && currentEnemyCount < 17)
        {
            spawningEnemy();
        }
    }

    private void spawnBossLiu()
    {
        if(score == 86)
        {
            if(currentLiuCount == 0)
            {
                Vector3 position = new Vector3(Random.Range(6f, 7f), 2, 0);
                Instantiate(BossTwo[0], position, transform.rotation);
                currentLiuCount++;
            }
        }
    }

    void checkWin()
    {
        if(score == 100)
        {
            SceneManager.LoadScene("gradeA");
        }
    }


}
