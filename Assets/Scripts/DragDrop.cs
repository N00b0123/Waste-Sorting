using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private GameObject canvasGO;
    private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    float speed = 120f;
    private float leftEdge;

    private bool CanResidueMove;
    private void Awake()
    {
        canvasGO = GameObject.Find("Canvas");
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = canvasGO.GetComponent<Canvas>();
        CanResidueMove = true;
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 2;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = .8f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        CanResidueMove = false;
    }


    private void Update()
    {
        if (CanResidueMove)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
     
        if (transform.position.x < leftEdge)
        {
            Destroy(gameObject);
            Score.Instance.SetTErroScore();
        }
    }
}
