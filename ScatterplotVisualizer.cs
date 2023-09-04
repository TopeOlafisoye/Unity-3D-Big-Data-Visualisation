using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DataPoint
{
    public float x;
    public float y;
    public float z;
}

public class ScatterplotVisualizer : MonoBehaviour
{
    public GameObject pointPrefab; // Assign your point prefab in the Inspector
    public TextAsset dataJson;     // Assign your JSON data file in the Inspector

    private List<DataPoint> dataPoints;

    void Start()
    {
        LoadData();
        CreateScatterplot();
    }

    void LoadData()
    {
        dataPoints = new List<DataPoint>();
        dataPoints.AddRange(JsonUtility.FromJson<DataPoint[]>(dataJson.text));
    }

    void CreateScatterplot()
    {
        foreach (var dataPoint in dataPoints)
        {
            Vector3 position = new Vector3(dataPoint.x, dataPoint.y, dataPoint.z);
            Instantiate(pointPrefab, position, Quaternion.identity);
        }
    }
}
