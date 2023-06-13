using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PerfectBoxCount : MonoBehaviour
{
    public TextMeshProUGUI perfectBoxCountText;
    private int _perfectBoxCount;
    private void OnTriggerEnter(Collider other)
    {
        Boxes boxVar = other.gameObject.GetComponent<Boxes>();
        if (boxVar != null )
        {
            _perfectBoxCount = _perfectBoxCount + 1;
            perfectBoxCountText.text = _perfectBoxCount.ToString();
        }
    }
}
