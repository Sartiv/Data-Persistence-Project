using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PersistData : MonoBehaviour
{
    public static PersistData Instance;

    public string nickname;
    public string bestNickname;
    public int bestScore = 0;

    
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadBestScore();
    }

    [System.Serializable]
    class SaveData
    {
        public string nickname;
        public string bestNickname;
        public int bestScore;
    }

    public void SaveBestScore()
    {
        SaveData data = new SaveData();
        data.nickname = nickname;
        data.bestScore = bestScore;
        data.bestNickname = bestNickname;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        Debug.Log(path);
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            nickname = data.nickname;
            bestScore = data.bestScore;
            bestNickname = data.bestNickname;
        }
    }

}


