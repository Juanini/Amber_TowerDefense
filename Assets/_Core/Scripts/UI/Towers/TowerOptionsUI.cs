using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

public class TowerOptionsUI : MonoBehaviour
{
    [BoxGroup("General")] public Button closeButton;
    
    [BoxGroup("Tower Creation")] public GameObject towerCreationContainer;
    
    [BoxGroup("Tower Options")] public GameObject towerOptionsContainer;
    [BoxGroup("Tower Options")] public Button removeTowerButton;
    
    public void Init()
    {
        closeButton.onClick.AddListener(OnCloseClick);
        removeTowerButton.onClick.AddListener(OnRemoveTowerClick);
    }

    // * =====================================================================================================================================
    // * 

    private void OnCloseClick()
    {
        CloseTowerOptions();
    }

    public void CloseTowerOptions()
    {
        closeButton.gameObject.SetActive(false);
        towerCreationContainer.gameObject.SetActive(false);
        towerOptionsContainer.gameObject.SetActive(false);
    }
    
    // * =====================================================================================================================================
    // * TOWER CREATION

    #region TOWER CREATION
    
    public void ShowTowerCreationUI(Vector2 _pos)
    {
        closeButton.gameObject.SetActive(true);
        towerCreationContainer.gameObject.SetActive(true);
        towerCreationContainer.transform.position = _pos;
    }
    
    public void HideTowerCreationUI()
    {
        closeButton.gameObject.SetActive(false);
        towerCreationContainer.gameObject.SetActive(false);
    }
    
    #endregion

    
    // * =====================================================================================================================================
    // * TOWER OPTIONS

    #region TOWER OPTIONS

    public void ShowTowerOptions(Tower _tower)
    {
        LevelManager.Ins.towerSelected = _tower;
        closeButton.gameObject.SetActive(true);
        towerOptionsContainer.transform.position = _tower.transform.position;
        towerOptionsContainer.gameObject.SetActive(true);
    }

    public void HideTowerOptions()
    {
        closeButton.gameObject.SetActive(true);
        towerOptionsContainer.gameObject.SetActive(true);
    }
    
    private void OnRemoveTowerClick()
    {
        HideTowerOptions();
        LevelManager.Ins.towerSelected.Remove();
    }
    
    #endregion
}
