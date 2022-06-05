using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/WasteTypeList")]
public class WasteTypeListSO : ScriptableObject
{
    public List<WasteTypeSO> list;
}
