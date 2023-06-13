using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConveyorBeltLarge : MonoBehaviour
{
    [SerializeField] private Transform reachPoint;
    public float conveyorSpeed = 0.1f;
    private int _spawnedBoxCount;
    public TextMeshProUGUI totalSpawnedBoxCountText;
    void OnTriggerStay(Collider other)
    {
        Boxes boxVar = other.gameObject.GetComponent<Boxes>();
        if (boxVar != null)
        {
            MoveConveyorBelt(other);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Boxes boxVar = other.gameObject.GetComponent<Boxes>();
        if (boxVar != null && GetComponent<ConveyorSpawnBelt>())
        {
            _spawnedBoxCount = _spawnedBoxCount + 1;
            totalSpawnedBoxCountText.text = _spawnedBoxCount.ToString();
        }
    }

    void MoveConveyorBelt(Collider other)
    {
        if (ConveyorManager.Instance.power == true)
        {
            other.transform.position = Vector3.MoveTowards(other.transform.position, reachPoint.position,
                conveyorSpeed * Time.deltaTime);
        }
    }
}
