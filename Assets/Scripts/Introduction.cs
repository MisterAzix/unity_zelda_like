using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Introduction : MonoBehaviour
{
    public AudioSource introSound;
    public AudioSource backgroundMusic;

    public RawImage backgroundImage;

    // Start is called before the first frame update
    void Awake()
    {
        introSound.Play();
        StartCoroutine(StopIntro());
    }

    IEnumerator StopIntro(){
        yield return new WaitForSeconds(41); // 41 seconds
        backgroundMusic.Play();
        for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                backgroundImage.color = new Color(1, 1, 1, i);
                yield return null;
            }
    }
}
