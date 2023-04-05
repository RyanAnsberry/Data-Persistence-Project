using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDataManager : MonoBehaviour
{
    public static PlayerDataManager Instance;

    public string PlayerName;
    public int PlayerScore;

    public int HighScore = 0;
    public string CurrentLeader = "";

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadGameRank();
    }

    public void CheckHighScore()
    {
        if (PlayerScore > HighScore)
        {
            CurrentLeader = PlayerName;
            HighScore = PlayerScore;
        }
    }


    public void SaveGameRank()
    {
        Debug.Log("Saving...");
        SaveData data = new SaveData();

        data.CurrentLeader = CurrentLeader;
        data.HighScore = HighScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadGameRank()
    {
        Debug.Log("Loading...");
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            Debug.Log("File Found!");

            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            CurrentLeader = data.CurrentLeader;
            HighScore = data.HighScore;
        }
    }

    [System.Serializable]
    class SaveData
    {
        public int HighScore;
        public string CurrentLeader;
    }
}
