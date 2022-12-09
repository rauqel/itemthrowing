using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeStickScript : MonoBehaviour
{
    private Rigidbody knifeRB;

    private bool targetHit;

    private void Start()
    {
        knifeRB = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Target")
        {
            if (targetHit)
                return;
            else
                targetHit = true;

            knifeRB.isKinematic = true;

            transform.SetParent(collision.transform);
        }
    }
}
