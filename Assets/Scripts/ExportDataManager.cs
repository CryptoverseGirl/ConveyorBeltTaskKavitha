using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;
using UnityEngine.Serialization;

public class ExportDataManager : MonoBehaviour
{
        public TextMeshProUGUI totalSpawnedBoxesText, damagedBoxesText, perfectBoxesText, exportedLocationText;
        public GameObject exportDataPopup;
        public Button exportButton;
        private string fileN;
        
        private void Start()
        {
                exportButton.onClick.AddListener(ExportDataToCSV);
        }

        private void ExportDataToCSV()
        {
                string spawnedBoxesCount = totalSpawnedBoxesText.text;
                string damagedBoxesCount = damagedBoxesText.text;
                string perfectBoxesCount = perfectBoxesText.text;


                string[] data = new string[] { spawnedBoxesCount, damagedBoxesCount, perfectBoxesCount };

                string header = "Spawned Boxes, Damaged Boxes, Perfect Boxes";

                string fileName = "converyordata.csv";
                string downloadsPath = GetDownloadsPath();
                string filePath = Path.Combine(downloadsPath, fileName);
                fileN = filePath;

                using (StreamWriter writer = new StreamWriter(filePath))
                {
                        writer.WriteLine(header);
                        writer.WriteLine(string.Join(",", data));
                }

                Debug.Log("Data exported to CSV file: " + filePath);
        }

        public void DataExportedTextPopup()
        {
                StartCoroutine("ExportDataPopup", 2f);

        }

        private IEnumerator ExportDataPopup()
        {
                exportDataPopup.SetActive(true);
                yield return new WaitForSeconds(2f);
                exportedLocationText.text = fileN.ToString();
                yield return new WaitForSeconds(5f);
                exportDataPopup.SetActive(false);
                

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




