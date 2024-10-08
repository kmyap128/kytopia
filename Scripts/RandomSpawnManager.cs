using System;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

using Random = UnityEngine.Random;

public class RandomSpawnManager : MonoBehaviour
{
    public List<SpriteRenderer> spritePrefabs = new List<SpriteRenderer>();

    public List<GameObject> spawnObjects = new List<GameObject>();

    public List<Color> spawnColors = new List<Color>();

    // Start is called before the first frame update
    void Start()
    {
        spawnColors.Add(Color.cyan);
        spawnColors.Add(Color.magenta);
        spawnColors.Add(Color.green);
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.sKey.wasReleasedThisFrame)
        {
            Spawn(0, 0, 0);
        }

        if (Keyboard.current.rKey.wasReleasedThisFrame)
        {
            Despawn();
        }
    }

    public void Spawn(float x, float y, float z)
    {
        Vector3 spawnPos = new Vector3(x, y, z);
        SpriteRenderer newSprite = Instantiate(PickRandomObject(), spawnPos, PickRandomRotation());
        newSprite.color = PickRandomColor();
        newSprite.size = PickRandomScale();
        spawnObjects.Add(newSprite.gameObject);
    }

    public void Despawn(){
        foreach(GameObject obj in spawnObjects){
            Destroy(obj);
        }
        spawnObjects.Clear();
    }

    SpriteRenderer PickRandomObject()
    {
        float randValue = Random.Range(0f, 1f);

        if(randValue < .2f)                 
        {
            return spritePrefabs[0];
        }
        else if(randValue < .4f)             
        {
            return spritePrefabs[1];
        }
        else if(randValue < .6f)             
        {
            return spritePrefabs[2];
        }
        else if(randValue < .8f)             
        {
            return spritePrefabs[3];
        }
        else
        {
            return spritePrefabs[4];
        }
    }
    Color PickRandomColor() {
        float randValue = Random.Range(0f, 1f);
        if(randValue < .3f)                 
        {
            return spawnColors[0];
        }
        else if(randValue < .6f)             
        {
            return spawnColors[1];
        }
        else
        {
            return spawnColors[2];
        }
    }

    Quaternion PickRandomRotation()
    {
        float randomAngle = Random.Range(0f, 360f);
        Quaternion randomRotation = Quaternion.Euler(0f, 0f, randomAngle);
        return randomRotation;
    }

    Vector2 PickRandomScale()
    {
        float randomScale = Random.Range(0.5f, 2.0f);
        return new Vector2(randomScale, randomScale);
    }
}