using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class video_skip : MonoBehaviour
{

    public GameObject menuPart2;
    public GameObject gamePlay;
    public GameObject gameQuit;

    IEnumerator Start(){
         yield return new WaitForSeconds(6);
         var videoPlayer = menuPart2.GetComponent<UnityEngine.Video.VideoPlayer>();
         menuPart2.SetActive(true);
         gamePlay.SetActive(true);
         gameQuit.SetActive(true);
         videoPlayer.Play();
    }
}
