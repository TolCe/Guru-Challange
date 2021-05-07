using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCreator : MonoBehaviour
{
    public static GridCreator Instance;

    [HideInInspector] public int gridWidth;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else { Instance = this; }
    }

    public void CreateGrid()
    {
        GridController.Instance.SetGrid(gridWidth);

        float xPos = 0;
        float yPos = (gridWidth - 1) * 0.5f * 2.75f;

        for (int i = 0; i < gridWidth; i++)
        {
            xPos = -(gridWidth - 1) * 0.5f * 2.75f;

            for (int j = 0; j < gridWidth; j++)
            {
                GridController.Instance.SetGridElement(i, j, BoxPool.Instance.TakeFromPool(transform, new Vector2(xPos, yPos)));
                xPos += 2.75f;
            }

            yPos -= 2.75f;
        }

        if (Screen.width <= Screen.height)
        {
            CameraController.Instance.SetSize(gridWidth * 1.5f * ((float)Screen.height / Screen.width));
        }
        else
        {
            CameraController.Instance.SetSize(gridWidth * ((float)Screen.width / Screen.height));
        }
    }
}
