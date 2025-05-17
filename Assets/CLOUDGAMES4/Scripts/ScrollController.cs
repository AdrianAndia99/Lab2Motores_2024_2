using UnityEngine;

public class InfiniteScrollSimple : MonoBehaviour
{
    public int speed;
    public float resetPosition;
    private void Update()
    {
        transform.position = transform.position + new Vector3(-speed * Time.deltaTime, 0);
        if(transform.position.x < resetPosition)
        {
            transform.position = new Vector3(Mathf.Abs(resetPosition),transform.position.y,transform.position.z);
        }

    }

}
