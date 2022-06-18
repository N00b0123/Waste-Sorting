using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private Vector3 spawnPoint;
    private GameObject canvasGO;
    private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Vector3 lastLocation;
    private bool isOnBin;
    private PointerEventData pointerEvent;

    public static DragDrop Instance;

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

    private void Start()
    {
        Instance = this;
        spawnPoint = transform.position;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = .8f;
        canvasGroup.blocksRaycasts = false;
        
        isOnBin = Bin.Instance.GetPositionStatus();
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        lastLocation.x = eventData.position.x;
        isOnBin = Bin.Instance.GetPositionStatus();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isOnBin = Bin.Instance.GetPositionStatus();
        if (!isOnBin)
        {
            var position = new Vector3(lastLocation.x, spawnPoint.y, 1f);
            transform.position = position;
            CanResidueMove = true;
         //   Debug.Log($" OnEndDrag DragDrop {isOnBin}");
        }

        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;

        pointerEvent = eventData;

        
    }

    public PointerEventData GetItemEvent()
    {
        return pointerEvent;
    }

    public void OnDrop()
    {
        if (!isOnBin)
        {
            var position = new Vector3(lastLocation.x, spawnPoint.y, 1f);
            transform.position = position;
            CanResidueMove = true;
         //   Debug.Log($" OnDrop DragDrop {isOnBin}");
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        CanResidueMove = false;
    }

    private void Update()
    {
        isOnBin = Bin.Instance.GetPositionStatus();
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
