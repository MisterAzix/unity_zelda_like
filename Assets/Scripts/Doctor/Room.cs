using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Room : MonoBehaviour
{
    public float m_speed = 1f;
    public GameObject m_KeyItem;

    private bool inPlace;
    private bool doctorStarted;
    private int spaceCount;
    private bool stopMove;
    private bool teleport;

    Rigidbody2D m_rb2D;

    // Start is called before the first frame update
    void Start()
    {
        m_rb2D = gameObject.GetComponent<Rigidbody2D>();

        spaceCount = 0;
        inPlace = false;
        doctorStarted = false;
        stopMove = true;
        teleport = true;
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
            if (spaceCount == 7)
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
            if(teleport)
            {
                m_KeyItem.transform.position = transform.position;
            }
            Vector2 newPos = new Vector2(transform.position.x, transform.position.y - 1 * m_speed);
            m_rb2D.MovePosition(newPos);
        }
    }
}
