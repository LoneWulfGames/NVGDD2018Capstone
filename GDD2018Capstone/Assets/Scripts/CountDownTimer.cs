using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

        else if(timeLeft < 30f)
        {
            timerText.color = Color.red;
        }
    }

    public void GameOver()
    {
        timerText.fontSize = 45;
        timerText.color = Color.cyan;
        timerText.alignment = TextAnchor.MiddleCenter;
        timerText.text = ("Time Ran Out. Hiders Win!");
        Debug.Log("GameOver!");
        StartCoroutine(WaitForSeconds());
    }

    public void ChangeTimerText()
    {
        timerText.text = ("Time Left: " + timeLeft);
    }

    IEnumerator WaitForSeconds()
    {
        yield return new WaitForSeconds(10f);
        SceneManager.LoadScene(0);
    }
}
