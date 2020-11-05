using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class video_skip : MonoBehaviour
{

    public GameObject menuPart2;
    public GameObject gamePlay;
    public GameObject gameQuit;

    public AudioSource introMusic;
    public AudioSource introMusic2;

    public Texture2D defaultTexture;
    public CursorMode curMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    
        void Awake()
    {
        Cursor.SetCursor(defaultTexture, hotSpot, curMode);
        introMusic.Play();
    }

    IEnumerator Start(){
         yield return new WaitForSeconds(6);
         var videoPlayer = menuPart2.GetComponent<UnityEngine.Video.VideoPlayer>();
         menuPart2.SetActive(true);
         gamePlay.SetActive(true);
         gameQuit.SetActive(true);
         videoPlayer.Play();
         introMusic.Stop();
         introMusic2.Play();
    }
}
