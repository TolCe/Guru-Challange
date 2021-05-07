using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPool : MonoBehaviour
{
    public static BoxPool Instance;

    List<GameObject> pool = new List<GameObject>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else { Instance = this; }
    }

    public Box TakeFromPool(Transform boxParent, Vector2 boxPosition)
    {
        GameObject boxObj = null;

        if (pool.Count == 0)
        {
            GameObject boxPrefab = Resources.Load("Box") as GameObject;
            boxObj = Instantiate(boxPrefab, boxParent);
        }
        else
        {
            boxObj = pool[0];
            pool.RemoveAt(0);
            boxObj.SetActive(true);
        }

        boxObj.transform.position = boxPosition;
        return boxObj.GetComponent<Box>();
    }

    public void PutBackIntoPool(Box objToPut)
    {
        objToPut.ResetBox();
        pool.Add(objToPut.gameObject);
        objToPut.gameObject.SetActive(false);
    }
}
