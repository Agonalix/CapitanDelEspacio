using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 10f;
    public TextMeshProUGUI timeText;
    private bool timerIsRunning = false;
    // Start is called before the first frame update
    void Start()
    {
        timerIsRunning = true;
        UpdateTimerUI();
        timeRemaining = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimerUI();
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                TimerEnded();
            }
        }
    }
    void UpdateTimerUI()
    {
        // Actualiza el texto del temporizador
        timeText.text = string.Format("{0:00}", timeRemaining);
    }

    void TimerEnded()
    {
        // Aquí manejas el evento de que el tiempo se ha acabado
        // Por ejemplo, puedes cargar una pantalla de reintentar
        SceneManager.LoadScene("Retry");
    }
}
