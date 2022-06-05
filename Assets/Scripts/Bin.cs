using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Bin : MonoBehaviour, IDropHandler
{
    [SerializeField] WasteTypeSO wasteType;


     //   WasteTypeListSO wasteTypeList = Resources.Load<WasteTypeListSO>(typeof(WasteTypeListSO).Name);

    public void OnDrop(PointerEventData eventData)
    {
        var grabResidue = eventData.pointerDrag.GetComponent<Residue>();

        if(grabResidue != null)
        {
            if(GetWasteBin() == grabResidue.GetWasteType())
            {
                Score.Instance.SetTPointScore();
                Destroy(grabResidue.gameObject);
            }
            else
            {
                Score.Instance.SetTErroScore();
                Destroy(grabResidue.gameObject);
            }
        }
    }
    private  WasteTypeSO GetWasteBin()
    {
        return this.wasteType;
    }
}
