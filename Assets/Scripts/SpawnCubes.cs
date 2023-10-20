//Jarvis Lawson
//Interactive Scripting Fall 2023
//This code will spawn cubes at random locations around the map.

//can you change the color of each cube? YES
//can you change how many cubes are created from the inspector? YES
//can you change the timer interval between spawns? YES
//can you change, in the inspector, the size of the random location? YES - Bonus points for the gizmo?
//can you add physics to the cubes? Either in code, or in the prefab? YES
//can you reset the spawn loop code and run it again, from a key press? YES

//homework: use an array of colors to choose the random color of your cubes. DONE (Bonus: Every name has the same color.)
//homework: change collectCubes() to a couroutine that uses WaitUntilEndOfFrame(); DONE


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCubes : MonoBehaviour
{
    //creating an array of string variables named "names" and supplying three names.
    public string[] names;
    public Color[] colors;
    [SerializeField] GameObject prefabCube;
    [SerializeField] int cubeCounter;                                      //Adds amount to inspector
    [SerializeField] float spawnRange;                                     //Adds range to the inspector
    [SerializeField] float cubeInterval;                                   //Adds interval to inspector

    // Declares a dictionary named nameToColor, which maps "names" to "colors"
    private Dictionary<string, Color> nameToColor = new Dictionary<string, Color>();


    // Start is called before the first frame update
    void Start()
    {
        InitializeNameToColorDictionary();
        StartCoroutine(SpawnLoop());
        StartCoroutine(CollectCubes());
    }

    //populates the "nameToColor" dictionary, assigning colors to names.
    void InitializeNameToColorDictionary()
    {
        for (int i = 0; i < names.Length; i++)
        {
            nameToColor[names[i]] = colors[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))                                //press space to do the following thing
        {
            StartCoroutine(SpawnLoop());                                   //runs spawn loop again
            Debug.Log("I pressed Spacebar!");
        }
        if(Input.GetKeyDown(KeyCode.B))
        {
            StartCoroutine(CollectCubes());
            Debug.Log("I pressed B!");
        }
    }

    //spawn a cube
    GameObject SpawnCube()
    {
        GameObject cube = Instantiate(prefabCube);
        
        //Names and Colors
        string randomName = names[Random.Range(0,names.Length)];            //Assigns a name to randomName
        Color randomColor = nameToColor[randomName];                        //Assigns color to randomColor based on the name using the nameToColor dictionary
        cube.name = randomName;                                             //Changes cube name to randomName
        cube.GetComponent<Renderer>().material.color = randomColor;         //Changes cube color to randomColor

        cube.AddComponent<Rigidbody>();           //adds physics to the cubes

        //Had to move this down because I think it was spawning then trying to change the color so it wasn't working
        cube.transform.position = new Vector3(Random.Range(-spawnRange, spawnRange) , 2, Random.Range(-spawnRange, spawnRange));

        return cube;
    }

    //this function and it;s loop all happen on one frame.
    IEnumerator CollectCubes()
    {
        //find all cubes in scene and add them to an array
        GameObject[] cubes = GameObject.FindGameObjectsWithTag("Cube");
        //move all of them to the same location(0,2,0).
        int i = 0;
        while(i < cubes.Length)
        {
            cubes[i].transform.position = new Vector3(0,2,0);
            i += 1;
            yield return new WaitForEndOfFrame();
        }
    }

    //the loop function
    IEnumerator SpawnLoop()
    {
        int counter = 0;
        while (counter < cubeCounter)                                       //Changes cube counter from inspector
        {
            //counter = counter + 1;
            counter += 1;       //adds 1 to counter
            SpawnCube();
            yield return new WaitForSeconds(cubeInterval);                   //Changes cube interval from inspector
        }
    }

    //Draw Gizmo
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;      //Gizmo color blue
        Vector3 gizmoPosition = new Vector3(transform.position.x, 2, transform.position.z); //calculate spawnRange position
        Gizmos.DrawWireCube(gizmoPosition, new Vector3(spawnRange * 2, 0.01f, spawnRange * 2)); //draw the wire frame - had to double the size for some reason
    }
}
