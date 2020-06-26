using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    void Start() {
        spriteRenderer.color = Color.white;
    }

    public void Init() {
        spriteRenderer.color = Color.white;
    }

    public Color Setting()
    {
        spriteRenderer.color = DefineColor.RandomColor;

        StartCoroutine(AnimationLightOn());

        return spriteRenderer.color;
    }

    public void SetColor(Color color) {
        spriteRenderer.color = color;
    }

    IEnumerator AnimationLightOn() {
        Color currentColor = spriteRenderer.color;
        currentColor.a = 0.5f;

        for(int i=0; i<10; i++) {
            yield return null;

            currentColor.a += 0.05f;

            spriteRenderer.color = currentColor;
        }
    }

    void OnMouseDown() {
        //GameSimpleMemorize.I.Answer(spriteRenderer.color);
        GameSimpleMemorize.I.Answer(this);
    }
}
