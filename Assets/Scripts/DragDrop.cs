using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{

	private void OnMouseUp()
	{
		Merge.Instance.HideImage();
		Merge.Instance.MergePlayers();
	}

	private void OnMouseEnter()
	{
		Merge.Instance.SetOverPlayer(transform);

		Merge.Instance.SetImageToMergedImage();
	}

	private void OnMouseExit()
	{
		Merge.Instance.ResetOverPlayer();
	}

	private void OnMouseDrag()
	{
		Merge.Instance.SetDraggedPlayerImage(transform);
	}

	private void OnMouseDown()
	{
		Merge.Instance.SetDraggedPlayer(transform);
	}

}
