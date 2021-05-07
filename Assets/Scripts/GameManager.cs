using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else { Instance = this; }
    }

    public void StartGame()
    {
        UIManager.Instance.ChangeActivityOfUIElements(UIManager.Instance.startElements, false);
        UIManager.Instance.ChangeActivityOfUIElements(UIManager.Instance.levelElements, true);
        GridCreator.Instance.CreateGrid();
    }

    public void Restart()
    {
        GridController.Instance.ResetGrid();
        UIManager.Instance.ChangeActivityOfUIElements(UIManager.Instance.levelElements, false);
        UIManager.Instance.ChangeActivityOfUIElements(UIManager.Instance.startElements, true);
    }
}
