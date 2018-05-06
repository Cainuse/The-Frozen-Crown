using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HPBar : MonoBehaviour {

	private float fillAmount;

	[SerializeField]
	private float lerpSpeed;

	[SerializeField]
	private Image content;

	[SerializeField]
	private Text valueText;

	public float MaxValue { get; set; }					//Set and refreshes Health

	public float Value
	{
		set
		{
			string[] tmp = valueText.text.Split (':');
			valueText.text = tmp [0] + ":" + value + "/" + MaxValue;
			fillAmount = Map (value, 0, MaxValue, 0, 1);   //Set current and Max Health

		}
	}


	// Use this for initialization
	void Start () 
	{

	
	}
	
	// Update is called once per frame
	void Update () 
	{
		HandleBar();
	}

	private void HandleBar()
	{
		if (fillAmount != content.fillAmount)			//controls the fillAmount
		{
			content.fillAmount = Mathf.Lerp(content.fillAmount, fillAmount, Time.deltaTime * lerpSpeed);
		}
	}

	private float Map(float value, float inMin, float inMax, float outMin, float outMax) // it holds out Health, value is current, inMin and inMax is the internal Min and Max health and Out is what being shown or displayed)
	{
		return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
		/*****				An algorithm to convert the current health based on out max 
		 Example:   Value = 80
		 			inMin = 0
		 			outMax = 1
		 			outMin = 0
					inMax = 100
				(80-0) * (1-0) / (100-0) + 0
		 (80-0) * (1-0) / (100 - 0) + 0
		 80*1 / 100-0 ====  0.8     done so we can have more flexability with minamal health*****/////
	}

}

