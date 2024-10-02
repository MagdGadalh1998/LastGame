using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class KeyboardDragHandler : MonoBehaviour, IDragHandler
{
    public Canvas uiCanvas;
    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    #region IDragHandler implementation

    public void OnDrag(PointerEventData eventData)
    {
       // transform.localPosition = eventData.position;
        rectTransform.anchoredPosition += eventData.delta / uiCanvas.scaleFactor;
    }

    #endregion





}