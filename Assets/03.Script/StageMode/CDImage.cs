using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CDImage : MonoBehaviour
{
    public Image cDimage; // 이미지 컴포넌트 선언
    public Sprite[] cdSprites; // 스프라이트 배열 선언

    void Update()
    {
        // 현재 스테이지에 따라 이미지를 변경합니다.
        switch (StageModeStageManager.instance.currentStage)
        {
            case StageModeStageManager.Stage.FirstTheFirstStage:
                cDimage.sprite = cdSprites[0];
                break;
            case StageModeStageManager.Stage.FirstTheSecondStage:
                cDimage.sprite = cdSprites[1];
                break;
            case StageModeStageManager.Stage.FirstTheThirdStage:
                cDimage.sprite = cdSprites[2];
                break;
            case StageModeStageManager.Stage.FirstThefourthStage:
                cDimage.sprite = cdSprites[3];
                break;
            case StageModeStageManager.Stage.FirstThefifthStage:
                cDimage.sprite = cdSprites[4];
                break;
            case StageModeStageManager.Stage.FirstTheSixthStage:
                cDimage.sprite = cdSprites[5];
                break;
            case StageModeStageManager.Stage.FirstTheSeventhStage:
                cDimage.sprite = cdSprites[6];
                break;
            case StageModeStageManager.Stage.FirstTheEighthStage:
                cDimage.sprite = cdSprites[7];
                break;
            default:
                // 기본값 처리 (필요에 따라 추가)
                break;
        }
    }
}
