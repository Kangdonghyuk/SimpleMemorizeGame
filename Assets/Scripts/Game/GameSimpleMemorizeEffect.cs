using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct YesNoEffectObject
{
    public GameObject gameObject;
    SpriteRenderer spriteRenderer;

    public void Init() {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.color = new Color(0f, 0f, 0f, 0f);
    }

    public void SetPosition(Vector3 position) {
        gameObject.transform.position = position;
    }

    public IEnumerator AnimationLightOn() {
        Color currentColor = Color.white;
        currentColor.a = 0.0f;

        for(int i=0; i<10; i++) {
            yield return null;

            currentColor.a += 0.1f;

            spriteRenderer.color = currentColor;
        }
        
        for(int i=0; i<10; i++) {
            yield return null;

            currentColor.a -= 0.1f;

            spriteRenderer.color = currentColor;
        }

        Init();
    }
}
public class GameSimpleMemorizeEffect : MonoBehaviour
{
    enum YESNO {
        YES = 0,
        NO = 1
    }

    public YesNoEffectObject[] yesNoEffectObjects = new YesNoEffectObject[2];

    public void Start() {
        yesNoEffectObjects[(int)YESNO.YES].Init();
        yesNoEffectObjects[(int)YESNO.NO].Init();
    }

    public void Yes(Vector3 position) {
        yesNoEffectObjects[(int)YESNO.YES].SetPosition(position);
        StartCoroutine(yesNoEffectObjects[(int)YESNO.YES].AnimationLightOn());
    } 
    public void No(Vector3 position) {
        yesNoEffectObjects[(int)YESNO.NO].SetPosition(position);
        StartCoroutine(yesNoEffectObjects[(int)YESNO.NO].AnimationLightOn());
    }
}
