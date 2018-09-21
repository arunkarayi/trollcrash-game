using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour {

    public GameObject[] cars;
    int carNo;
    int oldCarno = -1;
    int carSize = 5;
    public float delayTime = 0.5f;
    float timer;

    // Use this for initialization
    void Start () {
        timer = delayTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Vector3 carPos = new Vector3(Random.Range(-2.3f, 2.4f), transform.position.y, transform.position.z);
            carNo = AvoidRandomno(Random.Range(0, carSize+1));
            Instantiate(cars[carNo], carPos, transform.rotation);
            timer = delayTime;
        }
    }

    int AvoidRandomno(int number)
    {
        if (number == oldCarno)
        {
            if (number == carSize)
            {
                number = 0;
            }
            else
                number++;
        }
        oldCarno = number;
        return number;
    }
}
