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
      coroutine = StartCoroutine(timer.TimeCounte());
    }

    public void StopTimer()
    {
        StopCoroutine(coroutine);
    }

    public void ResetTimer()
    {
        timer.Reset();
    }

    private void Update()
    {
        text.text = timer.CountTime.ToString();
    }
}


public class Timer
{
    float time;

    public float CountTime => time;

    public Timer()
    {
        time = 0;
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
