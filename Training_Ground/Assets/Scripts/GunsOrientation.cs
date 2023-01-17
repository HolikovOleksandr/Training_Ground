using UnityEngine;

public class GunsOrientation : MonoBehaviour
{
    public Transform orientation;

    private void Update() 
    {
        transform.rotation = orientation.rotation;    
    }
}
