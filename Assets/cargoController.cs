using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cargoController : MonoBehaviour
{
    
    //variables

    private Rigidbody cargoRb;
    [SerializeField]
    private float xspeed = 0.0f;
    [SerializeField]
    private float zspeed = 0.0f;
    [SerializeField]
    private float depth = 0.0f;
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
        cargoRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    //add boyancy to player when underwater
    private void OnTriggerEnter(Collider BoyancyBoundary)
    {
        inWater = true;
    }


    private void FixedUpdate()
    {
        cargoRb.velocity = new Vector3(horizontalInput * xspeed, elevationInput * depth, verticalInput * zspeed);
        if (inWater)
        {
            cargoRb.AddForce(0, boyancyForce, 0, ForceMode.Acceleration);
        }
        else
        {
            cargoRb.AddForce(0, -20, 0);
        }
    }
}
