using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Runtime.InteropServices;
#if (UNITY_EDITOR)
using UnityEditor;
#endif

public class MenuUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TMP_InputField nameInput;
    // Start is called before the first frame update
    void Start()
    {
        //Load the name and score if one is present
        if (ScoreManager.instance.highScorePlayerName != null && ScoreManager.instance.highScore > 0)
        {
            scoreText.text = "Best Score: " + ScoreManager.instance.highScorePlayerName + ": " + ScoreManager.instance.highScore;
        }    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartNew()
    {
        ScoreManager.instance.currentPlayerName = nameInput.text; 
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {

#if (UNITY_EDITOR)
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
