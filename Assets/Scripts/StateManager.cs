using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class StateManager : MonoBehaviour
{
    public static StateManager Instance;

    public string BestPlayerName = "";
    public int BestPlayerScore = 0;
    public string CurrentPlayerName = "";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadState();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPlayerScore(int score)
    {
        if (BestPlayerScore < score)
        {
            BestPlayerName = CurrentPlayerName;
            BestPlayerScore = score;
            SaveState();
        }
    }

    public void SaveState()
    {
        SaveData data = new SaveData();
        data.BestPlayerName = BestPlayerName;
        data.BestPlayerScore = BestPlayerScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadState()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            BestPlayerName = data.BestPlayerName;
            BestPlayerScore = data.BestPlayerScore;
        }
    }
}
