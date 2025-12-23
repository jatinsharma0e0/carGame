using UnityEngine;

public class carcontroler : MonoBehaviour
{
   [SerializeField] private WheelCollider frontrightwheelcolider;
    [SerializeField] private WheelCollider backrightwheelcolider;
    [SerializeField] private WheelCollider frontleftwheelcolider;
    [SerializeField] private WheelCollider backleftwheelcolider;

    [SerializeField] private Transform frontrightwheeltransform;
    [SerializeField] private Transform backrightwheeltransform;
    [SerializeField] private Transform frontleftwheeltransform;
    [SerializeField] private Transform backleftwheeltransform;

    [SerializeField] private Transform carcenterofmasstransform;
   

    [SerializeField] private float motorforce = 100f;
    [SerializeField] private float steeringangle = 20f;
    [SerializeField] private float brakeforce = 1000f;

    private  Rigidbody rigidbody;
    private float verticalinput;
    private float horizontalinput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbody=GetComponent<Rigidbody>();
        rigidbody.centerOfMass = carcenterofmasstransform.localPosition;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MotorForce();
        updatewheel();
        GetInput();
        Steering();
        applybrakes();
        powersteering();
    }
    void GetInput()
    {
        verticalinput = Input.GetAxis("Vertical");
        horizontalinput = Input.GetAxis("Horizontal");
    }
    void applybrakes()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            frontrightwheelcolider.brakeTorque = brakeforce;
            backrightwheelcolider.brakeTorque = brakeforce;
            frontleftwheelcolider.brakeTorque = brakeforce;
            backleftwheelcolider.brakeTorque = brakeforce;
            rigidbody.linearDamping = 1f;
        }
        else
        {
            frontrightwheelcolider.brakeTorque = 0f;
            backrightwheelcolider.brakeTorque = 0f;
            frontleftwheelcolider.brakeTorque = 0f;
            backleftwheelcolider.brakeTorque = 0f;
            rigidbody.linearDamping = 0f;
        }
    }
    void MotorForce()
    {
        frontrightwheelcolider.motorTorque = motorforce * verticalinput;
        frontleftwheelcolider.motorTorque = motorforce * verticalinput;
    }
    void Steering()
    {
        frontrightwheelcolider.steerAngle = steeringangle * horizontalinput;
        frontleftwheelcolider.steerAngle = steeringangle * horizontalinput;
    }
    void powersteering()
    {
        if(horizontalinput==0)
        {
            transform.rotation= Quaternion.Slerp(transform.rotation,Quaternion.Euler(0,0,0),Time.deltaTime);
        }
    }
    void updatewheel()
    {
        rotatewheel(frontrightwheelcolider, frontrightwheeltransform);
        rotatewheel(backrightwheelcolider, backrightwheeltransform);
        rotatewheel(frontleftwheelcolider, frontleftwheeltransform);
        rotatewheel(backleftwheelcolider, backleftwheeltransform);
    }
    void rotatewheel(WheelCollider wheelcolider,Transform transform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelcolider.GetWorldPose(out pos, out rot);
        transform.position = pos;
        transform.rotation = rot;
    }
}
