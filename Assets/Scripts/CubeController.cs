using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class CubeController : MonoBehaviour
{
    int cubeSpeed;                                   //create an int named cubeSpeed with random range between 1 and 10 (inclusive)
    public int riseSpeed = 0;

    private CubeAudio cubeAudio;

    void Start()
    {
        cubeSpeed = Random.Range(1,10);
        cubeAudio = this.GetComponent<CubeAudio>();
    }

    void Update()
    {
        this.transform.Translate(0, riseSpeed * Time.deltaTime, 0);
    }

    public void GetCollected()
    {
        Debug.Log("Cube Speed: " + cubeSpeed);
        if(cubeSpeed > 6)                                                   //if speed is greater than 6
        {
            this.GetComponent<Renderer>().material.color = Color.green;     //turn green (Color.green)
            this.GetComponent<Rigidbody>().isKinematic = true;
            riseSpeed += 5; 
            this.transform.Translate(0, riseSpeed * Time.deltaTime, 0);                                                //move up by changing riseSpeed to 5
            Destroy(this.gameObject, 5);                                    //destory after 5 seconds
            cubeAudio.PlayCollectionAudio(true);
        }
            
        else                                                                //else if speed is less than 6
        {
            this.GetComponent<Renderer>().material.color = Color.red;       //turn cube red
            Destroy(this.gameObject, 1);                                    //destroy self after 1 second
            cubeAudio.PlayCollectionAudio(false);
        }
    }
}
