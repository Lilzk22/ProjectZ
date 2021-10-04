using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnParticleEnd : MonoBehaviour
{
	public void Awake()
	{
		this.ps = base.GetComponentInChildren<ParticleSystem>();
	}
	public void Update()
	{
		if (this.ps && !this.ps.IsAlive())
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}
	private ParticleSystem ps;
}