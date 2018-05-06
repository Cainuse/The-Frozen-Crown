using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class Stats
{
	[SerializeField]
	private HPBar bar;			//linking this script to HPBAR script

	[SerializeField]
	private float maxVal;

	[SerializeField]
	private float currentVal;

	public float CurrentVal   // Encapsulating our current Health Value
	{
		get
		{
			return currentVal;
		}

		set
		{
			this.currentVal = Mathf.Clamp(value,0,MaxVal);					// using a mathclamp to prevent going below 0
			bar.Value = currentVal;
		}
	}

	public float MaxVal		// Encapsulation our max health Value
	{
		get
		{
			return maxVal;
		}

		set
		{
			this.maxVal = value;
			bar.MaxValue = MaxVal;
		}
	}

	public void initialize()
	{
		this.MaxVal = maxVal;
		this.CurrentVal = currentVal;

	}



}