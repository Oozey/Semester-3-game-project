using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO.Ports;

public class GM : MonoBehaviour
{

    public static float vertVel = 0;
    public static float timeTotal = 0;

    public static float zVelAdj = 1;

    public static string lvlCompStatus = "";
    public float waittoload = 0;

    public float zScenePos = 110;

    public Transform BuildingBlock;
    public Transform obstObject;

    public int randNumb;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(BuildingBlock, new Vector3(0, 4.138f, 94), BuildingBlock.rotation);
        Instantiate(BuildingBlock, new Vector3(0, 4.138f, 98), BuildingBlock.rotation);
        Instantiate(BuildingBlock, new Vector3(0, 4.138f, 102), BuildingBlock.rotation);
        Instantiate(BuildingBlock, new Vector3(0, 4.138f, 106), BuildingBlock.rotation);

       
    }

    // Update is called once per frame
    void Update()
    {
        if (zScenePos < 130)
        {
            Instantiate(BuildingBlock, new Vector3(0, 4.138f, zScenePos), BuildingBlock.rotation);
            zScenePos += 4;

            
        }


        if (randNumb < 2)
        {
            Instantiate(obstObject, new Vector3(-1, 5.138f, zScenePos), obstObject.rotation);
        }
        if (randNumb == 4)
        {
            Instantiate(obstObject, new Vector3(0, 5.138f, zScenePos), obstObject.rotation);
        }
        if (randNumb > 8)
        {
            Instantiate(obstObject, new Vector3(1, 5.138f, zScenePos), obstObject.rotation);
        }

        Instantiate(BuildingBlock, new Vector3(0, 4.138f, zScenePos), BuildingBlock.rotation);
        zScenePos += 4;

        randNumb = Random.Range(0, 10);

        timeTotal += Time.deltaTime;

        if (lvlCompStatus == "Fail")
        {
            waittoload += Time.deltaTime;
        }
        if (waittoload > 2)
        {
            SceneManager.LoadScene("LevelComp");
        }
    }
}
