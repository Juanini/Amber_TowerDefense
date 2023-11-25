using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButtonUI : MonoBehaviour
{
    public Button button;

    private void Start()
    {
        button.onClick.AddListener(OnLevelClick);
    }

    private void OnLevelClick()
    {
        
    }
}
