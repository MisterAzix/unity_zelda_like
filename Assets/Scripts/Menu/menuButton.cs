using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menuButton : MonoBehaviour
{
    public RawImage img;

    void OnMouseOver(){
        if(Input.GetKeyUp(KeyCode.Mouse0)){
            Debug.Log("Play!");
            StartCoroutine(Fondu());
        }
    }

    IEnumerator Fondu(){
       // StartCoroutine(PlayGame());
        for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                // set color with i as alpha
                img.color = new Color(1, 1, 1, i);
                yield return null;
            }
    }

    /*IEnumerator PlayGame(){
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("GroundFloor");
    }*/
}
