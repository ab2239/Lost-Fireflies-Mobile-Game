using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] private float timeLeft;
    [SerializeField] private bool timerOn = false;

    [SerializeField] private TextMeshProUGUI timerTxt;

    // Start is called before the first frame update
    public void StartTimer()
    {
        timerOn = true;
        timerTxt.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (timerOn)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                UpdateTimer(timeLeft);
            }

            else
            {
                Debug.Log("Timer Finished");
                timeLeft = 0;
                timerOn = false;
                Time.timeScale = 1f;
                SceneManager.LoadScene("FailScene");
            }
        }
    }
    void UpdateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);
        timerTxt.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
}
