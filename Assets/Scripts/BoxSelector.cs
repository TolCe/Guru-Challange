using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSelector : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            SendRay(ray);
        }
    }

    void SendRay(Ray sentRay)
    {
        RaycastHit hit;

        if (Physics.Raycast(sentRay, out hit))
        {
            Box hitBox = hit.transform.GetComponent<Box>();

            if (hitBox != null)
            {
                hitBox.GetHit();
            }
        }
    }
}
