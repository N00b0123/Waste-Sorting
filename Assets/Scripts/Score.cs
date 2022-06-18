using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI point;
    [SerializeField] private TextMeshProUGUI erro;
    [SerializeField] private TextMeshProUGUI life;

    private int pointCount;
    private int erroCount;
    private int lifeCount;

    public static Score Instance;



    public void StartScore()
    {
        point.text = (GameManager.Instance.GetPointScoreValue()).ToString();
        erro.text = (GameManager.Instance.GetErroScoreValue()).ToString();
        life.text = (GameManager.Instance.GetLifeScoreValue()).ToString();

        pointCount = GameManager.Instance.GetPointScoreValue();
        erroCount = GameManager.Instance.GetErroScoreValue();
        lifeCount = GameManager.Instance.GetLifeScoreValue();

        life.text = $"{lifeCount}";

        
    }

    private void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string GeTPointScore()
    {
        return point.text;
    }

    public void SetTPointScore()
    {
        pointCount++;
        point.text = $"{pointCount}";
    }

    public string GeTErroScore()
    {
        return erro.text;
    }

    public void SetTErroScore()
    {
        lifeCount--;
        erroCount++;
        erro.text = $"{erroCount}";

        if(lifeCount <= 0)
        {
            GameManager.Instance.GameOver();
        }

        life.text = $"{lifeCount}";
    }

}
