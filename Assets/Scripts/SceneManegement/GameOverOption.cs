using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverOption : MonoBehaviour
{
    public Text optionText;

    private Color selectedColor = new Color(251f / 255f, 189f / 255f, 160f / 255f);
    private Color deselectedColor = new Color(255f / 255f, 213f / 255f, 213f / 255f);

    public void SelectOption()
    {
        optionText.color = selectedColor;
    }

    public void DeselectOption()
    {
        optionText.color = deselectedColor;
    }


}
