using UnityEngine;
using TMPro;

public class DropDown : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    public GameController gameController;

    private void Start()
    {
        dropdown.onValueChanged.AddListener(delegate {
            DropdownValueChanged(dropdown);
        });
    }

    void DropdownValueChanged(TMP_Dropdown dropdown)
    {
        int selectedIndex = dropdown.value;
        string selectedOption = dropdown.options[selectedIndex].text;

        switch (selectedOption)
        {
            case "yacht":
                // 设置数值为某个值
                SetNumericValue(0);
                break;
            case "rowing machine":
                // 设置数值为另一个值
                SetNumericValue(1);
                break;
            case "padalo":
                SetNumericValue(2);
                break;
        }
    }

    void SetNumericValue(int value)
    {
        gameController.shipType = value;
    }
}
