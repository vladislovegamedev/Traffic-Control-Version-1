using UnityEngine;

public class delete : MonoBehaviour
{
    public float timeToDelete = 2f;
    
    private void Start()
    {
        Destroy(gameObject, timeToDelete );
    }

    
}
