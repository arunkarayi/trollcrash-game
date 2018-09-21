using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackMove : MonoBehaviour {

    public float Speed = 2f;
    Vector2 offset;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        offset = new Vector2(0, Time.time * Speed);
        GetComponent<Renderer>().material.mainTextureOffset = offset;
    }
}
