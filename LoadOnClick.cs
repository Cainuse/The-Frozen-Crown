using UnityEngine;
using System.Collections;

public class LoadOnClick : MonoBehaviour {

	public GameObject loadingImage;

	public void LoadScene(int level)
	{
		loadingImage.SetActive(true);
		Application.LoadLevel(level);
	}

	public void Quit()                      //This function will be enabled on the Quit button
	{
		Application.Quit();
	}

}
