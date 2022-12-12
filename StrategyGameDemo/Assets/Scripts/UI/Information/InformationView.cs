using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class InformationView : MonoBehaviour
{

    #region References



    #endregion

    #region Serialize

    [SerializeField] private TMP_Text _buildingName;

    [SerializeField] private Image _buildingImage;

    [SerializeField] private TMP_Text _productionName;

    [SerializeField] private Image _productionImage;

    [SerializeField] private GameObject _productionPanel;

    [SerializeField] private GameObject _buildingPanel;

    #endregion

    #region OnEnable && OnDisable

    private void OnEnable()
    {
        GameEvents.OnSetBuildingData += SetBuildingData;
        GameEvents.OnSetProductionData += SetProductionData;
    }

    private void OnDisable()
    {
        GameEvents.OnSetBuildingData -= SetBuildingData;
        GameEvents.OnSetProductionData -= SetProductionData;
    }

    #endregion

    private void SetBuildingData(Sprite buildingImage, string buildingName)
    {
        IsActiveProductionPanel(false);
        IsActiveBuildingPanel(true);
        _buildingImage.sprite = buildingImage;
        _buildingName.text = buildingName;
    }

    private void SetProductionData(Sprite productionImage, string productionName)
    {
         IsActiveProductionPanel(true);
        _productionImage.sprite = productionImage;
        _productionName.text = productionName;
    }


    private void IsActiveBuildingPanel(bool on) => _buildingPanel.SetActive(on);


    private void IsActiveProductionPanel(bool on) => _productionPanel.SetActive(on);
}
