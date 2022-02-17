using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventManager : MonoBehaviour
{
    [SerializeField] private Text text_Count;
    [SerializeField] private Button ResetButton;
    public static Action<int> EventCount;
    private void Start()
    {
        EventCount += UpdateDisplay;
    }
    private void UpdateDisplay(int Count)
    {
        string CountText = text_Count.text;
        if (CountText == "")
        {
            CountText = "0";
        }
        Count += int.Parse(CountText);
        text_Count.text = Count.ToString();
        if (Count == 5)
        {
            ResetButton.gameObject.SetActive(true);
        }
    }
    
}
