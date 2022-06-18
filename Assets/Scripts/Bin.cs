using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Bin : MonoBehaviour, IDropHandler
{
    [SerializeField] WasteTypeSO wasteType;
    private bool isOnBin = false;
    public static Bin Instance;
    private Animator animator;
    [SerializeField] private GameObject ligthAnim;

    private void Start()
    {
        Instance = this;
        animator = ligthAnim.GetComponent<Animator>();
        ligthAnim.SetActive(false);
    }

    public void OnDrop(PointerEventData eventData)
    {
        var grabResidue = eventData.pointerDrag.GetComponent<Residue>();

        if(grabResidue != null)
        {
            if(GetWasteBin() == grabResidue.GetWasteType())
            {
                ligthAnim.transform.position = gameObject.transform.position;
                ligthAnim.SetActive(true);
                animator.SetBool("animateLigth", true);
                isOnBin = true;
                Score.Instance.SetTPointScore();
                Destroy(grabResidue.gameObject);
                isOnBin = false;
            }
            else if(GetWasteBin() != grabResidue.GetWasteType())
            {
                animator.SetBool("animateLigth", false);
                isOnBin = true;
                
                Score.Instance.SetTErroScore();
                Destroy(grabResidue.gameObject);
                isOnBin = false;
            }
            else
            {
                animator.SetBool("animateLigth", false);
                isOnBin = false;
                DragDrop.Instance.OnDrop();
            }
        }
        else
        {
            isOnBin = true;
        }
    }
    private  WasteTypeSO GetWasteBin()
    {
        return this.wasteType;
    }

    public bool GetPositionStatus()
    {
        return isOnBin;
    }
}
