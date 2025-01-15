using System.Collections.Generic;
using UnityEngine;

public class DeleteThis : MonoBehaviour
{
    public List<Sprite> sprites;
    private SpriteRenderer spriteRenderer;
    private int currentPunchIndex = 1;
    private float idleDelay = 0.5f; // Tempo em segundos para voltar ao sprite idle
    private float idleTimer = 0f;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (sprites.Count >= 3)
            spriteRenderer.sprite = sprites[0];
        else
            Debug.LogError("Parece q o macaco burro esqueceu de colocar os sprites");
    }

    private void Awake() => InputManager.onPunched += CarrotClickCallback;
    private void OnDestroy() => InputManager.onPunched -= CarrotClickCallback;
    private void Update()
    {
        if (spriteRenderer.sprite != sprites[0]) 
        {
            idleTimer += Time.deltaTime;
            if (idleTimer >= idleDelay)
            {
                SetIdleSprite();
            }
        }
    }
    void CarrotClickCallback()
    {
        ChangeSprite();
        idleTimer = 0f;
    }

    void ChangeSprite()
    {
        if (sprites.Count < 3) return;

        spriteRenderer.sprite = sprites[currentPunchIndex];
        currentPunchIndex = currentPunchIndex == 1 ? 2 : 1;
    }

    void SetIdleSprite()
    {
        spriteRenderer.sprite = sprites[0];
        idleTimer = 0f;
    }
}
