using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public GameObject startElements;
    public GameObject levelElements;
    public Text widthText;
    public Slider widthSlider;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else { Instance = this; }
    }
    private void Start()
    {
        UpdateWidth();

        ChangeActivityOfUIElements(startElements, true);
        ChangeActivityOfUIElements(levelElements, false);
    }

    public void ChangeText(Text aText, string aMessage)
    {
        aText.text = aMessage;
    }

    public void UpdateWidth()
    {
        ChangeText(widthText, "Grid Size: " + (widthSlider.value + 3) + "x" + (widthSlider.value + 3));
        GridCreator.Instance.gridWidth = (int)widthSlider.value + 3;
    }

    public void ChangeActivityOfUIElements(GameObject anObject, bool state)
    {
        anObject.SetActive(state);
    }
}
