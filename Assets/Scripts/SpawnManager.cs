using UnityEngine;
using System.Collections.Generic;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> spawnableObjects;
    public int difficultyLevel = 0;

    private float timer;
    private float spawnInterval = 1.5f;
    public AudioClip spawnSound;

    public GameObject easyObject;
    public GameObject mediumObject;
    public GameObject hardObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        difficultyLevel = PlayerPrefs.GetInt("SelectedDifficulty", 0);
        Debug.Log(difficultyLevel);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            spawnObject();
            timer = 0f;
        }
    }

    void spawnObject()
    {
        int side = Random.Range(0, 4);
        Vector3 spawnPost = Vector3.zero;
        Quaternion spawnRotation = Quaternion.identity;

        if (side == 0)
        {
            spawnPost = new Vector3(-0.01f, 1.11f, 11.84f);
            spawnRotation = Quaternion.Euler(0f, 270f, 90f);
        }

        else if (side == 1)
        {
            spawnPost = new Vector3(11.84f, 1.11f, 0f);
            spawnRotation = Quaternion.Euler(0f, 0f, 90f);
        }

        else if (side == 2)
        {
            spawnPost = new Vector3(-0.01f, 1.11f, -11.84f);
            spawnRotation = Quaternion.Euler(0f, 90f, 90f);
        }

        else if (side == 3)
        {
            spawnPost = new Vector3(-11.84f, 1.11f, 0f);
            spawnRotation = Quaternion.Euler(0f, 180f, 90f);
        }

        GameObject selectedProjectile = SelectByDifficulty();
        Instantiate(selectedProjectile, spawnPost, spawnRotation);
        AudioSource.PlayClipAtPoint(spawnSound, Camera.main.transform.position);
    }

    GameObject SelectByDifficulty()
    {
        float roll = Random.Range(0f, 100f);
        if (difficultyLevel == 0)
        {
            if (roll < 80f) return easyObject;
            if (roll < 95f) return mediumObject;
            return hardObject;
        }
        else if (difficultyLevel == 1)
        {
            if (roll < 30f) return easyObject;
            if (roll < 80f) return mediumObject;
            return hardObject;
        }
        else if (difficultyLevel == 2)
        {
            if (roll < 10f) return easyObject;
            if (roll < 40f) return mediumObject;
            return hardObject;
        }

        return easyObject;
    }
}
