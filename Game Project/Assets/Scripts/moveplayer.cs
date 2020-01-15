using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO.Ports;

public class moveplayer : MonoBehaviour
{
    SerialPort sp = new SerialPort("COM3", 9600);

    

    public KeyCode moveL;
    public KeyCode moveR;
    public KeyCode moveUp;
    public KeyCode moveDown;

    public float horizVelo = 0;
    public int laneNum = 2;
    public string controlLocked = "n";

    // Start is called before the first frame update
    void Start()
    {
        sp.Open();
        sp.ReadTimeout = 1;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(horizVelo, GM.vertVel, 4);

        if ((Input.GetKeyDown(moveL)) && (laneNum>1) && (controlLocked == "n"))
        {
            horizVelo = -2;
            StartCoroutine(stopSlide());
            laneNum -= 1;
            controlLocked = "y";
        };

        if ((Input.GetKeyDown(moveR)) && (laneNum<3) && (controlLocked == "n"))
        {
            horizVelo = 2;
            StartCoroutine(stopSlide());
            laneNum += 1;
            controlLocked = "y";
        };

        if (sp.IsOpen)
        {
            if ((sp.ReadByte() == 1) && (laneNum > 1) && (controlLocked == "n"))
            {
                horizVelo = -2;
                StartCoroutine(stopSlide());
                laneNum -= 1;
                controlLocked = "y";

            };

            if ((sp.ReadByte() == 2) && (laneNum < 3) && (controlLocked == "n"))
            {
                horizVelo = 2;
                StartCoroutine(stopSlide());
                laneNum += 1;
                controlLocked = "y";
            };

        }


    }

    void OnCollisionEnter (Collision other)
    {
        if (other.gameObject.tag == "lethal")
        {
            Destroy(gameObject);
            GM.zVelAdj = 0;
            
            GM.lvlCompStatus = "Fail";
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "RampTrigger")
        {
            GM.vertVel = 2;
        }
        if (other.gameObject.name == "RampDeTrigger")
        {
            GM.vertVel = 0;
        }
        if (other.gameObject.name == "exit")
        {
            GM.lvlCompStatus = "Succes";
            SceneManager.LoadScene("LevelComp");
        }
    }

    IEnumerator stopSlide()
    {
        yield return new WaitForSeconds(.5f);
        horizVelo = 0;
        controlLocked = "n";
    }

    
}
