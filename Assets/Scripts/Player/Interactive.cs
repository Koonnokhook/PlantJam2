using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactive: MonoBehaviour
{
    public Transform InteractorSource;
    public float InteractRange;

    private Outline lastHighlightedObject; // Reference to the last highlighted object.


    public interface IInteractable
    {
        void Interact();
    }


    void Start()
    {

    }

    public void Update() 
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = new Ray(InteractorSource.position, InteractorSource.forward);
            if (Physics.Raycast(ray, out RaycastHit hitInfo, InteractRange))
            {
                IInteractable interactObj = hitInfo.collider.gameObject.GetComponent<IInteractable>();

                if (interactObj != null)
                {
                    interactObj.Interact();
                    Debug.Log("You touched an interactable object.");
                }

                // Highlight the object if it has an Outline component.
                HighlightObject(hitInfo.collider.gameObject.GetComponent<Outline>());
            }
            else
            {
                // Remove the highlight from the last object.
                UnhighlightLastObject();
            }
        }
        else
        {
            // Remove the highlight from the last object when not interacting.
            UnhighlightLastObject();
        }
    }

    // Highlight the object with an Outline component.
    private void HighlightObject(Outline outline)
    {
        if (outline != null)
        {
            outline.enabled = true;

            // Remove the highlight from the last object.
            UnhighlightLastObject();

            // Store the highlighted object for future reference.
            lastHighlightedObject = outline;
        }
    }

    // Remove the highlight from the last highlighted object.
    private void UnhighlightLastObject()
    
    {
        if (lastHighlightedObject != null)
        {
            lastHighlightedObject.enabled = false;
            lastHighlightedObject = null;
        }
    }
}
