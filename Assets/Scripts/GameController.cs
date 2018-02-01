using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public GameObject hazards;
    public int hazardCount;
    public Vector3 spawnValues;
    public float spawnWait,startWait,waveWait;
    public GUIText scoreText,restartText,gameoverText;
    private bool restart, gameOver;
    private int score;
    void Start()
    { 
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves ());
        restart = false;
        gameOver = false;
        gameoverText.text = "";
        restartText.text = "";
        
        
    }
    void Update()
    {
        if(restart)
        {
            if(Input.anyKeyDown)
            {
#pragma warning disable CS0618 // O tipo ou membro é obsoleto
                Application.LoadLevel(Application.loadedLevel);//Instruction for restarting the current scene
#pragma warning restore CS0618 // O tipo ou membro é obsoleto
            }
        }
        
    }
    IEnumerator SpawnWaves ()
    {
        yield return new WaitForSeconds(startWait);
        while(true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazards, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);

            }
            yield return new WaitForSeconds(waveWait);
            if (gameOver)
            {
                restartText.text = "Press a button to restart!";
                restart = true;
                break;
            }

        }      

    }
    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();

    }

    void UpdateScore()
    {
        scoreText.text = "Score:" + score;
    }

    public void GameOver()
    {
        gameoverText.text = "Game Over!";
        gameOver = true;
    }
}
