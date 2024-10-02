using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
public class StartPlay : MonoBehaviour
{
  //  private static StartPlay instance;
    public Button welcom;
    private void Awake()
    {
        /*if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }*/
    }
    
    // Start is called before the first frame update
    void Start()
    {
        welcom.onClick.AddListener(NextScene);
        StartCoroutine(WaiToStart());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator WaiToStart()
    {
        welcom.gameObject.SetActive(false);
        welcom.transform.DOScale(0, 1);
        welcom.interactable = false;
        yield return new WaitForSeconds(1.3f);
        welcom.gameObject.SetActive(true);
        welcom.transform.DOScale(0.23095f, 1).SetEase(Ease.OutBounce)
        .OnComplete(() =>
        {
            welcom.interactable = true;
        });
    }
    void NextScene()
    {
        welcom.interactable = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
