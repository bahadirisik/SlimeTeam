using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelCompletedUI : MonoBehaviour
{

    [SerializeField] private Transform levelCompletedUI;
    [SerializeField] private Transform levelFailedUI;
    [SerializeField] private Button levelCompletedButton;
    [SerializeField] private Button levelFailedButton;

	private void Start()
	{
		Hide(levelCompletedUI);
		Hide(levelFailedUI);

		GameMaster.Instance.OnLevelCompleted += GameMaster_OnLevelCompleted;
		GameMaster.Instance.OnLevelFailed += GameMaster_OnLevelFailed;

		levelCompletedButton.onClick.AddListener(() => {
			LoadMainMenu();
		});

		levelFailedButton.onClick.AddListener(() => {
			LoadMainMenu();
		});
	}

	private void GameMaster_OnLevelFailed(object sender, System.EventArgs e)
	{
		Show(levelFailedUI);
	}

	private void GameMaster_OnLevelCompleted(object sender, System.EventArgs e)
	{
		Show(levelCompletedUI);
	}

	void Show(Transform panel)
	{
		panel.gameObject.SetActive(true);
	}

	void Hide(Transform panel)
	{
		panel.gameObject.SetActive(false);
	}

	void LoadMainMenu()
	{
		Loader.Load(Loader.Scene.MainMenuScene);
	}

}
