using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stairs : MonoBehaviour
{
    public float m_speed = 1f;

    private bool inPlace;
    private bool doctorStarted;
    private int spaceCount;
    private bool stopMove;

    Rigidbody2D m_rb2D;

    // Start is called before the first frame update
    void Start()
    {
        m_rb2D = gameObject.GetComponent<Rigidbody2D>();
        spaceCount = 0;
        inPlace = false;
        doctorStarted = false;
        stopMove = true;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        inPlace = true;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        inPlace = false;
    }

    void Update()
    {
        if (doctorStarted == false)
        {
            if (inPlace == true && Input.GetKeyDown(KeyCode.Space))
            {
                spaceCount = spaceCount + 1;
            }
            if (spaceCount == 5)
            {
                doctorStarted = false;
                stopMove = false;
            }
        }
        
    }

    void FixedUpdate()
    {
        if (!stopMove)
        {
            Vector2 newPos = new Vector2(transform.position.x,
                                     transform.position.y - 1 * m_speed);
            m_rb2D.MovePosition(newPos);
        }
    }
}
