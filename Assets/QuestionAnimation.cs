using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class QuestionAnimation : MonoBehaviour
{
    public static QuestionAnimation instance;
    [SerializeField] GameObject shadow;
    [SerializeField] GameObject[] quets;
    [SerializeField] GameObject winPanel;

    int questIndex;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ControlAnimation(string state,GameObject panel,int panelIndex)
    {
        //panelIndex 0 is the index of extra time panle
        //panelIndex 1 is the index of quest panle
        
        if (state == "Open")
        {
            PlayerController.instance.player.SetActive(false);
            panel.transform.DOScale(0, 0);
            this.GetComponent<AudioSource>().Play();
            panel.SetActive(true);
            
            panel.transform.DOScale(0.24228f, 0.7f)
                           .SetEase(Ease.OutBounce).OnComplete(() =>
                           {
                              // panel.GetComponent<DialogTyping>().StartTyping();

                           });
        }
        else if (state == "Close")
        {
            panel.transform.DOScale(0, 0.7f)
                .SetEase(Ease.OutBounce).OnComplete(() =>
                {
                    if(panelIndex == 0)
                    {
                        //when close the extra time panel
                        StartCoroutine(OpenTheQuestionPanel());
                    }
                    else if (panelIndex == 1)
                    {
                        //when close the question win panel
                        PlayerController.instance.player.SetActive(true);
                        questIndex++;
                        shadow.SetActive(false);
                        print("Make Action When Close QuestPanel");
                        WinInQuest();
                    }
                    else if (panelIndex == 2)
                    {
                        //when close the question lose panel and Open the win Panel
                        LoseInQuest();
                    }
                    panel.SetActive(false);
                });
        }
    }
    IEnumerator OpenTheQuestionPanel()
    {
        print("Time Panel closed.");
        yield return new WaitForSeconds(0.5f);
        shadow.SetActive(true);
        ControlAnimation("Open", quets[questIndex], 0);
        //quets[questIndex].SetActive(true);
    }
    public void WinInQuest()
    {
        StartCoroutine(WhenWin());
    }
    public void LoseInQuest()
    {
        StartCoroutine(WhenLose());
    }
    IEnumerator WhenLose()
    {
        yield return new WaitForSeconds(1);
        ControlAnimation("Open", winPanel, 0);
    }
    IEnumerator WhenWin()
    {
        PlayerController.instance.ResetVariables();
        yield return new WaitForSeconds(0.5f);
        ManageSpawner.instance.StartTimer(5);
        ManageSpawner.instance.StartSpwner();
    }
}
