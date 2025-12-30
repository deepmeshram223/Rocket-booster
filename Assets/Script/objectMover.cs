using UnityEngine;

public class objectMover : MonoBehaviour
{
    [SerializeField] int speed;
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
}
