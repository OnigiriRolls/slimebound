using System;
using UnityEngine;

public class LaserMovement : MonoBehaviour
{
    public Camera cam;
    public LineRenderer lineRenderer;
    public Transform firePoint;

    void Start()
    {
        DisableLaser();
    }

    void Update()
    {
        if (lineRenderer.enabled)
        {
            UpdateLaser();
        }
    }

    private void UpdateLaser()
    {
        throw new NotImplementedException();
    }

    public void EnableLaser()
    {
        lineRenderer.enabled = true;
    }
    public void DisableLaser()
    {
        lineRenderer.enabled = false;
    }
}
