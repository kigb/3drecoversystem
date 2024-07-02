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
                // ������ֵΪĳ��ֵ
                SetNumericValue(0);
                break;
            case "rowing machine":
                // ������ֵΪ��һ��ֵ
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
