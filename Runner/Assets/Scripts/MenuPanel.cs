using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuPanel : MonoBehaviour
{
    [SerializeField]
    private Transform root;
    [SerializeField]
    private Button playBtn, optionBtn, quitBtn;
    // Start is called before the first frame update
    void Start()
    {
        playBtn.onClick.AddListener(Play);
        optionBtn.onClick.AddListener(Option);
        quitBtn.onClick.AddListener(Quit);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Play(){
        SceneManager.LoadScene("Level1");
    }
    public void Option(){
        
    }
    public void Quit(){
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
