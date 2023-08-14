using UnityEngine;

public class Pipe : MonoBehaviour {
    private const float PIPE_OFFSET_X_MIN = -10f;

    [SerializeField] private float movingSpeed = 1f;

    private void Update()
    {
        HandleMovement();
        if (transform.position.x <= PIPE_OFFSET_X_MIN)
        {
            Destroy(gameObject);
        }
    }

    private void HandleMovement()
    {
        transform.position += Vector3.left * movingSpeed * Time.deltaTime;
    }


}
