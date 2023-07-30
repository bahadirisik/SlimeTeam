using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButtonUI : MonoBehaviour
{

    [SerializeField] private UpgradeUI upgradePanel;
	[SerializeField] private Button upgradePanelButton;

	private void Start()
	{
		upgradePanelButton.onClick.AddListener(() =>
		{
			upgradePanel.Show();
		});
	}

}
