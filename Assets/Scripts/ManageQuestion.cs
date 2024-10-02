using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;
public class ManageQuestion : MonoBehaviour
{
    // Start is called before the first frame update
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CloseExtraChancePanel()
    {
        //when Click Yes 0 indxt

        StartCoroutine(WaiToClosePanel(0));
    }
    public void CloseQuestionPanelInWinCase()
    {
        // index 1
        StartCoroutine(WaiToClosePanel(1));
    }
    public void CloseQuestionPanelInLoseCase()
    {
        // index 2
        StartCoroutine(WaiToClosePanel(2));
    }
    IEnumerator WaiToClosePanel(int index)
    {
        yield return new WaitForSeconds(1);
        if (index == 0)
        {
            //close the extra time panel
            QuestionAnimation.instance.ControlAnimation("Close", this.gameObject, 0);
        }
        else if (index == 1)
        {
            //close win Panel
            QuestionAnimation.instance.ControlAnimation("Close", this.gameObject, 1);
        }
        else if (index == 2)
        {
            //close Lose Panel
            QuestionAnimation.instance.ControlAnimation("Close", this.gameObject, 2);
        }
        else if (index == 3)
        {
            yield return new WaitForSeconds(1);
            //Restart the Game 
            print("Restart Game");
            
        }
    }
    public void RestartGame()
    {
        WaiToClosePanel(3);
    }
    
}
