using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControlButtons : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Toggle soundControl;
    [SerializeField] Toggle playPauseControl;
    [SerializeField] GameObject fade;

    AudioSource[] audioSources;
    void Start()
    {
        audioSources = FindObjectsOfType<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ControlSounds()
    {
        if(soundControl.isOn==false)
        {
            foreach (AudioSource audioSource in audioSources)
            {
                audioSource.UnPause();           
            }
        }
        else
        {
            foreach (AudioSource audioSource in audioSources)
            {
                audioSource.Pause();
            }
        }
    }
    public void PlayPauseControl()
    {
        if (playPauseControl.isOn == fade)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void CloseGame()
    {
        fade.SetActive(true);
    }
    
}
