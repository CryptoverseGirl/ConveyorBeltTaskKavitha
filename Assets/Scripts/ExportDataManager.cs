using System;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;
using UnityEngine.Serialization;

public class ExportDataManager : MonoBehaviour
{
        public TextMeshProUGUI TotalSpawnedBoxesText, damagedBoxesText, perfectBoxesText;
        public Button exportButton;
        
        private void Start()
        {
                exportButton.onClick.AddListener(ExportDataToCSV);
        }

        private void ExportDataToCSV()
        {
                string spawnedBoxesCount = TotalSpawnedBoxesText.text;
                string damagedBoxesCount = damagedBoxesText.text;
                string perfectBoxesCount = perfectBoxesText.text;


                string[] data = new string[] { spawnedBoxesCount, damagedBoxesCount, perfectBoxesCount };

                string header = "Spawned Boxes, Damaged Boxes, Perfect Boxes";

                string fileName = "converyordata.csv";
                string downloadsPath = GetDownloadsPath();
                string filePath = Path.Combine(downloadsPath, fileName);

                using (StreamWriter writer = new StreamWriter(filePath))
                {
                        writer.WriteLine(header);
                        writer.WriteLine(string.Join(",", data));
                }

                Debug.Log("Data exported to CSV file: " + filePath);
        }

        private string GetDownloadsPath()
        {
                string downloadsPath = "";

#if UNITY_EDITOR_WIN
                downloadsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                        "Downloads");
#elif UNITY_STANDALONE_WIN
        downloadsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
#elif UNITY_EDITOR_OSX
        downloadsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
#elif UNITY_STANDALONE_OSX
        downloadsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
#elif UNITY_EDITOR_LINUX
        downloadsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
#elif UNITY_STANDALONE_LINUX
        downloadsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
#endif
                return downloadsPath;
        }
}




