using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Residue : MonoBehaviour
{

    [SerializeField] WasteTypeSO wasteType;

    public static Residue Instance;

    private void Start()
    {
        Instance = this;
        
    }

    public WasteTypeSO GetWasteType()
    {
        return wasteType;
    }


}
