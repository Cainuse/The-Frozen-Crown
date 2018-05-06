using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour
{

    IEnumerator ChangeLevel()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            float fadeTime = GameObject.Find("Main Camera").GetComponent<Fading>().BeginFade(1);
            yield return new WaitForSeconds(fadeTime);
            Application.LoadLevel(Application.loadedLevel + 1);
        }

    }

}
