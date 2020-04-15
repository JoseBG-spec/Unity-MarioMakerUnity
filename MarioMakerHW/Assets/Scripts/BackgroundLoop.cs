using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BackgroundLoop : MonoBehaviour
{
    public GameObject[] levels;
    private GameObject[] newLevels;
    private Camera mainCamera;
    private Vector2 screenBounds;
    public Transform parent;
    private int childsNeededX;
    void Start()
    {
        mainCamera = GetComponent<Camera>();
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        newLevels = new GameObject[40];
        foreach (GameObject obj in levels)
        {
            loadChildObjects(obj,"x",0);
        }

        foreach(GameObject obj1 in newLevels)
        {
            if (obj1 != null)
            {
                loadChildObjects(obj1, "y", 0);
            }
            
        }
    }
    private void loadChildObjects(GameObject obj,string n,int index)
    {
        //Debug.Log(obj.name);
        float objectWidth = obj.GetComponent<SpriteRenderer>().bounds.size.x;
        float objectHeight = obj.GetComponent<SpriteRenderer>().bounds.size.y;
        int childsNeededY = (int)Mathf.Ceil(screenBounds.y * 2 / objectHeight);
        childsNeededX = (int)Mathf.Ceil(screenBounds.x * 2 / objectWidth);
        
        GameObject clone = Instantiate(obj) as GameObject;
        if (n == "x")
        {
            //Debug.Log(childsNeededX);
            for (int j = 0; j <= childsNeededX; j++)
            {
                GameObject c = Instantiate(clone) as GameObject;
                c.transform.SetParent(parent);
                c.transform.position = new Vector3(objectWidth * j + obj.transform.position.x, obj.transform.position.y, obj.transform.position.z);
                c.name = obj.name +"+"+ j;
                newLevels[index+j] = c;
            }
        }
        if (n == "y")
        {
            //Debug.Log(newLevels);
            for (int i = 0; i <= childsNeededY; i++)
            {
                GameObject c = Instantiate(clone) as GameObject;
                c.transform.SetParent(parent);
                c.transform.position = new Vector3(obj.transform.position.x, objectHeight * i + obj.transform.position.y, obj.transform.position.z);
                c.name = obj.name +"y"+ i;
            }
        }
        
        

        Destroy(clone);
        //Destroy(obj.GetComponent<SpriteRenderer>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
