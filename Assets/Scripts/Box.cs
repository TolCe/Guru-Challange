using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public bool isSelected;
    GameObject attachedX;
    Collider boxColl;
    [SerializeField] int[] gridIndex;

    private void Awake()
    {
        attachedX = transform.GetChild(0).gameObject;
        boxColl = GetComponent<Collider>();
    }

    public void GetHit()
    {
        SetBox(true);
        PutIntoTheBox();
        GridController.Instance.CheckConnectedBoxes();
    }
    public void ResetBox()
    {
        SetBox(false);
    }

    void SetBox(bool state)
    {
        isSelected = state;
        attachedX.SetActive(state);
        boxColl.enabled = !state;
    }

    public void CheckNeighbours()
    {
        if (gridIndex[0] > 0)
        {
            if (GridController.Instance.grid[gridIndex[0] - 1, gridIndex[1]].isSelected)
            {
                GridController.Instance.grid[gridIndex[0] - 1, gridIndex[1]].PutIntoTheBox();
            }
        }
        if (gridIndex[0] < GridController.Instance.grid.GetLength(0) - 1)
        {
            if (GridController.Instance.grid[gridIndex[0] + 1, gridIndex[1]].isSelected)
            {
                GridController.Instance.grid[gridIndex[0] + 1, gridIndex[1]].PutIntoTheBox();
            }
        }
        if (gridIndex[1] > 0)
        {
            if (GridController.Instance.grid[gridIndex[0], gridIndex[1] - 1].isSelected)
            {
                GridController.Instance.grid[gridIndex[0], gridIndex[1] - 1].PutIntoTheBox();
            }
        }
        if (gridIndex[1] < GridController.Instance.grid.GetLength(1) - 1)
        {
            if (GridController.Instance.grid[gridIndex[0], gridIndex[1] + 1].isSelected)
            {
                GridController.Instance.grid[gridIndex[0], gridIndex[1] + 1].PutIntoTheBox();
            }
        }
    }

    public void PutIntoTheBox()
    {
        GridController.Instance.AddConnectedBoxes(this);
    }

    public void SetGridIndex(int indexRow, int indexColumn)
    {
        gridIndex = new int[2] { indexRow, indexColumn };
    }
}
