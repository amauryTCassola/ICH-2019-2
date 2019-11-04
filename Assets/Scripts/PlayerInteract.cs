using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteract : MonoBehaviour
{
    private const string interactableObjectTag = "Interactable";
    private const string interactionFunctionName = "Interact";
    private const string interactionButton = "e";

    private GameObject raycastObj;

    [SerializeField] private int rayLength = 10;
    [SerializeField] private LayerMask layerMaskInteract;
    public GameObject interactText;

    void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, fwd, out hit, rayLength, layerMaskInteract.value))
        {

            if (hit.collider.CompareTag(interactableObjectTag))
            {
                raycastObj = hit.collider.gameObject;

                interactText.SetActive(true);

                if (Input.GetKeyDown(interactionButton))
                {
                    raycastObj.SendMessage(interactionFunctionName);
                }
            }
            else
            {
                interactText.SetActive(false);
            }
        }
        else
        {
            interactText.SetActive(false);
        }
    }

}