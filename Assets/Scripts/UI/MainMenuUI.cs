using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{

    [SerializeField] private Button level1Button;
    [SerializeField] private Button level2Button;
    [SerializeField] private Button level3Button;
    [SerializeField] private Button level4Button;
    [SerializeField] private Button level5Button;
    [SerializeField] private Button level6Button;
    [SerializeField] private Button quitButton;


	private void Awake()
	{
		level1Button.onClick.AddListener(() =>
		{
			Loader.Load(Loader.Scene.Level1);
		});

		level2Button.onClick.AddListener(() =>
		{
			Loader.Load(Loader.Scene.Level2);
		});

		level3Button.onClick.AddListener(() =>
		{
			Loader.Load(Loader.Scene.Level3);
		});

		level4Button.onClick.AddListener(() =>
		{
			Loader.Load(Loader.Scene.Level4);
		});

		level5Button.onClick.AddListener(() =>
		{
			Loader.Load(Loader.Scene.Level5);
		});

		level6Button.onClick.AddListener(() =>
		{
			Loader.Load(Loader.Scene.Level6);
		});

		quitButton.onClick.AddListener(() =>
		{
			Application.Quit();
		});

		Time.timeScale = 1f;
	}

}
