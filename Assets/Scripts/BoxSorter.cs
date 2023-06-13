using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSorter : MonoBehaviour
{
   public GameObject DamagedBoxesSorterCube;
   public BoxType outputDamaged;
   [Space(6)]
   public GameObject PerfectBoxesSorterCube;
   public BoxType outputPerfect;

  private void OnTriggerEnter(Collider other)
   {
      Boxes boxVar = other.gameObject.GetComponent<Boxes>();
      if (boxVar != null)
      {
         if (boxVar.box.boxType == outputDamaged)
         {
            other.transform.position = DamagedBoxesSorterCube.transform.position;
         }
         if (boxVar.box.boxType == outputPerfect)
         {
            other.transform.position = PerfectBoxesSorterCube.transform.position;
         }
      }
   }
}
