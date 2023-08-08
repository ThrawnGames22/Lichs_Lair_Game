using System.Collections;

using UnityEngine;

public class CameraSmoothFollow : MonoBehaviour
{

    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    /*
    public Transform target;
    public float cameraSpeed = 15;
    public float zOffset = 22;
    public bool smoothFollow = true;
    */

    //private Vector3 offset = new Vector3(0f, 0f, -10f);
    //private float smoothTime = 0.25f;
    //private Vector3 Velocity = Vector3.zero;

    //[SerializeField] private Transform target;
    // Start is called before the first frame update
    void Start()
    {
      target = GameObject.FindGameObjectWithTag("Player").transform;   
    }

    // Update is called once per frame
    void Update()
    {

        
        /*
        if(target)
        {
            Vector3 newPos = transform.position;
            newPos.x = target.position.x;
            newPos.x = target.position.z - zOffset;

            if(!smoothFollow)
            {
                transform.position = newPos;

            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, newPos, cameraSpeed * Time.deltaTime);
            }
        }
        */
        //Vector3 targetPostion = target.position + offset;
        //transform.position = Vector3.SmoothDamp(transform.position, targetPostion, ref Velocity, smoothTime);
    }

    void FixedUpdate()
    {
        //Smooth Follow The camera based on Target
        if(target != null)
        {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        transform.LookAt(target);
        }
    }
}
