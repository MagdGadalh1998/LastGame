using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    //[SerializeField] private GameObject questionUi;
    [SerializeField] private Image questImage;
    //[SerializeField] private Image questGuide;
    [SerializeField] private List<Button> answerButtons;
    [SerializeField] private List<Question> questions;


    private Question currentQuestion;
    public static int currentQuestionIndex;
    private void Start()
    {
        foreach (Button button in answerButtons)
        {
            button.interactable = false;
        }
    }
    
    public void DisplayNextQuestion()
    {
        ClearButtonListeners();
        if (currentQuestionIndex < questions.Count)
        {
            currentQuestion = questions[currentQuestionIndex];

            /*questImage.sprite =currentQuestion.questImage;
            questImage.SetNativeSize();*/

           /* questGuide.sprite = currentQuestion.ansGuide;
            questGuide.SetNativeSize();*/

            for (int i = 0; i < answerButtons.Count; i++)
            {
                /*answerButtons[i].GetComponentInChildren<Image>().sprite = currentQuestion.ansImage[i];
                answerButtons[i].GetComponentInChildren<Image>().SetNativeSize();*/

                int answerIndex = i;
                answerButtons[i].onClick.AddListener(() => CheckAnswer(answerIndex));
            }
        }
        else
        {
        }
    }
    
    private void CheckAnswer(int answerIndex)
    {
        if (answerIndex == currentQuestion.correctAnswerIndex)
        {
           // SetFeedback(answerIndex, true);
            
            print("U Win");
            currentQuestionIndex++;
        }
        else
        {
            print("U Lose");
            //SetFeedback(answerIndex, false);
        }
    }
    void ControlButtons(bool state)
    {
        //true is open 
        //fales is close
        foreach (Button button in answerButtons)
        {
            button.interactable = state;
        }
    }
    void SetFeedback(int index,bool state)
    {
        answerButtons[index].transform.GetChild(0).gameObject.SetActive(true);
        answerButtons[index].interactable = false;
        if (state)
        {
            answerButtons[index].transform.GetChild(0).GetComponent<Image>().sprite = currentQuestion.rightFeed;
            ControlButtons(false);
        }
        else
        {
            answerButtons[index].transform.GetChild(0).GetComponent<Image>().sprite = currentQuestion.wrongFeed;
        }
            
    }
    private void ClearButtonListeners()
    {
        foreach (Button button in answerButtons)
        {
            button.onClick.RemoveAllListeners();
        }
    }
    IEnumerator NextQuest()
    {
        yield return new WaitForSeconds(2);
        DisplayNextQuestion();
    }
    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
[System.Serializable]
public class Question
{
    public Sprite questImage;
    //public AudioClip qClip;
    //public Sprite[] ansImage;
   // public Sprite ansGuide;
    public Sprite rightFeed;
    public Sprite wrongFeed;
    public int correctAnswerIndex;
}
