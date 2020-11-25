using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;

    private float colorTimerValue = 2f;
    private float colorTimer = 0;
    private float red;
    private float green;
    private float blue;
    private float alpha;
    private Color color;

    private float scaleTimerValue = 1.5f;
    private float scaleTimer = 0;
    private float scaleX;
    private float scaleY;
    private float scaleZ;
    private Vector3 scale;

    private float rotationTimerValue = 2.5f;
    private float rotationTimer = 0;
    private float rotationX;
    private float rotationY;
    private float rotationZ;
    private float rotationSpeed = 1f;
    private int rotationIndex;
    private Vector3 rotation;
    
    void Start()
    {

    }
    
    void Update()
    {
        float time = Time.deltaTime;

        //################################################################
        // COLOR
            if(colorTimer > 0)
            {
                colorTimer-= time;
            }
            else
            {
                red   = Random.Range(0f, 1f);
                green = Random.Range(0f, 1f);
                blue  = Random.Range(0f, 1f);
                alpha = Random.Range(0f, 1f);
                color = (new Color(red, green, blue, alpha) - Renderer.material.GetColor("_Color")) / colorTimerValue * time;

                colorTimer = colorTimerValue;
            }
            
            Renderer.material.color+= color;
        //################################################################
        // SCALE
            if(scaleTimer > 0)
            {
                scaleTimer-= time;
            }
            else
            {
                scaleX  = Random.Range(1f, 2f);
                scaleY  = Random.Range(1f, 2f);
                scaleZ  = Random.Range(1f, 2f);
                scale   = (new Vector3(scaleX, scaleY, scaleZ) - transform.localScale) / scaleTimerValue * time;

                scaleTimer = scaleTimerValue;
            }
            
            transform.localScale+= scale;
        //################################################################
        // ROTATION
            if(rotationTimer > 0)
            {
                rotationTimer-= time;
            }
            else
            {
                rotationX  = Random.Range(0f, 180f);
                rotationY  = Random.Range(0f, 180f);
                rotationZ  = Random.Range(0f, 180f);
                rotation   = (new Vector3(rotationX, rotationY, rotationZ) - new Vector3(transform.rotation[0],transform.rotation[1],transform.rotation[2])) / rotationTimerValue * time;

                rotationTimer = rotationTimerValue;

                rotationSpeed = -rotationSpeed;
                rotationIndex = Random.Range(0, 3);
                rotation[rotationIndex]+= rotationSpeed;
            }
            
            rotationX  = rotation[0] + transform.rotation[0];
            rotationY  = rotation[1] + transform.rotation[1];
            rotationZ  = rotation[2] + transform.rotation[2];
            transform.Rotate(rotationX,rotationY,rotationZ);
        //################################################################
    }
}
