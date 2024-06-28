using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;
using System.Collections;
public class MenuBtn : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] float startDelay;
    [SerializeField] float scaleDuration = 0.2f; // 스케일 애니메이션 실행 시간
    [SerializeField] Vector3 scaleUp = new Vector3(1.2f, 1.2f, 1.2f); // 마우스 오버 시 스케일

    public Material outlineMaterial; // 아웃라인 메테리얼

    private Image buttonImage;
    private Material originalMaterial; // 기본 메테리얼 저장 변수

    void Start()
    {
        buttonImage = GetComponent<Image>();
        originalMaterial = buttonImage.material;

        StartCoroutine(AnimateButton());
    }

    IEnumerator AnimateButton()
    {
        // 버튼의 초기 위치를 위로 이동시킵니다.
        Vector3 startPos = transform.position + new Vector3(0, 10, 0); // 10은 임의의 값입니다.
        transform.position = startPos;
        yield return new WaitForSeconds(startDelay);
        // 버튼을 아래로 내린 후 살짝 튀어오르게 하는 애니메이션
        transform.DOMoveY(transform.position.y - 10, 1f).SetEase(Ease.OutBounce);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // 마우스가 버튼 위에 있을 때 아웃라인 메테리얼로 교체합니다.
        buttonImage.material = outlineMaterial;

        // 추가적인 애니메이션 등을 실행할 수 있습니다.
        transform.DOScale(scaleUp, scaleDuration).SetEase(Ease.OutSine);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // 마우스가 버튼에서 벗어날 때 기본 메테리얼로 교체합니다.
        buttonImage.material = originalMaterial;

        // 추가적인 애니메이션 등을 실행할 수 있습니다.
        transform.DOScale(Vector3.one, scaleDuration).SetEase(Ease.OutSine);
    }

    void Update()
    {

    }
}
