using UnityEngine;

public class PPENEMY : MonoBehaviour
{
    private void Update()
    {
        if (!PPSTATICHELPER.PPisGame)
            return;
        
        transform.Translate(Vector3.down * 5f * Time.deltaTime, Space.World);
        
        transform.Rotate(Vector3.forward * 20f * Time.deltaTime);
        
        if (transform.position.y < -20f)
        {
            Destroy(gameObject);
        }
    }
}