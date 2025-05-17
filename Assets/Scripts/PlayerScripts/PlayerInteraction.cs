using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public IInteractable focusedInteractable;
    public LayerMask layerMask;
    public Camera mainCamera;
    public float baseInteractRange;
    public float interactRange;
    public float interactRadius;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        DetectInteractable();
        interactRadius = transform.localScale.x;
        interactRange = baseInteractRange * transform.localScale.x;
        if (focusedInteractable != null && Input.GetKeyDown(KeyCode.E))
        {
            focusedInteractable.Interact();
        }
    }

    void DetectInteractable()
    {
        RaycastHit hit;
        if (Physics.SphereCast(transform.position + Vector3.up*transform.localScale.y*2, interactRadius, transform.forward, out hit, interactRange, layerMask))
        {
            if (focusedInteractable != hit.transform.GetComponent<IInteractable>())
            {
                focusedInteractable = hit.transform.GetComponent<IInteractable>();
                Debug.Log("Interactable detected");
            }

        }
        else
        {
            focusedInteractable = null;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position + Vector3.up * transform.localScale.y*2 + transform.forward * interactRange, interactRadius);
    }
}
