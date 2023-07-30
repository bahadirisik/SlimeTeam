using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Merge : MonoBehaviour
{
	public static Merge Instance { get; private set; }

	public event EventHandler<OnMergeUpgradeSuccessEventArgs> OnMergeUpgradeSuccess;
	public class OnMergeUpgradeSuccessEventArgs : EventArgs
	{
		public Button upgradeMergeButton;
	}

	public List<PlayerMergeSO> playerMergeSOList;
	[SerializeField] private List<PlayerSO> availableSoldierSOList;

	[SerializeField] private Image draggedPlayerImage;

    private Transform draggedPlayer;
    private Transform overPlayer;

	private void Awake()
	{
		Instance = this;
	}

	private void Start()
	{
		draggedPlayer = null;
		overPlayer = null;
	}

	void GetInformation(PlayerSO playerSO)
	{
		Debug.Log(playerSO.playerName);
		Debug.Log(playerSO.playerDamage);
	}

    public void SetDraggedPlayer(Transform player)
	{
		draggedPlayer = player;
	}

	public void SetOverPlayer(Transform player)
	{
		overPlayer = player;
	}

	public void SetDraggedPlayerImage(Transform player)
	{
		if (overPlayer == null)
		{
			draggedPlayerImage.sprite = player.GetComponent<Player>().GetPlayerSO().sprite;
		}

		draggedPlayerImage.gameObject.SetActive(true);
		draggedPlayerImage.transform.position = Input.mousePosition;
	}

	public void HideImage()
	{
		draggedPlayerImage.gameObject.SetActive(false);
	}

	public void MergePlayers()
	{
		if (overPlayer == null)
			return;

		if(draggedPlayer.transform == overPlayer.transform)
		{
			return;
		}

		foreach (PlayerMergeSO playerMergeSO in playerMergeSOList)
		{
			if(draggedPlayer.GetComponent<Player>().GetPlayerSO() == playerMergeSO.input1 
				&& overPlayer.GetComponent<Player>().GetPlayerSO() == playerMergeSO.input2)
			{
				if (availableSoldierSOList.Contains(playerMergeSO.output))
				{
					Transform mergedPlayer = Instantiate(playerMergeSO.output.playerPrefab, overPlayer.transform.position, Quaternion.identity).transform;
					SpawnManager.Instance.AddPlayerToTheList(mergedPlayer);

					MergeSucceed();
					return;
				}
			}

			if (overPlayer.GetComponent<Player>().GetPlayerSO() == playerMergeSO.input1
				&& draggedPlayer.GetComponent<Player>().GetPlayerSO() == playerMergeSO.input2)
			{
				if (availableSoldierSOList.Contains(playerMergeSO.output))
				{
					Transform mergedPlayer = Instantiate(playerMergeSO.output.playerPrefab, overPlayer.transform.position, Quaternion.identity).transform;
					SpawnManager.Instance.AddPlayerToTheList(mergedPlayer);

					MergeSucceed();
					return;
				}
			}
		}
	}

	public void SetImageToMergedImage()
	{
		if (draggedPlayer == null)
			return;

		if (draggedPlayer.transform == overPlayer.transform)
		{
			return;
		}

		foreach (PlayerMergeSO playerMergeSO in playerMergeSOList)
		{
			if (draggedPlayer.GetComponent<Player>().GetPlayerSO() == playerMergeSO.input1
				&& overPlayer.GetComponent<Player>().GetPlayerSO() == playerMergeSO.input2)
			{
				draggedPlayerImage.sprite = playerMergeSO.output.sprite;
				return;
			}

			if (overPlayer.GetComponent<Player>().GetPlayerSO() == playerMergeSO.input1
				&& draggedPlayer.GetComponent<Player>().GetPlayerSO() == playerMergeSO.input2)
			{
				draggedPlayerImage.sprite = playerMergeSO.output.sprite;
				return;
			}
		}

	}

	private void MergeSucceed()
	{
		AudioManager.Instance.Play("Merge");

		SpawnManager.Instance.RemovePlayerFromList(draggedPlayer.transform);
		SpawnManager.Instance.RemovePlayerFromList(overPlayer.transform);

		ResetOverPlayer();
		ResetDraggedPlayer();
	}

	public void ResetOverPlayer()
	{
		overPlayer = null;
	}

	public void ResetDraggedPlayer()
	{
		draggedPlayer = null;
	}

	public void AddPlayerAvailableSOList(PlayerSO playerSO,int cost,Button button)
	{
		if (GameMaster.Instance.GetCurrentCoin() < cost)
			return;

		if (!availableSoldierSOList.Contains(playerSO))
		{
			GameMaster.Instance.ChangeCoin(-cost);
			availableSoldierSOList.Add(playerSO);

			OnMergeUpgradeSuccess?.Invoke(this, new OnMergeUpgradeSuccessEventArgs
			{
				upgradeMergeButton = button
			});
		}
	}

	public List<PlayerSO> GetAvailableSOList()
	{
		return availableSoldierSOList;
	}
}
