using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake instance;// �̱��� �ν��Ͻ�


    public Camera maincamera; // ��鸱 ���� ī�޶�
    Vector3 cameraPos;// ī�޶� �ʱ� ��ġ ���� ����

    private void Awake()
    {
        instance = this; // �ν��Ͻ� ����
    }

    [SerializeField]
    [Range(0.1f, 0.5f)]
    float ShakeRange = 0.5f;// ��鸲 ����
    [SerializeField]
    [Range(0.1f, 1f)]
    float duration = 0.1f; //��鸲 ���� �ð�

    public void Shake()
    {
        cameraPos = maincamera.transform.position;// ���� ī�޶� ��ġ ����
        InvokeRepeating("StartShake", 0f, 0.005f);// �ݺ� ȣ���� ���� ī�޶� ���� ����
        Invoke("StopShake", duration);// ���� �ð� �Ŀ� ���� ���߱� ȣ��
    }

    void StartShake()
    {
        // ������ ��鸲�� �����Ͽ� ���ο� ī�޶� ��ġ ����
        float CameraPosX = Random.value * ShakeRange * 2 - ShakeRange;
        float CameraPosY = Random.value * ShakeRange * 2 - ShakeRange;

        Vector3 newCameraPos = cameraPos;
        newCameraPos.x += CameraPosX;
        newCameraPos.y += CameraPosY;

        maincamera.transform.position = newCameraPos; // ī�޶� ��ġ ����
    }

    void StopShake() // ī�޶� ���� ����
    {
        CancelInvoke("StartShake");// ī�޶� ���� ����
        maincamera.transform.position = cameraPos; // �ʱ� ī�޶� ��ġ�� ����
    }
}
