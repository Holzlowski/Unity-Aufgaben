using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    float moveHorizontal, moveVertical;
    float x, z;
    public float moveSpeed = 5f;
    public float rotationSpeed = 100f;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        //hier wird der Animator des Childobjekt zugewiesen
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //x ist die berechnete Rotation des Objekts
        x = Input.GetAxis("Horizontal") * Time.deltaTime * rotationSpeed;
        //z ist die berechnete Translation des Objekts
        z = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        //das Objekt wird mit den x und z Werten bewegt und gedreht
        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);

        //hier werden die Zeitpunkte der Animationen durch Boolwerte gesetzt
        if (Input.GetKey(KeyCode.W))
        {
            anim.SetBool("isRunning", true);
        }

        else
        {
            anim.SetBool("isRunning", false);
        }

        if (Input.GetKey(KeyCode.S))
        {
            anim.SetBool("isGoingBack", true);
        }

        else
        { 
           anim.SetBool("isGoingBack", false);
        }

        //das war für Aufgabe 9 und 11
        /*
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
        transform.Translate(moveHorizontal * Time.deltaTime * moveSpeed, 0, moveVertical * Time.deltaTime * moveSpeed);
        */
    }
}
