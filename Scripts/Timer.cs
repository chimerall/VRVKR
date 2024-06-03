using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeStart;

    public TextMeshProUGUI textTimer;

    bool timerRunning = false;

    // Start is called before the first frame update
    void Start()
    {

        textTimer.text = timeStart.ToString("F2");
    }

    // Update is called once per frame
    void Update()
    {
        if (timerRunning == true)
        {
            timeStart += Time.deltaTime;
            textTimer.text = timeStart.ToString("F2");
        }
    }

    public void BtnTimer()
    {
        timerRunning = !timerRunning;
    }
}