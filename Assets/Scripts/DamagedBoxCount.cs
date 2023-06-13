using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DamagedBoxCount : MonoBehaviour
{
    public TextMeshProUGUI damagedBoxCountText;
    private int _damagedBoxCount;
    private void OnTriggerEnter(Collider other)
    {
        Boxes boxVar = other.gameObject.GetComponent<Boxes>();
        if (boxVar != null )
        {
            _damagedBoxCount = _damagedBoxCount + 1;
            damagedBoxCountText.text = _damagedBoxCount.ToString();
        }
    }
}
