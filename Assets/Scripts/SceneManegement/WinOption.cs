using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinOption : MonoBehaviour
{
    public Text optionText;

    private Color selectedColor = new Color(255f / 255f, 215f / 255f, 0f / 255f);
    private Color deselectedColor = new Color(150f / 255f, 243f / 255f, 232f / 255f);

    public void SelectOption()
    {
        optionText.color = selectedColor;
    }

    public void DeselectOption()
    {
        optionText.color = deselectedColor;
    }

}
