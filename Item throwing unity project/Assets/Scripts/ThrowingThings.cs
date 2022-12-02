using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThrowingThings : MonoBehaviour
{
    [Header("References")]
    public Transform cam;
    public Transform attackPoint;
    public GameObject objectToThrow;
    public Rigidbody objectRb;

    [Header("Settings")]
    public int totalThrows;
    public float throwCooldown;

    [Header("Throwing")]
    public KeyCode throwKey = KeyCode.Mouse0;
    public float throwForce;
    public float throwUpwardForce;

    bool readyToThrow;

    [Header("HeldItem")]
    public GameObject heldItem;

    [Header("Projectile Trajectory")]
    [SerializeField]
    private LineRenderer lineRenderer;

    [Header("Display Controls")]
    [SerializeField]
    [Range(10, 100)]
    private int linePoints = 25;
    [SerializeField]
    [Range(0.01f, 0.25f)]
    private float timeBetweenPoints = 0.1f;

    [Header("Text")]
    public GameObject textDisplay;

    private void TextToDisplay()
    {
        textDisplay.GetComponent<Text>().text = "Total items left: " + totalThrows;
    }
    private void Start()
    {
        readyToThrow = true;
        objectRb = heldItem.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(Input.GetKey(throwKey) && readyToThrow && totalThrows > 0)
        {
            DrawProjection();
        }
        if (Input.GetKeyUp(throwKey) && readyToThrow && totalThrows > 0)
        {
            Throw();
            lineRenderer.enabled = false;
        }

        if(totalThrows == 0)
        {
            Destroy(heldItem);
        }

        TextToDisplay();
    }

    private void Throw()
    {
        readyToThrow = false;

        // Instantiate object to throw
        GameObject projectile = Instantiate(objectToThrow, attackPoint.position, cam.rotation);

        // Get rigidbody component
        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();

        // Calculate direction
        Vector3 forceDirection = cam.transform.forward;

        RaycastHit hit;

        /*if(Physics.Raycast(cam.position, cam.forward, out hit, 500f))
        {
            forceDirection = (hit.point - attackPoint.position).normalized;
        }*/

        // Add force
        Vector3 forceToAdd = forceDirection * throwForce + transform.up * throwUpwardForce;

        projectileRb.AddForce(forceToAdd, ForceMode.Impulse);

        totalThrows--;

        //implement throwCoolDown;
        Invoke(nameof(ResetThrow), throwCooldown);
    }

    private void ResetThrow()
    {
        readyToThrow = true;
    }

    private void DrawProjection()
    {
        lineRenderer.enabled = true;
        lineRenderer.positionCount = Mathf.CeilToInt(linePoints / timeBetweenPoints) + 1;
        //float TotalForce = throwForce + throwUpwardForce * 3.5f;
        Vector3 startPosition = attackPoint.position;
        Vector3 startVelocity = throwForce * cam.transform.forward + throwUpwardForce * cam.transform.up / objectRb.mass * 1.1f;
        int i = 0;
        lineRenderer.SetPosition(i, startPosition);
        for(float time  = 0; time < linePoints; time += timeBetweenPoints)
        {
            i++;
            Vector3 point = startPosition + time * startVelocity;
            point.y = startPosition.y + startVelocity.y * time + (Physics.gravity.y / 2f * time * time);

            lineRenderer.SetPosition(i, point);

            Vector3 lastPosition = lineRenderer.GetPosition(i - 1) - attackPoint.position.normalized;
        }
    }
}