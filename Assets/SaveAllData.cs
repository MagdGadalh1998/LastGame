using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SaveAllData : MonoBehaviour
{
    private List<PlayerData> playerDataList = new List<PlayerData>();
    [SerializeField] string fileName;

    // Start is called before the first frame update
    void Start()
    {
        playerDataList = JasonFileHandller.ReadListFromJSON<PlayerData>(fileName);
        SaveData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SaveData()
    {
        // Load data from player prefs
        int _playerId = PlayerPrefs.GetInt("Player_ID");
        string _PlayerName = PlayerPrefs.GetString("player_Name");
        string _PlayerPhone = PlayerPrefs.GetString("Player_Phone");
        int _PlayerScore = PlayerController.instance.score;

        long number = long.Parse(_PlayerPhone);
        //save data to jason file 
        playerDataList.Add(new PlayerData(
                             _playerId,
                             _PlayerName,
                             number,
                             _PlayerScore));

        JasonFileHandller.SaveToJSON<PlayerData>(playerDataList, fileName);
        
    }
    public void PlayAgain()
    {
        StartCoroutine(WaitToNextScene());
    }
    IEnumerator WaitToNextScene()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(0);
    }
}
