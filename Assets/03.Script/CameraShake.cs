using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake instance;// 싱글톤 인스턴스


    public Camera maincamera; // 흔들릴 메인 카메라
    Vector3 cameraPos;// 카메라 초기 위치 저장 변수

    private void Awake()
    {
        instance = this; // 인스턴스 설정
    }

    [SerializeField]
    [Range(0.1f, 0.5f)]
    float ShakeRange = 0.5f;// 흔들림 범위
    [SerializeField]
    [Range(0.1f, 1f)]
    float duration = 0.1f; //흔들림 지속 시간

    public void Shake()
    {
        cameraPos = maincamera.transform.position;// 현재 카메라 위치 저장
        InvokeRepeating("StartShake", 0f, 0.005f);// 반복 호출을 통한 카메라 흔들기 시작
        Invoke("StopShake", duration);// 일정 시간 후에 흔들기 멈추기 호출
    }

    void StartShake()
    {
        // 랜덤한 흔들림을 생성하여 새로운 카메라 위치 설정
        float CameraPosX = Random.value * ShakeRange * 2 - ShakeRange;
        float CameraPosY = Random.value * ShakeRange * 2 - ShakeRange;

        Vector3 newCameraPos = cameraPos;
        newCameraPos.x += CameraPosX;
        newCameraPos.y += CameraPosY;

        maincamera.transform.position = newCameraPos; // 카메라 위치 변경
    }

    void StopShake() // 카메라 흔들기 중지
    {
        CancelInvoke("StartShake");// 카메라 흔들기 중지
        maincamera.transform.position = cameraPos; // 초기 카메라 위치로 복구
    }
}
