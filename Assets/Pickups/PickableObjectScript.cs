using System;
using System.Linq;
using UnityEngine;

public class PickableObjectScript : MonoBehaviour
{
    public Material OutlineMaterial; // Assign this in the Inspector
    public Boolean Hovered;

    public virtual Boolean Pickup()
    {
        Boolean successfullPickup = true;
        Destroy(gameObject);
        return successfullPickup;
    }

    public void Highlight()
    {
        if (!Hovered)
        {
            Hovered = true;
            foreach (Transform childTransform in transform)
            {
                // Access the GameObject from the Transform component
                Renderer rend = childTransform.gameObject.GetComponent<Renderer>();

                Material[] materials = rend.materials;
                Material[] newMaterials = new Material[materials.Length + 1];
                for (int i = 0; i < materials.Length; i++)
                {
                    newMaterials[i] = materials[i];
                }
                newMaterials[newMaterials.Length - 1] = OutlineMaterial;
                rend.materials = newMaterials;
            }
        }
    }

    public void UnHighlight()
    {
        if (Hovered)
        {
            Hovered = false;
            foreach (Transform childTransform in transform)
            {
                // Access the GameObject from the Transform component
                Renderer rend = childTransform.gameObject.GetComponent<Renderer>();

                Material[] materials = rend.materials;
                Material[] newMaterials = new Material[materials.Length - 1];
                for (int i = 0; i < materials.Length - 1; i++)
                {
                    newMaterials[i] = materials[i];
                }
                rend.materials = newMaterials;
            }
        }
    }
}
