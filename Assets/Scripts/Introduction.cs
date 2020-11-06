using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Introduction : MonoBehaviour
{
    public AudioSource introSound;
    public Camera mainCam;

    // Start is called before the first frame update
    void Awake()
    {
        mainCam.enabled = false;
        introSound.Play();
    }

    IEnumerator StopIntro(){
        yield return new WaitForSeconds(41);
        mainCam.enabled = true;
    }
}
