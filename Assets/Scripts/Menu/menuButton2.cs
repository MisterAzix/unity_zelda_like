using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuButton2 : MonoBehaviour
{
    void OnMouseOver(){
        if(Input.GetKeyDown(KeyCode.Mouse0)){
            Debug.Log("Quit!");
            Application.Quit();
        }
    }
}
