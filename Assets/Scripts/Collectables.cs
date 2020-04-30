using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    public Transform myPrefab;
    List<Transform> collectables;
    List<Vector3> posi;
    Transform[] collectables2;
    Vector3[] positions;
    Vector3 randomPosition, distance;
    float distanceLength;
    float prefabRadius;
    int numberOfCollectables;
    bool collided;

    public  float collectableTurnSpeed;
   
    // Start is called before the first frame update
    void Start()
    {

        collectables = new List<Transform>();
        posi = new List<Vector3>();
        numberOfCollectables = Random.Range(12, 18);
        positions = new Vector3[numberOfCollectables];
        collectables2 = new Transform[numberOfCollectables];
        
        // die Prefabs werden instanziiert und auf zufällige Positionen gesetzt
        for (int i = 0; i < numberOfCollectables; i++)
        {
            collectables2[i] = Instantiate(myPrefab, new Vector3(Random.Range(-4.8f, 4.8f), 0.5f, Random.Range(-4.8f, 4.8f)), Quaternion.identity);
        }


      //Das hier ist mein gescheiterter Versuch, die Collectables auf Kollisionen untereinander
      //zu checken. Ich wollte dich auch nicht weiter nerven, aber wäre nett wenn du mir 
      //sagen könntest, was ich falsch gemacht habe und was ich besser machen könnte

      /*
      prefabRadius = myPrefab.GetComponent<SphereCollider>().radius;
      Debug.Log("Radius: " + prefabRadius);

      randomPosition = new Vector3(Random.Range(-4.8f, 4.8f), 0.5f, Random.Range(-4.8f, 4.8f));
      posi.Add(randomPosition);

      //hier sollen die Positionen dann auf Kollisionen geprüft werden

      for (int i = 1; i < numberOfCollectables; i++)
      {
          randomPosition = new Vector3(Random.Range(-4.8f, 4.8f), 0.5f, Random.Range(-4.8f, 4.8f));
          collided = false;
          while(posi[i] == null)
          {
              foreach (Vector3 position in posi)
              {
                  if(position != null)
                  {
                      distance = position - randomPosition;
                      distanceLength = distance.magnitude;

                      if (distanceLength < prefabRadius)
                      {
                          randomPosition = new Vector3(Random.Range(-4.8f, 4.8f), 0.5f, Random.Range(-4.8f, 4.8f));
                          break;
                      }
                  }
              }
              if (collided == false)
              {
                  posi.Add(randomPosition);
              }
          }

      }

      foreach(Vector3 position in posi)
      {
          Debug.Log(position);
      }

      //Hier speise ich dann die erzeugten Positionen ein
      for (int i = 0; i < numberOfCollectables; i++)
      {
          collectables[i] = Instantiate(myPrefab, posi[i], Quaternion.identity);
      }
     */

    }
     
    private void Update()
    {
        //jedes Collectable dreht sich mit einer gewissen Geschwindigkeit
        foreach (Transform collectable in collectables2)
        {
            if (collectable)
            {
                collectable.transform.Rotate(0, Time.deltaTime * collectableTurnSpeed, 0);
            }
        }
    }
}
