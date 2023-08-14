using UnityEngine;

public class Background : MonoBehaviour {
    [SerializeField] private float movingSpeed = 0.5f;

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
