using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuButton : MonoBehaviour
{
    void OnMouseOver(){
        if(Input.GetKeyUp(KeyCode.Mouse0)){
            Debug.Log("Play!");
            SceneManager.LoadScene("MainScene");
        }
    }
}
