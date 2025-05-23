using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Manager : MonoBehaviour
{
    public static Manager instance;

    private int crystal;
    [SerializeField] private TMP_Text crystalDisplay;

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
    }

    private void Update()
    {
        AmountTime();
    }

    private void OnGUI()
    {
        crystalDisplay.text = crystal.ToString();
    }

    public void ChangeCrystals(int amount)
    {
        crystal += amount;
    }

    public void AmountTime()
    {
        if (crystal == 6)
        {
            Time.timeScale = 0f;
        }
        
        Debug.Log(crystal.ToString());
    }

}

