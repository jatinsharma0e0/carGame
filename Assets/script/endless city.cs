using UnityEngine;

public class endlesscity : MonoBehaviour
{
    [SerializeField] Transform playercartransform;
    [SerializeField] Transform othercitytransform;
    [SerializeField] float halflength;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playercartransform.position.z>transform.position.z+halflength+10f)
        {
            transform.position=new Vector3(0,0,othercitytransform.position.z+halflength*2);
        }
    }
}
