using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableCollision : MonoBehaviour
{
    int Score = 0;

    //wenn Objekt mit Collectables kollidiert, wird dieses zerstört
    //und der Score wird erhöht
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Collectable")
        {
            Destroy(other.gameObject);
            Score++;
            Debug.Log(Score);
        }
    }
}

