using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Outro : MonoBehaviour
{
    public AudioSource outroMusic;
    public AudioSource backgroundMusic;
    public RawImage img;
    public GameObject credits;

    private bool inPlace;
    private int spaceCount;

    public List<DialogPage> m_dialogWithPlayer;
    public GameObject m_overlayToDisplay = null;

    public List<DialogPage> GetDialog()
    {
        return m_dialogWithPlayer;
    }

    public GameObject GetOverlay()
    {
        return m_overlayToDisplay;
    }

    void Start(){
        spaceCount = 0;
    }

    void OnTriggerEnter2D(){
        inPlace = true;
    }

    void Update(){
        if(inPlace == true && Input.GetKeyDown(KeyCode.Space)){
            spaceCount = spaceCount + 1;
        }
        if(spaceCount == 3){
            outroMusic.Play();
        }
        if(spaceCount == 4){
            var creditsVideo = credits.GetComponent<UnityEngine.Video.VideoPlayer>();
            creditsVideo.Play();
            backgroundMusic.Stop();
            StartCoroutine(Fade());
        }
    }

    IEnumerator Fade(){
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
        Destroy(GetComponent<Outro>());
    }
}
