using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> residueList;
    [SerializeField] private float spawRate = 1f;
    [SerializeField] private GameObject spawnPoint;
    private WasteTypeListSO wasteTypeList;
    System.Random random = new System.Random();
    [SerializeField] private Canvas canvas;


    private void Awake()
    {
        wasteTypeList = Resources.Load<WasteTypeListSO>(typeof(WasteTypeListSO).Name);
    }

    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), spawRate, spawRate);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn()
    {  
        var i = random.Next(0, 23);
        GameObject residue = Instantiate(residueList[i], spawnPoint.transform.localPosition, Quaternion.identity);
        residue.transform.SetParent(canvas.transform, false);
    }
}
