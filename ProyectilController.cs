using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectilController : MonoBehaviour
{
    private const float TIME2LIVE = 4f;
    
    public GameObject player;
    [SerializeField] private float speed;
    private Rigidbody2D rb;

    private float initTime;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initTime = Time.time;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector2(speed, 0f);
        if (Time.time - initTime > TIME2LIVE)
        {
            Destroy(gameObject);
        }

    }
}
