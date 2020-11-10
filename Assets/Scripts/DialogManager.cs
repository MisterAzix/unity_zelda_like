/* Author : Raphaël Marczak - 2018/2020, for MIAMI Teaching (IUT Tarbes) and MMI Teaching (IUT Bordeaux Montaigne)
 * 
 * This work is licensed under the CC0 License. 
 * 
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

// This struct represents one dialog page
// (text on the current page, and its color)
[System.Serializable]
public struct DialogPage
{
    public string text;
    public Color color;
    public GameObject character;
}

// This class is used to correctly display a full dialog
public class DialogManager : MonoBehaviour {

    public Text m_renderText;
    private List<DialogPage> m_dialogToDisplay;
    private GameObject m_overlayToDisplay;
    private Transform m_parentOverlay;

    void Awake () {

    }

    // Sets the dialog to be displayed
    public void SetDialog(List<DialogPage> dialogToAdd)
    {
        m_dialogToDisplay = new List<DialogPage>(dialogToAdd);

        if (m_dialogToDisplay.Count > 0)
        {
            if (m_renderText != null)
            {
               m_renderText.text = "";
            }

            this.gameObject.SetActive(true);
            int index = 0;
            int i = 0;
            foreach (var dialog in m_dialogToDisplay)
            {
                if (dialog.character)
                {
                    index = i;
                }
                i++;
            }
            m_parentOverlay = m_dialogToDisplay[index].character.transform.parent;
            //m_parentOverlay = m_dialogToDisplay[0].character?m_dialogToDisplay[0].character.transform.parent:null;
            if(m_parentOverlay) m_parentOverlay.gameObject.SetActive(true);
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (m_renderText == null)
        {
            this.gameObject.SetActive(false);
        }

        // Displays the current page
		if (m_dialogToDisplay.Count > 0)
        {
            m_renderText.text = m_dialogToDisplay[0].text;
            //UnityEngine.Debug.Log(m_parentOverlay);
            if(m_parentOverlay) {
                foreach (Transform child in m_parentOverlay)
                {
                    if (child.tag == "DialogCharacter")
                    {
                        child.gameObject.SetActive(false);
                    }
                }
                if (m_dialogToDisplay[0].character) m_dialogToDisplay[0].character.gameObject.SetActive(true);
            }
        } 
        else
        {
            if(m_parentOverlay)
            {
                m_parentOverlay.gameObject.SetActive(false);
                m_parentOverlay = null;
            }
            this.gameObject.SetActive(false);
        }

        // Removes the page when the player presses "space"
        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_dialogToDisplay.RemoveAt(0);
        }
	}

    public bool IsOnScreen()
    {
        return this.gameObject.activeSelf;
    }
}
