using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carController : MonoBehaviour {

    public float carSpeed;
    Vector3 position;
    bool currentPlatformAndroid = false;

    public UIManager ui;
    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        #if UNITY_ANDROID
                currentPlatformAndroid = true;
        #else
                currentPlatformAndroid = false;
        #endif
    }

    // Use this for initialization
    void Start () {
        position = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (currentPlatformAndroid == true)
        {
           // AccelerometerMove();
        }
        else
        {
            position.x += Input.GetAxis("Horizontal") * carSpeed * Time.deltaTime;
            position.x = Mathf.Clamp(position.x, -2.6f, 2.7f);
            transform.position = position;
        }

        position = transform.position;
        position.x = Mathf.Clamp(position.x, -2.6f, 2.7f);
        transform.position = position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy Car")
        {
            Destroy(gameObject);
            ui.gameOverActivated();
        }
    }

    void AccelerometerMove()
    {
        float x = Input.acceleration.x;
        if(x < -0.1f)
        {
            MoveLeft();
        }else if(x > 0.1f)
        {
            MoveRight();
        }
        else
        {
            SetVelocityZero();
        }
    }

    public void MoveLeft()
    {
        rb.velocity = new Vector2(-carSpeed, 0);
        /*rb.velocity = new Vector2(Mathf.Lerp(rb.velocity.x, -carSpeed, Time.deltaTime), 0);
        transform.eulerAngles = new Vector2(0, 180);*/
    }

    public void MoveRight()
    {
        rb.velocity = new Vector2(carSpeed, 0);
        /*rb.velocity = new Vector2(Mathf.Lerp(rb.velocity.x, carSpeed, Time.deltaTime), 0);
        transform.eulerAngles = new Vector2(0, 0);*/
    }

    public void SetVelocityZero()
    {
        rb.velocity = Vector2.zero;
    }
}
