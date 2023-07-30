using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MainUpgradeUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI mainMoneyText;
    [SerializeField] private TextMeshProUGUI maxSoldierText;
    [SerializeField] private Button soldier2MainUpgradeButton;
    [SerializeField] private Button soldier3MainUpgradeButton;
    [SerializeField] private Button archerMainUpgradeButton;
    [SerializeField] private Button mageMainUpgradeButton;
    [SerializeField] private Button tankMainUpgradeButton;
    [SerializeField] private Button assassinMainUpgradeButton;
    [SerializeField] private Button maxSoldierMainUpgradeButton;

    void Start()
    {

        SetMainMoneyText();

        soldier2MainUpgradeButton.onClick.AddListener(() =>
        {
            PurchaseSoldierUpgrade(50,0);
        });

        soldier3MainUpgradeButton.onClick.AddListener(() =>
        {
            PurchaseSoldierUpgrade(100, 1);
        });

        archerMainUpgradeButton.onClick.AddListener(() =>
        {
            PurchaseSoldierUpgrade(75, 3);
        });

        mageMainUpgradeButton.onClick.AddListener(() =>
        {
            PurchaseSoldierUpgrade(120, 4);
        });

        tankMainUpgradeButton.onClick.AddListener(() =>
        {
            PurchaseSoldierUpgrade(150, 2);
        });

        assassinMainUpgradeButton.onClick.AddListener(() =>
        {
            PurchaseSoldierUpgrade(100, 5);
        });

        maxSoldierMainUpgradeButton.onClick.AddListener(() =>
        {
            SetMaxSoldierAmount(2,35);
        });
    }

    void SetMainMoneyText()
	{
        mainMoneyText.text = MainUpgrades.mainMoney.ToString();
        maxSoldierText.text = MainUpgrades.maxSoldierAmountUpgrade.ToString();
    }

    void PurchaseSoldierUpgrade(int cost, int upgradeIndex)
	{
        if(MainUpgrades.mainMoney >= cost && !MainUpgrades.avaliableMergeUpgradeList.Contains(upgradeIndex))
		{
            AudioManager.Instance.Play("Upgrade");
            MainUpgrades.avaliableMergeUpgradeList.Add(upgradeIndex);
            MainUpgrades.mainMoney -= cost;
            SetMainMoneyText();
		}
	}

    void SetMaxSoldierAmount(int amount, int cost)
	{
        if(MainUpgrades.mainMoney >= cost)
		{
            AudioManager.Instance.Play("Upgrade");
            MainUpgrades.maxSoldierAmountUpgrade += amount;
            MainUpgrades.mainMoney -= cost;
            SetMainMoneyText();
            maxSoldierText.text = MainUpgrades.maxSoldierAmountUpgrade.ToString();
        }
	}
}
