using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    private TextMeshProUGUI txt;
    private int score = 0;

    void Start()
    {
        txt = GetComponent<TextMeshProUGUI>();

        StartCoroutine(AdjSize());
    }

    void Update()
    {
        
    }

    private IEnumerator AdjSize()
    {
        WaitForSeconds sec = new WaitForSeconds(0.05f);

        while(true)
        {
            txt.fontSize = Mathf.Clamp(txt.fontSize - 5f, 60, 110);
            yield return sec;
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
        txt.text = score + "";
        txt.fontSize = 110;
    }

    public void ReStart()
    {
        score = 0;
        txt.text = score + "";
        txt.fontSize = 110;
    }
}
