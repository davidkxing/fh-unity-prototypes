using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    public float time = 2.0f;
    public float timer = 2.0f;

    // Update is called once per frame
    void Update()
    {
        Debug.Log(timer);
        timer += Time.deltaTime;
        if (timer >= time)
        {
            // On spacebar press, send dog
            if (Input.GetKeyDown(KeyCode.Space))
            {
                spawnDog();
                timer = 0;
            }
        }
    }

    void spawnDog()
    {
        Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
    }
}
