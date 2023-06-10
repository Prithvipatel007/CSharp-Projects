using UnityEngine;

public class MoveBackForth : MonoBehaviour
{

    public GameObject[] waypoints;
    int current = 0;
    float rotSpeed;
    public float speed = 2.5f;
    float WPradius = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*// move the cube from (0,0,0) to (5,0,0) and back to (0,0,0) and so on
        // use the Mathf.PingPong function to the other axes if you need to move in those axes as well

        transform.position = new Vector3(Mathf.PingPong(Time.time * Speed, 5),
                                        transform.position.y,
                                        transform.position.z            
            );*/

        if(Vector3.Distance(waypoints[current].transform.position,transform.position)<WPradius)
        {
            current++;
            if(current >= waypoints.Length)
            {
                current = 0;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, waypoints[current].transform.position, Time.deltaTime * speed);

    }
}
