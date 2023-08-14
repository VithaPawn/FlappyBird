using System.Collections.Generic;
using UnityEngine;

public class BirdAnimator : MonoBehaviour {
    [SerializeField] private List<Sprite> spriteList;

    private SpriteRenderer spriteRenderer;
    private int spriteIndex;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        InvokeRepeating(nameof(ChangeSprite), 0.15f, 0.2f);
    }

    private void ChangeSprite()
    {
        spriteIndex++;
        if (spriteIndex >= spriteList.Count)
        {
            spriteIndex = 0;
        }
        spriteRenderer.sprite = spriteList[spriteIndex];
    }
}
