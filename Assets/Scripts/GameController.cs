using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private GameObject PaddleLeft;
    private GameObject PaddleRight;
    private GameObject Court;
    private Text balls;
    private static int numBalls;
    public float speed = 1.5f;


    // Start is called before the first frame update
    void Start()
    {
        PaddleLeft = GameObject.Find("PaddleLeft");
        PaddleRight = GameObject.Find("PaddleRight");
        Court = GameObject.Find("Court");

        var leftRenderer = PaddleLeft.GetComponent<Renderer>();
        leftRenderer.material.SetColor("_Color", Color.green);

        var rightRenderer = PaddleRight.GetComponent<Renderer>();
        rightRenderer.material.SetColor("_Color", Color.cyan);

        var courtRenderer = Court.GetComponent<Renderer>();
        courtRenderer.material.SetColor("_Color", Color.black);

        balls = FindObjectOfType<Text>();
        numBalls = 0;
    }

    private void OnTriggerEnter(Collider other)
    {


        if (gameObject.name == "PaddleRight")
        {
            if (other.gameObject.name == "sphere1")
            {
                Destroy(other.gameObject);
                GameObject sphere2 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                sphere2.name = "sphere2";
                sphere2.transform.position = new Vector3(PaddleRight.transform.position.x, PaddleRight.transform.position.y, PaddleRight.transform.position.z);
                sphere2.AddComponent<Rigidbody>();
                var sphere2Rigid = sphere2.GetComponent<Rigidbody>();
                sphere2Rigid.AddRelativeForce(new Vector3(500, 1, 1));
            }

        }

        if (gameObject.name == "PaddleLeft")
        {
            if (other.gameObject.name == "sphere2") { 
                Destroy(other.gameObject);
            GameObject sphere1 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere1.name = "sphere1";
            sphere1.transform.position = new Vector3(PaddleLeft.transform.position.x, PaddleLeft.transform.position.y, PaddleLeft.transform.position.z);

            sphere1.AddComponent<Rigidbody>();
            var sphere1Rigid = sphere1.GetComponent<Rigidbody>();
            sphere1Rigid.AddRelativeForce(new Vector3(-500, 1, 1));
        }
    } 

    }

    private void spawnCylinder()
    {
        GameObject Cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        Cylinder.name = "Cylinder";
        Cylinder.transform.position = new Vector3(0, 0, 0);

        var cylinder = Cylinder.GetComponent<Renderer>();
        cylinder.material.SetColor("_Color", Color.red);
    }

    private void Update()

    {
        // mevement of paddles using the keys
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            PaddleRight.transform.position += Vector3.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            PaddleRight.transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            PaddleRight.transform.position += Vector3.back * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            PaddleRight.transform.position += Vector3.forward * speed * Time.deltaTime;
        }

        if (Input.GetKey("w"))
        {
            PaddleLeft.transform.position += Vector3.back * speed * Time.deltaTime;
        }
        if (Input.GetKey("s"))
        {
            PaddleLeft.transform.position += Vector3.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey("d"))
        {
            PaddleLeft.transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey("a"))
        {
            PaddleLeft.transform.position += Vector3.right * speed * Time.deltaTime;
        }

        if(numBalls >= 10)
        {
            SceneManager.LoadScene("MainMenu");
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            if (gameObject.name == "PaddleLeft")
            {
                GameObject sphere1 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                sphere1.name = "sphere1";
                sphere1.transform.position = new Vector3(PaddleLeft.transform.position.x, PaddleLeft.transform.position.y, PaddleLeft.transform.position.z);
           
                sphere1.AddComponent<Rigidbody>();
                var sphere1Rigid = sphere1.GetComponent<Rigidbody>();
                sphere1Rigid.AddRelativeForce(new Vector3(-500, 1, 1));
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (gameObject.name == "PaddleRight") { 
                GameObject sphere2 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere2.name = "sphere2";
            sphere2.transform.position = new Vector3(PaddleRight.transform.position.x, PaddleRight.transform.position.y, PaddleRight.transform.position.z);
                sphere2.AddComponent<Rigidbody>();
            var sphere2Rigid = sphere2.GetComponent<Rigidbody>();
            sphere2Rigid.AddRelativeForce(new Vector3(500, 1, 1));
        }
        }

        balls.text = "Missed Balls : "+ numBalls;
    }


    private void OnCollisionExit(Collision collision)
    {
        if (gameObject.name == "Court")
        {
            numBalls++;

        }
    }
}
