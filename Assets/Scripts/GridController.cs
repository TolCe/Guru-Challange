using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    public static GridController Instance;

    public Box[,] grid;
    public List<Box> connectedBoxes = new List<Box>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else { Instance = this; }
    }

    public void SetGrid(int width)
    {
        grid = new Box[width, width];
    }

    public void SetGridElement(int indexRow, int indexColumn, Box box)
    {
        grid[indexRow, indexColumn] = box;
        box.SetGridIndex(indexRow, indexColumn);
    }

    public void AddConnectedBoxes(Box box)
    {
        if (!connectedBoxes.Contains(box))
        {
            connectedBoxes.Add(box);
        }
    }
    public void CheckConnectedBoxes()
    {
        for (int i = 0; i < connectedBoxes.Count; i++)
        {
            connectedBoxes[i].CheckNeighbours();
        }

        if (connectedBoxes.Count >= 3)
        {
            for (int i = 0; i < connectedBoxes.Count; i++)
            {
                connectedBoxes[i].ResetBox();
            }

            connectedBoxes = new List<Box>();
        }
        else
        {
            connectedBoxes = new List<Box>();
        }
    }
}
