using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class GetSelectedValue : MonoBehaviour
{
    public TMP_Dropdown dropdown;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetValue() {
        int pickedIndex = dropdown.value;
        return pickedIndex;
    }
}
