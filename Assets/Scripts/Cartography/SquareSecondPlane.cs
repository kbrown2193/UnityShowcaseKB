using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareSecondPlane : MonoBehaviour
{
    // sample data structures
    private bool[] dataBools = new bool[60 * 60];
    private int[] dataInts = new int[60 * 60];
    private Vector3[] dataVectors = new Vector3[60 * 60]; // 1D Array (60 * 60) = 3600
    private Color[] dataColors = new Color[60 * 60];

    // tile id
    private int longitudeDegree; //
    private int longitudeMinute;
    private int latitudeDegree;
    private int latitudeMinute;

    // Data table, if data table lookup, Row Name = 
    // or, NAME = LAT_00X_LON_000Y


}
