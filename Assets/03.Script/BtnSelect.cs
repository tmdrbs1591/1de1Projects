using UnityEngine;
using UnityEngine.UI;

public class BtnSelect : MonoBehaviour
{
    public Button[] buttons; // 버튼 배열 선언

    void Start()
    {
       
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            if (!IsAnyButtonSelected())
            {
                SelectFirstButton();
            }
        }
    }

    bool IsAnyButtonSelected()
    {
        foreach (Button button in buttons)
        {
            if (button != null && button.gameObject == UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject)
            {
                return true;
            }
        }
        return false;
    }

    void SelectFirstButton()
    {
        if (buttons.Length > 0 && buttons[0] != null)
        {
            buttons[0].Select();
        }
    }
}
