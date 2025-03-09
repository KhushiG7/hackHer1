using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{

    public int maximum;
    public int current;
    public Image mask;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Application.isPlaying) {
        GetCurrentFill();
        }
    }

    void GetCurrentFill() {
        float fillAmount = (float)current / (float)maximum;
        mask.fillAmount = fillAmount;
    }

    void AddPB(int value) {
        current = current + value;
    }
}
