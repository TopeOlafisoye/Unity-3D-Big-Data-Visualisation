using UnityEngine;
using System.IO;

public class TitanicDataVisualizer : MonoBehaviour
{
    public string csvFileName;
    public GameObject dataPointPrefab;
    public Transform dataPointsParent;

    void Start()
    {
        string filePath = Path.Combine(Application.dataPath, csvFileName);
        StreamReader reader = new StreamReader(filePath);

        while (!reader.EndOfStream)
        {
            string line = reader.ReadLine();
            string[] values = line.Split(',');

            float x = float.Parse(values[0]);  // Example: Age
            float y = float.Parse(values[1]);  // Example: Fare
            // You can customize this to fit your dataset's structure

            Vector3 position = new Vector3(x, 0, y);
            Instantiate(dataPointPrefab, position, Quaternion.identity, dataPointsParent);
        }

        reader.Close();
    }
}