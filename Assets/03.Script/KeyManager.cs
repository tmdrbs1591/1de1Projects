using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum KeyAction { Q, W, E, D, F, J, K, KEYCOUNT }

public static class KeySetting
{
    public static Dictionary<KeyAction, KeyCode> keys = new Dictionary<KeyAction, KeyCode>()
    {
        { KeyAction.Q, KeyCode.Q },
        { KeyAction.W, KeyCode.W },
        { KeyAction.E, KeyCode.E },
        { KeyAction.D, KeyCode.D },
        { KeyAction.F, KeyCode.F },
        { KeyAction.J, KeyCode.J },
        { KeyAction.K, KeyCode.K }
    };
}


public class KeyManager : MonoBehaviour
{
    KeyCode[] defaultKeys = new KeyCode[] { KeyCode.Q, KeyCode.W, KeyCode.E, KeyCode.D, KeyCode.F, KeyCode.J, KeyCode.K };

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        // 기본 키로 키 사전 초기화
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
            Debug.LogError("유효하지 않은 키 번호입니다!");
        }
    }
}
