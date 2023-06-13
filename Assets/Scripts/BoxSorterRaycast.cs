using UnityEngine;

public class BoxSorterRaycast : MonoBehaviour
{ 
    public GameObject DamagedBoxesSorterCube;
    public BoxType outputDamaged;
    [Space(6)]
    public GameObject PerfectBoxesSorterCube;
    public BoxType outputPerfect;
    private void Update()
    {
        SortBox();
    }

    private void SortBox()
    {
        Ray ray = new Ray(transform.position, -Vector3.up);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            GameObject box = hit.collider.gameObject;
            Boxes boxVar = box.GetComponent<Boxes>();
            if (boxVar != null)
            {
                if (boxVar.box.boxType == outputDamaged)
                {
                    box.transform.position = DamagedBoxesSorterCube.transform.position;
                }
                else if (boxVar.box.boxType == outputPerfect)
                {
                    box.transform.position = PerfectBoxesSorterCube.transform.position;
                }
            }
        }
        //Debug.DrawRay(ray.origin, ray.direction * 10f, Color.red, 1f);
    }
}


