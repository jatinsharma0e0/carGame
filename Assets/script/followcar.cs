using UnityEngine;

public class followcar : MonoBehaviour
{
    private Transform playerCarTransform;
    private Transform camerapoinTransform;

    private Vector3 velocity = Vector3.zero;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerCarTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        camerapoinTransform = playerCarTransform.Find("camerapoint").GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.LookAt(playerCarTransform);
        transform.position = Vector3.SmoothDamp(transform.position, camerapoinTransform.position, ref velocity, 3f*Time.deltaTime);
    }
}
