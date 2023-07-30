using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinTextUI : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI coinText;


	private void Start()
	{
		GameMaster.Instance.OnCoinChange += GameMaster_OnCoinChange;
	}

	private void GameMaster_OnCoinChange(object sender, GameMaster.OnCoinIncreaseEventArgs e)
	{
		coinText.text = e.coin.ToString();
	}
}
