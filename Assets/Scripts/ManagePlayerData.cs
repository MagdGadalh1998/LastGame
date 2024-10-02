using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using System;

public class ManagePlayerData : MonoBehaviour
{
    private List<PlayerData> playerDataList = new List<PlayerData>();

    [SerializeField] InputField playerId;
    [SerializeField] InputField playerName;
    [SerializeField] InputField playerPhoneNumber;
    [SerializeField] string fileName;
    public Button saveData;

    // Start is called before the first frame update
    void Start()
    {
        playerDataList = JasonFileHandller.ReadListFromJSON<PlayerData>(fileName);
        saveData.onClick.AddListener(SaveData);
        
    }
    public void SaveData()
    {
        /*playerDataList.Add(new PlayerData(int.Parse(playerId.text),
                           playerName.text, long.Parse(playerPhoneNumber.text)));
        JasonFileHandller.SaveToJSON<PlayerData>(playerDataList, fileName);*/

        PlayerPrefs.SetInt("Player_ID", int.Parse(playerId.text));
        PlayerPrefs.SetString("player_Name", playerName.text);
        PlayerPrefs.SetString("Player_Phone", playerPhoneNumber.text);
        StartCoroutine(NextScene());

    }
    IEnumerator NextScene()
    {
        saveData.interactable = false;
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void LoadFromJasonFile()
    {
       // playerDataList = JasonFileHandller.ReadFromJSON<PlayerData>(fileName);
    }
    // Update is called once per frame
    void Update()
    {
        CheckInputFields();
    }
    public void CheckInputFields()
    {
        // Get the text from each input field
        string text1 = playerName.text;
        string text2 = playerPhoneNumber.text;
        string text3 = playerId.text;

        // Check if any of the input fields is empty
        if (!string.IsNullOrEmpty(text1) && 
            !string.IsNullOrEmpty(text2) &&
            !string.IsNullOrEmpty(text3) &&
            playerPhoneNumber.text.Length == 11)
        {
            ManageUIAnimation.instance.AnimatButton(true);
        }
        else
        {
            ManageUIAnimation.instance.AnimatButton(false);
        }
    }

}
