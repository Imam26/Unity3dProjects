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
    private GamePanel gamePanel;

    [SerializeField]
    private float score;

    private float playerStartPosZ;
    // Start is called before the first frame update
    void Start()
    {
        player.onGameOver +=GameOver;
        player.onWin +=PlayerWin;
        playerStartPosZ = player.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        score  = player.transform.position.z - playerStartPosZ;
        PlayerPrefs.SetFloat("score", score);
        scoreText.text = (player.transform.position.z-playerStartPosZ).ToString("0");
    }

    private void GameOver(){
        
        var bestScore = PlayerPrefs.GetFloat("score");
        
        if(score>bestScore){
            bestScore = score;
            PlayerPrefs.SetFloat("score", score);
        }
        gamePanel.Init(false, "Game Over!", score, bestScore);
    }

    private void PlayerWin(){
        
        var bestScore = PlayerPrefs.GetFloat("score");
        
        if(score>bestScore){
            bestScore = score;
            PlayerPrefs.SetFloat("score", score);
        }
        gamePanel.Init(true, "You win!!!", score, bestScore);
    }   
}
