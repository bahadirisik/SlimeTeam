using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCastle : MonoBehaviour, IDamageable
{
    private int healt;
    [SerializeField] private int startingHealt = 100;
	void Start()
    {
        healt = startingHealt;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(healt <= 0)
		{
            LevelFailed();
		}

    }

    public void DecreaseHealth(int damage)
    {
        healt -= damage;
    }

    void LevelFailed()
	{

	}
}
