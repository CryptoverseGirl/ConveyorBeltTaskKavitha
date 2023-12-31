using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    [SerializeField]
    private float conveyorSpeed;
    [SerializeField]
    private List<GameObject> onBelt;
    private Rigidbody rb;
    private float distance = 1f;
    private Material material;
    void Start()
    {
        material = GetComponent<MeshRenderer>().material;
        rb = gameObject.GetComponent<Rigidbody> ();
        rb.isKinematic = true;
        rb.useGravity = false;
    }

    // Update is called once per frame
    private void Update()
    {
        // Move the conveyor belt texture to make it look like it's moving
        GetComponent<MeshRenderer>().material.mainTextureOffset += new Vector2(0, 1) * conveyorSpeed * Time.deltaTime;
    }

    // Fixed update for physics
    void FixedUpdate()
    {
        // For every item on the belt, add force to it in the direction given
            Vector3 mov = transform.forward * Time.fixedDeltaTime * conveyorSpeed/ distance;
            rb.position =  (rb.position - mov);
            rb.MovePosition (rb.position + mov);
        
    }

    // When something collides with the belt
    private void OnCollisionEnter(Collision collision)
    {
        onBelt.Add(collision.gameObject);
    }

    // When something leaves the belt
    private void OnCollisionExit(Collision collision)
    {
        onBelt.Remove(collision.gameObject);
    }
}



