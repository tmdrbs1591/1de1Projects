using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum KeyAction { TOP, MID, BOTTOM, KEYCOUNT }

public static class KeySetting
{
    public static Dictionary<KeyAction, KeyCode> keys = new Dictionary<KeyAction, KeyCode>()
    {
        { KeyAction.TOP, KeyCode.Q },
        { KeyAction.MID, KeyCode.W },
        { KeyAction.BOTTOM, KeyCode.E }
    };
}

public class KeyManager : MonoBehaviour
{
    KeyCode[] defaultKeys = new KeyCode[] { KeyCode.Q, KeyCode.W, KeyCode.E };

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        // Initialize keys dictionary with default keys
        for (int i = 0; i < (int)KeyAction.KEYCOUNT; i++)
        {
            KeySetting.keys[(KeyAction)i] = defaultKeys[i];
        }
    }

    private void OnGUI()
    {
        Event keyEvent = Event.current;
        if (keyEvent.isKey && key != -1 && key < (int)KeyAction.KEYCOUNT)
        {
            KeySetting.keys[(KeyAction)key] = keyEvent.keyCode;
            key = -1;
        }
    }

    int key = -1;

    public void ChangeKey(int num)
    {
        if (num >= 0 && num < (int)KeyAction.KEYCOUNT)
        {
            key = num;
        }
        else
        {
            Debug.LogError("Invalid key number!");
        }
    }
}
