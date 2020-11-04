using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorScript : MonoBehaviour
{
    public Texture2D defaultTexture;
    public Texture2D clickTexture;
    public Texture2D grabTexture;

    public CursorMode curMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    // Start is called before the first frame update

    void Awake(){
        Cursor.SetCursor(defaultTexture, hotSpot, curMode);
    }

    void OnMouseOver(){
        switch(gameObject.tag){
            case "Click":
                if(Input.GetKey(KeyCode.Mouse0)){
                    Cursor.SetCursor(grabTexture, hotSpot, curMode);
                }else{
                    Cursor.SetCursor(clickTexture, hotSpot, curMode);
                }
            break;
            case "Grab":
                Cursor.SetCursor(grabTexture, hotSpot, curMode);
            break;
            default:
                Cursor.SetCursor(defaultTexture, hotSpot, curMode);
            break;
        }
    }

    void OnMouseExit(){
        Cursor.SetCursor(defaultTexture, hotSpot, curMode);
    }
}
