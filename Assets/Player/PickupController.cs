using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PickupController : MonoBehaviour
{
    public Camera cam;
    public LayerMask IgnoreLayer;
    public float rayDistance = 100f; // Maximum distance for the raycast
    public Text InteractPrompt;
    public GameObject HoveredObject;


    void Start()
    {
        InteractPrompt.enabled = false;
        if (cam == null)
        {
            cam = Camera.main; // Automatically find the main camera if not set
        }
    }

    void Update()
    {
        // Create a Ray starting from the camera's position, pointing in its forward direction
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        RaycastHit hit;

        // Optional: Draw the ray in the scene view for visualization (only visible in the editor)
        Debug.DrawRay(ray.origin, ray.direction * rayDistance, Color.yellow);

        // Perform the raycast
        if (Physics.Raycast(ray, out hit, rayDistance, ~IgnoreLayer))
        {
            // The ray hit an object!
            //Debug.Log("Hit object: " + hit.transform.name + " at point: " + hit.point);
            // You can access information about the hit object here
            // e.g., hit.collider.tag, hit.transform, etc.
            PickableObjectScript pickableScript;

            if (HoveredObject != null && hit.collider.gameObject != HoveredObject)
            {
                if (HoveredObject.CompareTag("Pickup"))
                {
                    pickableScript = HoveredObject.GetComponent<PickableObjectScript>();
                    pickableScript.UnHighlight();
                }
                HoveredObject = null;
            }
            if (hit.collider.CompareTag("Pickup"))
            {
                InteractPrompt.enabled = true;

                HoveredObject = hit.collider.gameObject;
                if (HoveredObject != null)
                {
                    pickableScript = hit.collider.gameObject.GetComponent<PickableObjectScript>();
                    pickableScript.Highlight();
                }
            } else
            {
                InteractPrompt.enabled = false;
            }
        }
        else
        {
            // The ray did not hit anything within the specified distance
            InteractPrompt.enabled = false;
        }
    }

    public void OnInteract()
    {
        //Debug.Log("Pressed Interact");
        if (HoveredObject != null)
        {
            PickableObjectScript pickableScript = HoveredObject.GetComponent<PickableObjectScript>();

            Boolean successfulPickup = pickableScript.Pickup();
            if (successfulPickup)
            {
                HoveredObject = null;
            }
        }
    }
}
