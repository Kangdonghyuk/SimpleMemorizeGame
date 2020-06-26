using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSimpleMemorize : MonoBehaviour
{
    public static GameSimpleMemorize I;

    public GameSimpleMemorizeEffect gameSimpleMemorizeEffect;
    public GameSimpleMemorizeScore gameSimpleMemorizeScore;
    public GameSimpleMemorizeTime gameSimpleMemorizeTime;

    public Box[,] simpleBoxes = new Box[2,2];

    List<Color> memorizeColorList = new List<Color>();

    int level, qusIndex;
    bool isQuestionSetting;

    void Awake() {
        I = this;

        for(int i=0; i<transform.childCount; i++)
            simpleBoxes[i / 2, i % 2] = transform.GetChild(i).GetComponent<Box>();
    }

    void Start()
    {
        level = 4;
        qusIndex = 0;

        isQuestionSetting = false;

        gameSimpleMemorizeScore.SetScore(0);

        gameSimpleMemorizeTime.Init();

        StartCoroutine(SettingSimpleBoxesColor());
    }

    void Initialize() {
        qusIndex = 0;
        
        memorizeColorList.RemoveRange(0, memorizeColorList.Count);

        for(int row = 0; row < 2; row++) {
            for(int col = 0; col < 2; col++)
                simpleBoxes[row, col].Init();
        }
    }

    void SettingAnswerList() {
        int row = Random.Range(0, 2);
        int col = Random.Range(0, 2);

        DefineColor.ColorStateInitialize();

        simpleBoxes[row, col].SetColor(memorizeColorList[qusIndex]);

        DefineColor.SetColorState(memorizeColorList[qusIndex]);

        for(int _row = 0; _row < 2; _row++) {
            for(int _col = 0; _col < 2; _col++) {
                if(_row == row && _col == col)
                    continue;
                
                simpleBoxes[_row, _col].SetColor(DefineColor.RandomColorUnique);
            }
        }
    }

    public void Answer(Box box) {
        if(isQuestionSetting)
            return;

        Color color = box.spriteRenderer.color;

        if(color == memorizeColorList[qusIndex]) {
            Debug.Log("Success");

            gameSimpleMemorizeEffect.Yes(box.transform.position);

            qusIndex += 1;

            gameSimpleMemorizeScore.AddScore(1);

            if(qusIndex < level)
                SettingAnswerList();
            else {
                Initialize();
                StartCoroutine(SettingSimpleBoxesColor());
            }
        }
        else {
            gameSimpleMemorizeEffect.No(box.transform.position);

            Debug.Log("Fail");
        }
    }

    IEnumerator SettingSimpleBoxesColor() {
        isQuestionSetting = true;

        gameSimpleMemorizeTime.Stop();

        for(int i = 0; i < level; i++) {
            int index = i % 4;

            int row = index / 2;
            int col = index % 2;

            yield return new WaitForSeconds(1.0f);
                
            memorizeColorList.Add(simpleBoxes[row, col].Setting());
        }

        yield return new WaitForSeconds(1.0f);

        SettingAnswerList();

        isQuestionSetting = false;

        gameSimpleMemorizeTime.Play();
    }
}
