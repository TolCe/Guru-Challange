using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController Instance;

    Camera cam;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else { Instance = this; }

        cam = GetComponent<Camera>();
    }

    public void SetSize(float newSize)
    {
        cam.orthographicSize = newSize;
    }
}
