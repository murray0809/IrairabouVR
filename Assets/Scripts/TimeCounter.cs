using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class TimeCounter : MonoBehaviour
{
    public Timer timer;

    public Text text;

    Coroutine coroutine;

    private void Awake()
    {
        timer = new Timer();
    }

    public void StartTimer()
    {
        if (timer.isTimeCounted) return;
      coroutine = StartCoroutine(timer.TimeCounte());
        timer.isTimeCounted = true;
    }

    public void StopTimer()
    {
        StopCoroutine(coroutine);
        timer.isTimeCounted = false;
    }

    public void ResetTimer()
    {
        timer.Reset();
    }

    private void Update()
    {
        text.text = timer.CountTime.ToString("0.00");
    }
}


public class Timer
{
    float time;

    public float CountTime => time;

    public bool isTimeCounted;
    public Timer()
    {
        time = 0;
        isTimeCounted = false;
    }

    /// <summary>
    /// タイマーをリセットする
    /// </summary>
    public void Reset()
    {
        time = 0;
    }

    public IEnumerator TimeCounte()
    {
        while (true)
        {
            time += Time.deltaTime;
            yield return null;
        }
    }
}
