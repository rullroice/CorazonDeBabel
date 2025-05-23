using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    float elapsedTime;

    private void Update()
    {
        PausarEsc();
        
        elapsedTime += Time.deltaTime;
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        int milliseconds = Mathf.FloorToInt((elapsedTime * 1000f) % 1000f);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        
    }

    private void PausarEsc()
    {
        if (Time.timeScale == 0f && Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 1f;
            timerText.color = Color.white;
            Debug.Log("Juego Reanudado");
        }
        else if (Time.timeScale == 1f && Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            timerText.color = Color.red;
            Debug.Log("Juego Pausado");
        }
        else if (Time.timeScale == 0f)
        {
            timerText.color = Color.red;
        }
    }

}
