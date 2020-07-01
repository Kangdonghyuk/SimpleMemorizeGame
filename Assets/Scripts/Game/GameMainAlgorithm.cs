using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMainAlgorithm : MonoBehaviour
{
    public static GameMainAlgorithm I;
    public GameMainEffect gameMainEffect;

    public const int ROW = 2, COL = 2;

    public Box[,] boxes = new Box[ROW, COL];
    List<Color> memorizeColorList = new List<Color>();

    int level, questionIndex, combo;
    bool isDoQuestionSetting;

    void Awake() {
        I = this;

        for(int i=0; i<transform.childCount; i++)
            boxes[i / 2, i % 2] = transform.GetChild(i).GetComponent<Box>();
    }

    void Start()
    {
        level = CoreInfo.levelCount;
        questionIndex = 0;
        combo = 0;

        isDoQuestionSetting = false;

        GameMainUI.I.Init();
        GameTimer.I.Init();

        StartCoroutine(SettingSimpleBoxesColor());
    }

    void Update()
    {
        
    }

    void Initialize() {
        questionIndex = 0;
        
        memorizeColorList.RemoveRange(0, memorizeColorList.Count);

        for(int row = 0; row < ROW; row++) {
            for(int col = 0; col < COL; col++)
                boxes[row, col].Init();
        }
    }

    void SettingAnswerList() {
        int row = Random.Range(0, ROW);
        int col = Random.Range(0, COL);

        DefineColor.ColorStateInitialize();

        boxes[row, col].SetColor(memorizeColorList[questionIndex]);

        DefineColor.SetColorState(memorizeColorList[questionIndex]);

        for(int _row = 0; _row < 2; _row++) {
            for(int _col = 0; _col < 2; _col++) {
                if(_row == row && _col == col)
                    continue;
                
                boxes[_row, _col].SetColor(DefineColor.RandomColorUnique);
            }
        }
    }

    public void Answer(Box box) {
        if(isDoQuestionSetting)
            return;

        Color color = box.spriteRenderer.color;

        if(color == memorizeColorList[questionIndex]) {
            Debug.Log("Success");

            gameMainEffect.Yes(box.transform.position);

            questionIndex += 1;
            combo += 1;
            
            
            Debug.Log("Combo " + combo.ToString() + " Score : " + (1 + (combo / 10)).ToString());
            GameMainUI.I.AddScore(1 + (combo / 10));

            if(questionIndex < level) {
                SettingAnswerList();
            }
            else {
                Debug.Log("Time Score : " + Mathf.Clamp(5 - (int)GameTimer.I.answerTime, 0, 5).ToString());
                GameMainUI.I.AddScore(Mathf.Clamp(5 - (int)GameTimer.I.answerTime, 0, 5));
                Initialize();
                StartCoroutine(SettingSimpleBoxesColor());
            }
        }
        else {
            combo = 0;
            gameMainEffect.No(box.transform.position);

            Debug.Log("Fail");
        }
    }

    IEnumerator SettingSimpleBoxesColor() {
        isDoQuestionSetting = true;

        GameMainUI.I.Stop();

        for(int i = 0; i < level; i++) {
            int index = i % (ROW * COL);

            int row = index / ROW;
            int col = index % COL;

            yield return new WaitForSeconds(1.0f);
                
            memorizeColorList.Add(boxes[row, col].Setting());
        }

        yield return new WaitForSeconds(1.0f);

        SettingAnswerList();

        isDoQuestionSetting = false;

        GameMainUI.I.Play();
    }
}
