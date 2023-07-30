using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountDownTextUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countDownText;

	private void Start()
	{
		GameMaster.Instance.OnCountDownChange += GameMaster_OnCountDownChange;
	}

	private void GameMaster_OnCountDownChange(object sender, GameMaster.OnCountDownChangeEventArgs e)
	{
		if(e.countdown < 0f)
		{
			countDownText.gameObject.SetActive(false);
		}
		countDownText.text = e.countdown.ToString("F0");
	}
}
