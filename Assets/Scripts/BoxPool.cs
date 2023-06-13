using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BoxPool : MonoBehaviour
{
    public Transform boxSpawnPoint;
    public List<GameObject> boxPrefabs;
    public int maxPoolSize = 60;
    private List<GameObject> boxPool = new List<GameObject>();
    private void Start()
    {
        // Instantiate and populate the object pool
        for (int i = 0; i < maxPoolSize; i++)
        {
            GameObject box = InstantiateBox();
            box.SetActive(false);
            boxPool.Add(box);
        }

        // Start spawning boxes
        StartCoroutine(SpawnBoxes());
    }

    private GameObject InstantiateBox()
    {
        int randomIndex = Random.Range(0, boxPrefabs.Count);
        GameObject boxPrefab = boxPrefabs[randomIndex];
        return Instantiate(boxPrefab, boxSpawnPoint.position, Quaternion.identity);
    }

    private IEnumerator<WaitForSeconds> SpawnBoxes()
    {
        while (true)
        {
            float spawnTime = Random.Range(3f, 8f);
            yield return new WaitForSeconds(spawnTime);
            GameObject box = GetPooledBox();
            if (box != null)
            {
                box.transform.position = boxSpawnPoint.position;
                box.SetActive(true);
            }
        }
    }

    private GameObject GetPooledBox()
    {
        foreach (GameObject box in boxPool)
        {
            if (!box.activeInHierarchy)
            {
                return box;
            }
        }

        // If no inactive box is found, create a new one and expand the pool
        GameObject newBox = InstantiateBox();
        newBox.SetActive(false);
        boxPool.Add(newBox);
        return newBox;
    }
}


