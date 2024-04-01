using System.Collections;
using TMPro;
using UnityEngine;

public class CountDown : MonoBehaviour
{
    public static CountDown instance;
    [SerializeField] TMP_Text countDownText;

    IEnumerator StartCountDown()
    {
        int count = 3;
        while (count > 0)
        {
            countDownText.text = count.ToString();
            yield return new WaitForSeconds(0.4f);
            count--;
        }
        countDownText.text = "Go!";
        yield return new WaitForSeconds(0.4f);
        countDownText.text = "";
    }
    public void CountDowns()
    {
        StartCoroutine(StartCountDown());

    }
    public void Start()
    {
      instance = this;
        StartCoroutine(StartCountDown());
    }
}
