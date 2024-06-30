using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonSelectDebug : MonoBehaviour
{

    void Update()
    {
     
        // 현재 선택된 UI 요소를 가져옴
        GameObject selectedObject = EventSystem.current.currentSelectedGameObject;

        // 선택된 UI 요소가 있을 때만 처리
        if (selectedObject != null)
        {
            StageModeStageManager.Stage newStage = StageModeStageManager.Stage.FirstTheFirstStage;

            // 버튼의 이름에 따라 스테이지 설정
            switch (selectedObject.name)
            {
                case "Stage1-1": newStage = StageModeStageManager.Stage.FirstTheFirstStage; break;
                case "Stage1-2": newStage = StageModeStageManager.Stage.FirstTheSecondStage; break;
                case "Stage1-3": newStage = StageModeStageManager.Stage.FirstTheThirdStage; break;
                case "Stage1-4": newStage = StageModeStageManager.Stage.FirstThefourthStage; break;
                case "Stage1-5": newStage = StageModeStageManager.Stage.FirstThefifthStage; break;
                case "Stage1-6": newStage = StageModeStageManager.Stage.FirstTheSixthStage; break;
                case "Stage1-7": newStage = StageModeStageManager.Stage.FirstTheSeventhStage; break;
                case "Stage1-8": newStage = StageModeStageManager.Stage.FirstTheEighthStage; break;
                default:
                    newStage = StageModeStageManager.Stage.Main; 
                    break;
            }
           
            // 스테이지 변경
            StageModeStageManager.instance.currentStage = newStage;
        }
    }
}
