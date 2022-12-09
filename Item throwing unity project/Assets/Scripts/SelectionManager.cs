using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour
{
    public Text pickUpPrompt;
    public ThrowingThings throwScript;

    KeyCode pickUp = KeyCode.Mouse1;

    // Start is called before the first frame update
    void Start()
    {
        pickUpPrompt.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;
            var selectionRenderer = selection.GetComponent<Renderer>();
            if(hit.transform.CompareTag("Snowball") || hit.transform.CompareTag("Throwing Knife") && selectionRenderer != null)
            {
                pickUpPrompt.enabled = true;
            }
            else
            {
                pickUpPrompt.enabled = false;
            }

            if(hit.transform.CompareTag("Snowball") && Input.GetKeyDown(pickUp))
            {
                throwScript.heldItem = throwScript.sbHeldItem;
                Debug.Log(throwScript.heldItem.name);
            }
            if (hit.transform.CompareTag("Throwing Knife") && Input.GetKeyDown(pickUp))
            {
                throwScript.heldItem = throwScript.tkHeldItem;
                Debug.Log(throwScript.heldItem.name);
            }
        }
    }
}
