using UnityEngine;

public class ConveyorBeltAnimation : MonoBehaviour
{
   public Renderer beltRenderer;
   public float scrollX = 0.5f;
   public float scrollY = 0.5f;
   public float scrollSpeed = 0.1f;

   void Start()
   {
      beltRenderer = GetComponent<Renderer>();
   }

   private void FixedUpdate()
   {
      if (ConveyorManager.Instance.power == true)
      {
         float offsetX = Time.time * scrollX * scrollSpeed;
         float offsetY = Time.time * scrollY * scrollSpeed;
         beltRenderer.material.mainTextureOffset = new Vector2(offsetX, offsetY);
      }
   }
}
