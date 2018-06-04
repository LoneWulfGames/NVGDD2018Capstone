using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour
{
    public float timeLeft = 180f;

    public Text timerText;

    public void Update()
    {
        timeLeft -= Time.deltaTime;

        ChangeTimerText();

        if(timeLeft <= 0f)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        Debug.Log("GameOver!");
    }

    public void ChangeTimerText()
    {
        timerText.text = ("Time Left: " + timeLeft);
        
        if(timeLeft <= 30)
        {
            timerText.color = Color.red;
        }
    }
}
