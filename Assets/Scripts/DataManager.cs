using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public string playerName = "John";
    public string highScoreName = "Name";
    public int highScore = 0;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

    }

    [System.Serializable]
    class SaveData
    {
        public string playerName = "John Doe";
        public int highScore = 0;
    }

    public void StartGame()
    {
        playerName = GameObject.Find("Canvas").gameObject.transform.GetChild(0).GetChild(0).GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text;
        SceneManager.LoadScene(1);
    }

    public void SaveHighScore(int score)
    {
        Debug.Log("Saving High Score");
        SaveData data = new SaveData();
        if (score > highScore)
        {
            data.highScore = score;
            data.playerName = playerName;
        }
        else
        {
            data.highScore = highScore;
            data.playerName = highScoreName;
        }

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighScore()
    {
        Debug.Log("Loading High Score");
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScoreName = data.playerName;
            highScore = data.highScore;
        }
    }

}
