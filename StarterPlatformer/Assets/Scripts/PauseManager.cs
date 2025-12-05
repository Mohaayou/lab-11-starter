using System.IO;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PauseManager: MonoBehaviour 
{
    public GameObject pauseScreen;
    public PlayerMovement Player;




    void Start()
    {
        Player = GameObject.FindAnyObjectByType<PlayerMovement>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            if (pauseScreen.activeSelf)
            {
                // We're paused, so unpause
                UnPause();
            }   
            else
            {
                // We're unpaused, so pause
                Pause();
            }
        }
    }
    public void Pause()
    {
        pauseScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    public void UnPause()
    {
        pauseScreen.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Save()
    {
        SaveData data = new SaveData();
        data.score = Player.score;
        data.hp = Player.hp;
        data.playerPos = Player.lastSafePos;
        string jsonData = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/save.json", jsonData);
    }

    public void Load()
    {
        string loadedJson = File.ReadAllText(Application.persistentDataPath + "/save.json");
        SaveData data = JsonUtility.FromJson<SaveData>(loadedJson);
        data.score = Player.score;
        data.hp = Player.hp;
        data.playerPos = Player.lastSafePos;
        Player.UpdateUI();

    }

    class SaveData
    {
        public int score;
        public int hp;
        public Vector3 playerPos;
    }
}
