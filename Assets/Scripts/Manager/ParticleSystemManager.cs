using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemManager : MonoBehaviour
{
	public static ParticleSystemManager Instance { get; private set; }

	private void Awake()
	{
		Instance = this;
	}

	public void ActiveParticle(Transform position,GameObject particleEffect)
	{
		GameObject particleEffectGO = Instantiate(particleEffect,position.position,Quaternion.identity);

		Destroy(particleEffectGO, 2f);
	}

}
