using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInfo : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 0f;
    }

    public void StartLevel()
	{
        Time.timeScale = 1f;
        gameObject.SetActive(false);
	}

}
