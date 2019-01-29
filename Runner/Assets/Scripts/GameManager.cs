using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Player player;
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private GameOverPanel gameOverPanel;

    [SerializeField]
    private float score;
    // Start is called before the first frame update
    void Start()
    {
        player.onGameOver +=GameOver;
    }

    // Update is called once per frame
    void Update()
    {
        score = player.transform.position.z;
        PlayerPrefs.SetFloat("score", score);
        scoreText.text = player.transform.position.z.ToString("0");
    }

    private void GameOver(){
        
        var bestScore = PlayerPrefs.GetFloat("score");
        
        if(score>bestScore){
            bestScore = score;
            PlayerPrefs.SetFloat("score", score);
        }
        gameOverPanel.Init(score, bestScore);
    }   
}
