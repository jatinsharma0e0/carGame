using UnityEngine;

public class cameramovement : MonoBehaviour
{
    [SerializeField] Transform playercartransform;
    [SerializeField] float offset = -5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 camerapos=transform.position;
        camerapos.z = playercartransform.position.z + offset;
        transform.position = camerapos;
    }
}
