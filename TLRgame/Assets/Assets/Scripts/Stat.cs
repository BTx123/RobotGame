using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class Stat {
	[SerializeField]
	public BarScript bar;

	public float maxVal;

	public float currentVal;

	public float CurrentVal
    {
		get
		{
			return currentVal;
		}

		set
		{
			this.currentVal = value;
			bar.Value = currentVal;
		}
	}

	public float MaxVal
    {
		get
		{
			return maxVal;
		}

		set
		{
			this.maxVal = value;
			bar.MaxValue = maxVal;
		}
	}

	public void Initialize()
	{
		this.MaxVal = maxVal;
		this.CurrentVal = currentVal;
	}
}
