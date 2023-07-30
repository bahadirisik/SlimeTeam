using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeUI : MonoBehaviour
{
    [SerializeField] private Button soldierLevel2UpgradeButton;
    [SerializeField] private Button soldierLevel3UpgradeButton;
    [SerializeField] private Button tankSoldierUpgradeButton;
    [SerializeField] private Button mageUpgradeButton;
    [SerializeField] private Button assassinUpgradeButton;
    [SerializeField] private Button archerUpgradeButton;
    [SerializeField] private Button maxSoldierAmountUpgradeButton;
    [SerializeField] private Button backButton;

    [SerializeField] private UpgradeSO soldierLevel2UpgradeSO;
    [SerializeField] private UpgradeSO soldierLevel3UpgradeSO;
    [SerializeField] private UpgradeSO tankUpgradeSO;
    [SerializeField] private UpgradeSO mageUpgradeSO;
    [SerializeField] private UpgradeSO assassinUpgradeSO;
    [SerializeField] private UpgradeSO archerUpgradeSO;

    [SerializeField] private Transform upgradePanelUI;

    [SerializeField] private Sprite sprite;

    void Start()
    {
		Merge.Instance.OnMergeUpgradeSuccess += Merge_OnMergeUpgradeSuccess;

        Hide();

        EnableAvaliableUpgrades();

        soldierLevel2UpgradeButton.onClick.AddListener(() =>
        {
            Merge.Instance.AddPlayerAvailableSOList(soldierLevel2UpgradeSO.playerSO, soldierLevel2UpgradeSO.cost,soldierLevel2UpgradeButton);
        });

        soldierLevel3UpgradeButton.onClick.AddListener(() =>
        {
            Merge.Instance.AddPlayerAvailableSOList(soldierLevel3UpgradeSO.playerSO, soldierLevel3UpgradeSO.cost,soldierLevel3UpgradeButton);
        });

        tankSoldierUpgradeButton.onClick.AddListener(() =>
        {
            Merge.Instance.AddPlayerAvailableSOList(tankUpgradeSO.playerSO, tankUpgradeSO.cost,tankSoldierUpgradeButton);
        });

        mageUpgradeButton.onClick.AddListener(() =>
        {
            Merge.Instance.AddPlayerAvailableSOList(mageUpgradeSO.playerSO, mageUpgradeSO.cost,mageUpgradeButton);
        });

        archerUpgradeButton.onClick.AddListener(() =>
        {
            Merge.Instance.AddPlayerAvailableSOList(archerUpgradeSO.playerSO, archerUpgradeSO.cost,archerUpgradeButton);

        });

        assassinUpgradeButton.onClick.AddListener(() =>
        {
            Merge.Instance.AddPlayerAvailableSOList(assassinUpgradeSO.playerSO, assassinUpgradeSO.cost, assassinUpgradeButton);

        });

        maxSoldierAmountUpgradeButton.onClick.AddListener(() =>
        {
            SpawnManager.Instance.IncreaseMaxSpawnAmount(2,35);
        });

        backButton.onClick.AddListener(() =>
        {
            Hide();
        });
    }

	private void Merge_OnMergeUpgradeSuccess(object sender, Merge.OnMergeUpgradeSuccessEventArgs e)
	{
        e.upgradeMergeButton.image.sprite = sprite;
        e.upgradeMergeButton.interactable = false;
        e.upgradeMergeButton.transform.GetChild(0).gameObject.SetActive(false);
	}

	public void Show()
	{
        gameObject.SetActive(true);
	}

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    void EnableAvaliableUpgrades()
	{
		foreach (int item in MainUpgrades.avaliableMergeUpgradeList)
		{
            upgradePanelUI.GetChild(item).gameObject.SetActive(true);
		}
	}
}
