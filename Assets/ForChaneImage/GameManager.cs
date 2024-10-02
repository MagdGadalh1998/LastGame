using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class GameManager : MonoBehaviour
{
    public CanvasGroup image1;
    public float fadeDuration = 1f;
    bool isFinish = false;
    void Start()
    {
        // Ensure the images are set to the desired alpha initially
    }

    public void FadeBetweenImages(string state)
    {
        // Fade out the first image and fade in the second image using DoTween
        if(state == "O")
            image1.DOFade(0f, fadeDuration).SetEase(Ease.OutBounce).OnComplete(()=> isFinish = false);
        else if(state == "I")
            image1.DOFade(1f, fadeDuration).SetEase(Ease.InOutBounce).OnComplete(() => isFinish = false);
    }
    void Update()
    { 
        if (Input.GetKeyDown(KeyCode.A) && !isFinish)
        {
            isFinish = true;
            FadeBetweenImages("O");
        }
        else if (Input.GetKeyDown(KeyCode.Z) && !isFinish)
        {
            isFinish = true;
            FadeBetweenImages("I");
        }
    }
}
