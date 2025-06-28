using UnityEngine;

public class IgnoreCollision: MonoBehaviour
{
    public Collider ColliderCube1;
    public Collider ColliderCube2;

    void Start()
    {
        Physics.IgnoreCollision(ColliderCube1 , ColliderCube2);
    }
}
