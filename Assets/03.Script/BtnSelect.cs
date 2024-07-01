using UnityEngine;
using UnityEngine.UI;

public class BtnSelect : MonoBehaviour
{
    public Button[] buttons; // 버튼 배열 선언

    public KeyCode key;
    public KeyCode key2;
    public KeyCode key3;
    public KeyCode key4;
    public string type;

    public GameObject MenuBtn;
    public GameObject SettingBtn;

    public ButtonManager buttonManager;
    private void OnEnable()
    {
        if (type == "StageModeBtn")
            SelectFirstButton();
        if (type == "SettingBtn")
            MenuBtn.SetActive(false);

        if (type == "NextSettingBtn")
        {
            SettingBtn.SetActive(false);
            MenuBtn.SetActive(false);

        }

    }
    private void OnDisable()
    {
        SelectFirstButton();
        if (type == "SettingBtn")
            MenuBtn.SetActive(true);
        if (type == "NextSettingBtn")
            SettingBtn.SetActive(true);
    }
    void Update()
    {
        if (!buttonManager.isNavimpossible) { 
        if (Input.GetKeyDown(key) || Input.GetKeyDown(key2) || Input.GetKeyDown(key3) || Input.GetKeyDown(key4))
        {
            if (!IsAnyButtonSelected())
            {
                SelectFirstButton();
            }
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
