using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public string highScorePlayerName;
    public string currentPlayerName;
    public int highScore;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(instance);
            return;
        }
        instance = this;

        DontDestroyOnLoad(gameObject);

        LoadNameInfo();
    }

    [System.Serializable]
    public class SaveData
    {
        public string playerName;
        public int highScore;
    }

    public void SaveNameInfo()
    {
        SaveData data = new SaveData();

        data.playerName = highScorePlayerName;
        data.highScore = highScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }   
    
    public void LoadNameInfo()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScorePlayerName = data.playerName;
            highScore = data.highScore;
        }
    }

}
