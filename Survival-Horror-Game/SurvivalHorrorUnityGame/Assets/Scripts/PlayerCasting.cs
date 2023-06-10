using UnityEngine;

public class PlayerCasting : MonoBehaviour
{
    public static float DistanceFromTarget;

    public float ToTarget;

    // Update is called once per frame
    void Update()
    {
        RaycastHit Hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Hit)) // if we find the raycast
        {
            ToTarget = Hit.distance;
            DistanceFromTarget = ToTarget;
        }
    }
}
