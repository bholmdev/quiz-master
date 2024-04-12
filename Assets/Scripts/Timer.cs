using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float timeToCompleteQuestion = 30f;
    [SerializeField] float timeToShowCorrectAnswer = 10f;

    public bool isAnsweringQuestion = false;
    public bool loadNextQuestion = false;
    public float fillFracture;
    
    float timerValue;

    // Update is called once per frame
    void Update()
    {
        UpdateTimer();
    }

    void UpdateTimer()
    {
        timerValue -= Time.deltaTime;

        if (isAnsweringQuestion)
        {
            if (timerValue > 0)
            {
                fillFracture = timerValue / timeToCompleteQuestion;
            }
            else
            {
                isAnsweringQuestion = false;
                timerValue = timeToShowCorrectAnswer;
            }
        }
        else
            {
                if(timerValue > 0)
                {
                    fillFracture = timerValue / timeToShowCorrectAnswer;
                }
                else
                {
                    isAnsweringQuestion = true;
                    timerValue = timeToCompleteQuestion;
                    loadNextQuestion = true;
                }
            }

        Debug.Log(isAnsweringQuestion + " " + timerValue + " " + fillFracture);
    }

    public void CancelTimer()
    {
        timerValue = 0;
    }
}
