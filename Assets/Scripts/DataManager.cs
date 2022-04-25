using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static DataManager Instance;

    private SaveData UserInfo; // new variable declared

    private void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadUserInfo();
    }

    [System.Serializable]
    class SaveData
    {
        public string Name;
        public int Score;
    }

    public void SaveUserInfo()
    {
        string json = JsonUtility.ToJson(UserInfo);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadUserInfo()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            UserInfo = data;
        } else UserInfo = new SaveData();
    }

    public void SetName(string name)
    {
        UserInfo.Name = name;
    }

    public void SetHighScore(int score)
    {
        if (score > UserInfo.Score)
            UserInfo.Score = score;
    }

    public string GetName()
    {
        return UserInfo.Name;
    }

    public int GetHighScore()
    {
       return UserInfo.Score;
    }
}
