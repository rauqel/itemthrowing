using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KnifeStickScript : MonoBehaviour
{
    public int damage;

    public Rigidbody knifeRB;
    public ThrowingThings throwScript;
    public bool targetHit;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Target")
        {
            if (targetHit)
            {
                return;
            }
            else
            {
                targetHit = true;
            }

            knifeRB.isKinematic = true;

            transform.SetParent(collision.transform);
        }

        if(collision.gameObject.GetComponent<TargetHealth>() != null)
        {
            TargetHealth target = collision.gameObject.GetComponent<TargetHealth>();

            target.TakeDamage(damage);

            if(target == null)
            {
                Destroy(gameObject);
            }
        }
        
    }
}
