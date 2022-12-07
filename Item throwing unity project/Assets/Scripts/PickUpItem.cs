using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    bool itemEquipped;

    public GameObject lastHit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var ray = new Ray(origin: this.transform.position, direction: this.transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, maxDistance: 100))
        {
            lastHit = hit.transform.gameObject;
            Debug.Log(lastHit);
        }
    }
}
