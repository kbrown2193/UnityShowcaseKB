using UnityEngine;
using TMPro;

public class DisplayStandForMaterial : MonoBehaviour
{
    [SerializeField] private string displayStandID;
    [SerializeField] private TextMeshPro displayStandDetailsText; // changes the text of this
    [SerializeField] private GameObject displayStandItem; // changes the model and material of this
    [SerializeField] private GameObject displayStandPedestal; // changes the model and material of this

    private void Start()
    {
        DisplayStandMaterialData standData = DisplayStandMaterialDatabase.GetDisplayStandData(displayStandID);
        if (standData != null)
        {
            SetDisplayStandDetailsText(standData);
            SetDisplayStandItemModelAndMaterial(standData);
            SetDisplayStandPedestalModelAndMaterial(standData);
        }
    }

    private void SetDisplayStandDetailsText(DisplayStandMaterialData standData)
    {
        if (displayStandDetailsText != null)
        {
            displayStandDetailsText.text = standData.details;
        }
    }

    private void SetDisplayStandItemModelAndMaterial(DisplayStandMaterialData standData)
    {
        displayStandItem.GetComponent<MeshFilter>().mesh = standData.itemModel;
        displayStandItem.GetComponent<Renderer>().material = standData.itemMaterial;
    }

    private void SetDisplayStandPedestalModelAndMaterial(DisplayStandMaterialData standData)
    {
        displayStandPedestal.GetComponent<MeshFilter>().mesh = standData.pedestalModel;
        displayStandPedestal.GetComponent<Renderer>().material = standData.pedestalMaterial;
    }
}
