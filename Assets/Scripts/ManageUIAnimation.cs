using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class ManageUIAnimation : MonoBehaviour
{
    [SerializeField] Button regButton;
    [SerializeField] Image regBack;
    [SerializeField] Image regTopCenterLogo;
    #region Singltone
    public static ManageUIAnimation instance;
    private void Awake()
    {
        if (instance == null )
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartAnimat());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   public void AnimatButton(bool state)
   {
        // true for scale obj to 1
        //false for scle obj to 0
        if(state)
        {
            regButton.transform.DOScale(1f, 0.5f).SetEase(Ease.OutBounce);
        }
        else
        {
            regButton.transform.DOScale(0f, 0.5f).SetEase(Ease.OutBounce);
        }
   }
   IEnumerator StartAnimat()
   {
        regBack.transform.DOScale(0, 0);
        regTopCenterLogo.transform.DOScale(0, 0);

        yield return new WaitForSeconds(0.7f);
        regBack.GetComponent<AudioSource>().Play();
        regBack.transform.DOScale(0.2440857f, 1).SetEase(Ease.OutBounce);
        regTopCenterLogo.transform.DOScale(1,1).SetEase(Ease.OutBounce);
    }
}
