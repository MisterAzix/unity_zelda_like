using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Outro : MonoBehaviour
{
    public AudioSource outroMusic;
    public AudioSource backgroundMusic;
    public RawImage img;
    public GameObject credits;

    private bool inPlace;
    private bool outroStarted;
    private int spaceCount;

    void Start()
    {
        spaceCount = 0;
        inPlace = false;
        outroStarted = false;
    }

    void OnTriggerEnter2D()
    {
        inPlace = true;
    }

    void Update(){
        if(outroStarted == false)
        {
            if(inPlace == true && Input.GetKeyDown(KeyCode.Space)){
                spaceCount = spaceCount + 1;
            }
            if(spaceCount == 3){
                outroMusic.Play();
            }
            if(spaceCount == 4){
                var creditsVideo = credits.GetComponent<UnityEngine.Video.VideoPlayer>();
                outroStarted = true;
                creditsVideo.Play();
                backgroundMusic.Stop();
                StartCoroutine(Fade());
                StartCoroutine(AutoQuit());
            }
        }
        
    }

    IEnumerator Fade()
    {
        for (float i = 0; i >= 0; i += Time.deltaTime){
            // set color with i as alpha
            img.color = new Color(0, 0, 0, i);
            yield return null;
        }
        for (float i = 0; i >= 0; i += Time.deltaTime){
            // set color with i as alpha
            img.color = new Color(i, i, i, 1);
            yield return null;
        }
    }

    IEnumerator AutoQuit()
    {
        yield return new WaitForSeconds(114);
        SceneManager.LoadScene("Menu");
    }
}
