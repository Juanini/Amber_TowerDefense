using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerCreationButton : MonoBehaviour
{
    public Button button;
    public TowerType towerType;

    private void Start()
    {
        button.onClick.AddListener(OnSelect);
    }

    private void OnSelect()
    {
        GameManager.Ins.OnCreateTower(towerType);
    }
}