using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Introduction : MonoBehaviour
{
    public AudioSource introSound;
    public AudioSource backgroundMusic;

    public RawImage backgroundImage;

    public bool skipIntro = false;

    // Start is called before the first frame update
    
    void Awake()
    {
        if(!skipIntro){
        introSound.Play();
            StartCoroutine(StopIntro());
        }else{
            backgroundImage.color = new Color(1, 1, 1, 0);
            backgroundMusic.Play();
        }
    }

    IEnumerator StopIntro()
    {
        yield return new WaitForSeconds(41); // 41 seconds
        backgroundMusic.Play();
        for (float i = 1; i >= 0; i -= Time.deltaTime){
            // set color with i as alpha
            backgroundImage.color = new Color(1, 1, 1, i);
            yield return null;
        }
    }
}
