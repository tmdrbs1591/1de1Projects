using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoldManager : MonoBehaviour
{
    public static GoldManager instance;

    public int allGold;

    [SerializeField]
    private int branch;
    [SerializeField]
    private string tier;
    [SerializeField]
    private DataBase database;

    [SerializeField] TMP_Text goldText;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
        goldText.text = database.Entities[6].gold.ToString();

        if (Input.GetKeyDown(KeyCode.B))
        {
            CrearGold("S");
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            database.Entities[6].gold = 0;
        }
    }
    public void CrearGold(string clearTier)
    {
        for (int i = 0; i < database.Entities.Count; ++i)
        {
            if (database.Entities[i].tier == clearTier)
            {
                database.Entities[6].gold += database.Entities[i].gold;
                Debug.Log(database.Entities[6].gold);
            }
        }
    }


}
