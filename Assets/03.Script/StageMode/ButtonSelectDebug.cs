using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonSelectDebug : MonoBehaviour
{

    void Update()
    {
     
        // ���� ���õ� UI ��Ҹ� ������
        GameObject selectedObject = EventSystem.current.currentSelectedGameObject;

        // ���õ� UI ��Ұ� ���� ���� ó��
        if (selectedObject != null)
        {
            StageModeStageManager.Stage newStage = StageModeStageManager.Stage.FirstTheFirstStage;

            // ��ư�� �̸��� ���� �������� ����
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
           
            // �������� ����
            StageModeStageManager.instance.currentStage = newStage;
        }
    }
}
