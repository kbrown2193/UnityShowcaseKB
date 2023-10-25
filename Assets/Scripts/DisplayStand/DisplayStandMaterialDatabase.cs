using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DisplayStandMaterialDatabase", menuName = "USKB/DisplayStand/DisplayStand Material Database")]
public class DisplayStandMaterialDatabase : ScriptableObject
{
    [SerializeField] private List<DisplayStandMaterialData> displayStandDataList = new List<DisplayStandMaterialData>();

    const string DISPLAYSTAND_MATERIAL_DATABASE_LOCATION = "DisplayStand/DisplayStandMaterialDatabase";

    public static DisplayStandMaterialData GetDisplayStandData(string displayStandID)
    {
        DisplayStandMaterialDatabase database = Resources.Load<DisplayStandMaterialDatabase>(DISPLAYSTAND_MATERIAL_DATABASE_LOCATION); // If using multiple database objects, need to pass in the database name, for now is hardcoded

        foreach (DisplayStandMaterialData standData in database.displayStandDataList)
        {
            if (standData.displayStandID == displayStandID)
            {
                return standData;
            }
        }

        Debug.LogError("Display Stand ID not found in the database: " + displayStandID);
        return null;
    }
}

[System.Serializable]
public class DisplayStandMaterialData
{
    public string displayStandID;
    public string details;
    public Material itemMaterial;
    public Mesh itemModel;
    public Material pedestalMaterial;
    public Mesh pedestalModel;
}
