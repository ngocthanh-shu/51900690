using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    GameObject[] listPickups;
    private LineRenderer lineRenderer;
    public Text scoreText;
    public Text winText;
    public Text playerPosition;
    public Text playerVelocity;
    public Text closet;
    private int numPickUps = 4;
    private int count;
    Vector3 firstPosition = new Vector3(0f,0.5f,0f);
    // Start is called before the first frame update
    void Start()
    {
        listPickups = GameObject.FindGameObjectsWithTag("PickUp");
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        count = 0;
        winText.text = "";
        playerPosition.text = "";
        playerVelocity.text = "";
        closet.text = "1";
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        playerPosition.text = GameObject.FindGameObjectWithTag("Player").transform.position.ToString();
        Vector3 lastPoisition = GameObject.FindGameObjectWithTag("Player").transform.position;
        lineRenderer.SetPosition(0,lastPoisition);
        float velocity = Vector3.Distance(lastPoisition,firstPosition) / Time.deltaTime;
        firstPosition = lastPoisition;
        playerVelocity.text = velocity.ToString() + " m/h";
        float tmp = 0f;
        for (int i = 0; i < listPickups.Length; i++)
        {
            if (listPickups[i].Equals(ClosestPickUp(lastPoisition, listPickups))){
                listPickups[i].GetComponent<Renderer>().material.color = Color.blue;
                lineRenderer.SetPosition(1, listPickups[i].transform.position);
                tmp = Vector3.Distance(lastPoisition,listPickups[i].transform.position);
            }
            else
            {
                listPickups[i].GetComponent<Renderer>().material.color = Color.white;
            }
        }
        lineRenderer.SetWidth(0.1f, 0.1f);
        closet.text = tmp.ToString() + " m";

    }


    public void SetCountText()
    {
        scoreText.text = "Score: " + count.ToString();
        if (count >= numPickUps)
        {
            winText.text = "You Win";
        }
    }
    
    public void setCount()
    {
        count += 1;
    }

    public GameObject ClosestPickUp(Vector3 lastPosition,GameObject[] gameObjects)
    {
        int min = checkTrue(gameObjects, 0);
        if(min == gameObjects.Length)
        {
            return null;
        }
        float minValue = Vector3.Distance(lastPosition,gameObjects[min].transform.position);
        for (int i = 1; i < gameObjects.Length; i++)
        {
            float tmp = Vector3.Distance(gameObjects[i].transform.position,lastPosition);
            if (tmp < minValue && gameObjects[i].active == true)
            {
                min = i;
            }
        }
        return gameObjects[min];
    }

    public int checkTrue(GameObject[] gameObjects, int i)
    {
        if (i == gameObjects.Length)
            return i;
        else
        {
            if (gameObjects[i].active == true)
            {
                return i;
            }
            else
                return checkTrue(gameObjects, i + 1);
        }
    }
}
