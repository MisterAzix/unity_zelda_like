using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class DoctorDestroy : MonoBehaviour
{
    public RawImage img;
    public GameObject DoctorNPC;

    private bool inPlace;
    private bool doctorStarted;
    private int spaceCount;
    private int fadeSpeed = 5;
    private float fadeAmout;
    private Color objectColor;

    void Start()
    {
        spaceCount = 0;
        inPlace = false;
        doctorStarted = false;
    }

    void OnTriggerEnter2D()
    {
        inPlace = true;
    }

    void Update()
    {
        if (doctorStarted == false)
        {
            if (inPlace == true && Input.GetKeyDown(KeyCode.Space))
            {
                spaceCount = spaceCount + 1;
            }
            if (spaceCount == 4)
            {
                doctorStarted = true;
                StartCoroutine(Fade());
                Destroy(DoctorNPC);
            }
        }

    }

    IEnumerator Fade()
    {
        img.color = new Color(0, 0, 0, 255);
        yield return new WaitForSeconds(0.1f);
        img.color = new Color(0, 0, 0, 0);
    }
}
