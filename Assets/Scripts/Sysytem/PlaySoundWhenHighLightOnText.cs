using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlaySoundWhenHighLightOnText : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private AudioClip textSound;
    // Start is called before the first frame update
    void Start()
    {
       
    }
    public void OnPointerEnter(PointerEventData ped)
    {
        print("Enter");
        GetComponent<AudioSource>().clip = textSound;
        GetComponent<AudioSource>().Play();
    }
    public void OnPointerExit(PointerEventData ped)
    {
        print("Exite");
        GetComponent<AudioSource>().Stop();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
