using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoldManager : MonoBehaviour
{
    public static GoldManager instance;
    public int allGold;

    [SerializeField] TMP_Text goldText;
    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        goldText.text = allGold.ToString();
    }
}
