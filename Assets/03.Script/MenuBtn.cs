using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;
using System.Collections;
public class MenuBtn : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] float startDelay;
    [SerializeField] float scaleDuration = 0.2f; // ������ �ִϸ��̼� ���� �ð�
    [SerializeField] Vector3 scaleUp = new Vector3(1.2f, 1.2f, 1.2f); // ���콺 ���� �� ������

    public Material outlineMaterial; // �ƿ����� ���׸���

    private Image buttonImage;
    private Material originalMaterial; // �⺻ ���׸��� ���� ����

    void Start()
    {
        buttonImage = GetComponent<Image>();
        originalMaterial = buttonImage.material;

        StartCoroutine(AnimateButton());
    }

    IEnumerator AnimateButton()
    {
        // ��ư�� �ʱ� ��ġ�� ���� �̵���ŵ�ϴ�.
        Vector3 startPos = transform.position + new Vector3(0, 10, 0); // 10�� ������ ���Դϴ�.
        transform.position = startPos;
        yield return new WaitForSeconds(startDelay);
        // ��ư�� �Ʒ��� ���� �� ��¦ Ƣ������� �ϴ� �ִϸ��̼�
        transform.DOMoveY(transform.position.y - 10, 1f).SetEase(Ease.OutBounce);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // ���콺�� ��ư ���� ���� �� �ƿ����� ���׸���� ��ü�մϴ�.
        buttonImage.material = outlineMaterial;

        // �߰����� �ִϸ��̼� ���� ������ �� �ֽ��ϴ�.
        transform.DOScale(scaleUp, scaleDuration).SetEase(Ease.OutSine);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // ���콺�� ��ư���� ��� �� �⺻ ���׸���� ��ü�մϴ�.
        buttonImage.material = originalMaterial;

        // �߰����� �ִϸ��̼� ���� ������ �� �ֽ��ϴ�.
        transform.DOScale(Vector3.one, scaleDuration).SetEase(Ease.OutSine);
    }

    void Update()
    {

    }
}
