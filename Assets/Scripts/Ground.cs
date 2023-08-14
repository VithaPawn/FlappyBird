using UnityEngine;

public class Ground : MonoBehaviour {
    [SerializeField] private float movingSpeed = 1f;

    private MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        meshRenderer.material.mainTextureOffset += new Vector2(movingSpeed * Time.deltaTime, 0);
    }
}
