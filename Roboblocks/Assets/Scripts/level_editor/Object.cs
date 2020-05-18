using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Object
{
    public float posX;
    public float posY;
    public float posZ;

    public float scaleX;
    public float scaleY;
    public float scaleZ;

    public float rotationX;
    public float rotationY;
    public float rotationZ;

    public float r;
    public float g;
    public float b;

    public string name;

    public int Id;
    public int levelId;

    public Object(float posX, float posY, float posZ, float rotationX, float rotationY, float rotationZ, float r, float g, float b, string name, float scaleX, float scaleY, float scaleZ)
    {
        this.posX = posX;
        this.posY = posY;
        this.posZ = posZ;

        this.rotationX = rotationX;
        this.rotationY = rotationY;
        this.rotationZ = rotationZ;

        this.r = r;
        this.g = g;
        this.b = b;

        this.name = name;

        this.scaleX = scaleX;
        this.scaleY = scaleY;
        this.scaleZ = scaleZ;
    }

    public Object(float posX, float posY, float posZ, float rotationX, float rotationY, float rotationZ, float r, float g, float b, string name)
    {
        this.posX = posX;
        this.posY = posY;
        this.posZ = posZ;

        this.rotationX = rotationX;
        this.rotationY = rotationY;
        this.rotationZ = rotationZ;

        this.r = r;
        this.g = g;
        this.b = b;

        this.name = name;
    }



    public Object(float posX, float posY, float posZ, float rotationX, float rotationY, float rotationZ, string name)
    {
        this.posX = posX;
        this.posY = posY;
        this.posZ = posZ;

        this.rotationX = rotationX;
        this.rotationY = rotationY;
        this.rotationZ = rotationZ;

        this.name = name;

    }
}