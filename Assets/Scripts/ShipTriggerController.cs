using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipTriggerController : MonoBehaviour
{
    private int totalCubesCollected = 0;
    //[SerializeField] float DeathTimer = 5f;
    
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Cube"))
        {
            //Destroy(other.gameObject, DeathTimer);
            // totalCubesCollected + 1;                            //does the math, doesnt do anything with the sum.
            // totalCubesCollected = totalCubesCollected + 1;      //does something with the math, is long
            // totalCubesCollected ++;                             //adds 1 to the variable(old)
            Debug.Log("Cube triggered");
            other.GetComponent<CubeController>().GetCollected();
            totalCubesCollected += 1;                              //shorter, does the math
            Debug.Log("We have collected " + totalCubesCollected + " cubes.");
        }
    }
}
