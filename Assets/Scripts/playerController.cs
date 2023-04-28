using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class playerController : MonoBehaviour
{
    public GameObject player;
    //variables
    private Rigidbody rb;
    [SerializeField]
    private float xspeed = 5.0f;
    [SerializeField]
    private float zspeed = 5.0f;
    [SerializeField]
    private float depth = 2.0f;
    [SerializeField]
    private float boyancyForce = 3.5f;
    [SerializeField]
    bool inWater = false;


    //movement numbers
    public float horizontalInput;
    public float verticalInput;
    public float elevationInput;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //player movement
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        elevationInput = Input.GetAxis("Depth");

        //rotate playermodel
    }

    //add boyancy to player when underwater
    private void OnTriggerEnter(Collider BoyancyBoundary)
    {
        inWater = true;


    }
    private void onTriggerEnter1(Collider collider)
    {
        if (collider.gameObject.tag == "cargo")
        {
            Debug.Log("You found some cargo!");
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        inWater = false;
    }

    private void OnTriggerEnter2D(Collider2D r)
    {
        Debug.Log("You found some lost cargo!");
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(horizontalInput * xspeed, elevationInput * depth, verticalInput * zspeed);
        if (inWater)
        {
            rb.AddForce(0, boyancyForce, 0, ForceMode.Acceleration);
        }
        else
        {
            rb.AddForce(0, -20, 0);
        }
    }
}
