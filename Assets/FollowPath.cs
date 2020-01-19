using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject path;
    public float speed;
    private float distTraveled;
    private float distLeft;
    private int index;
    private Transform[] nodes;
    void Start()
    {
        distTraveled = 0;
        index = 0;
        nodes = path.GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (distTraveled == 0 && index < nodes.Length)
        {
            transform.LookAt(nodes[index]);
            distLeft = Vector3.Distance(transform.position, nodes[index].position);
        }
        
    }

    void FixedUpdate()
    {
        if (index < nodes.Length)
        {
            transform.position += (transform.forward / Vector3.Magnitude(transform.forward)) * speed;
            distLeft -= Vector3.Magnitude((transform.forward / Vector3.Magnitude(transform.forward)) * speed);
            distTraveled += Vector3.Magnitude((transform.forward / Vector3.Magnitude(transform.forward)) * speed);
            if (distLeft <= 0)
            {
                index++;
                distTraveled = 0;
            }
        }
    }
}
