using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class DialogTyping : MonoBehaviour
{
    [SerializeField] Text qText;
    [SerializeField] string[] lines;
    [SerializeField] float typingSpeed;
    [SerializeField] Button[] buttons;
    [SerializeField] GameObject player;
    
    int index;
    // Start is called before the first frame update
    void Start()
    {
        StartTyping();
    }

    // Update is called once per frame
    void Update()
    {
       /* if (qText.text == lines[index])
        {
            NextLine();
        }
        else
        {
            StopAllCoroutines();
            qText.text = lines[index];
        }*/
    }
    /*private void OnEnable()
    {
        QuestionAnimation.instance.ControlAnimation("Open", this.gameObject,0);
    }*/
    public void StartTyping()
    {
        index = 0;
        qText.text = string.Empty;
        StartCoroutine(Typing());
    }
    IEnumerator Typing()
    {
        ControlButtons(false);
        yield return new WaitForSeconds(0.1f);
        foreach (char c in lines[index].ToCharArray())
        {
            qText.text += c;
            this.GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(typingSpeed);
            this.GetComponent<AudioSource>().Stop();
        }
        ControlButtons(true);
    }
    void NextLine()
    {
        if(index <lines.Length -1)
        {
            index++;
            qText.text = string.Empty;
            StartCoroutine(Typing());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
    void ControlButtons(bool state)
    {
        foreach(Button btn in buttons)
        {
            btn.enabled = state;
        }
    }
    
}
