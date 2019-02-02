using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GamePanel : MonoBehaviour
{
    [SerializeField]
    private Transform root;
    [SerializeField]
    private Text currentScoreText, bestScoreText, titleText;

    [SerializeField]
    private Button restartBtn, quitBtn, nextLevelBtn;

    public void Init(bool isActiveNextLevelBtn, string titleText, float currentScore, float bestScore){
        root.gameObject.SetActive(true);
        this.titleText.text = titleText;
        currentScoreText.text = "Your score: " + currentScore;
        bestScoreText.text = "Best score: " + bestScore;
        nextLevelBtn.gameObject.SetActive(isActiveNextLevelBtn);
    }
    // Start is called before the first frame update

    void Start()
    {
        restartBtn.onClick.AddListener(Restart);
        quitBtn.onClick.AddListener(Out);
        nextLevelBtn.onClick.AddListener(NextLevel);
        root.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnDestroy() {
        restartBtn.onClick.RemoveAllListeners(); 
        quitBtn.onClick.RemoveAllListeners(); 
        nextLevelBtn.onClick.RemoveAllListeners(); 
    }
    public void Restart () {
        Debug.Log("Restart");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Out () {
        Debug.Log("Out");
        SceneManager.LoadScene("Menu");
    }

    public void NextLevel () {

        try{
            string activeSceneName = SceneManager.GetActiveScene().name;
            int nextLevelNumber = int.Parse(activeSceneName.Substring(5))+1;

            SceneManager.LoadScene("Level"+nextLevelNumber.ToString());
        }
        catch(Exception ex){
            Debug.Log(ex.Message);
        }
               
    }
}
