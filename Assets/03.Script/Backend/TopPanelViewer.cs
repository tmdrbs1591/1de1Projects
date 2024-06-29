using UnityEngine;
using TMPro;

public class TopPanelViewer : MonoBehaviour
{
	[SerializeField]
	private	TextMeshProUGUI	textNickname;

	[SerializeField]
	GameObject NickPanel;

    [SerializeField]
    ButtonManager button;

    public void UpdateNickname()
	{
		// 닉네임이 없으면 gamer_id를 출력하고, 닉네임이 있으면 닉네임 출력
		textNickname.text = UserInfo.Data.nickname == null ?
							UserInfo.Data.gamerId : UserInfo.Data.nickname;
		if (UserInfo.Data.nickname == null)
		{
            button.isNikEdit = true;

            NickPanel.SetActive(true);
		}
		else
		{
            NickPanel.SetActive(false);
        }

	}
}

