using System.Collections;
using TMPro;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string desa;
    public GameObject showimg;
}

public class DialogueManager : MonoBehaviour
{
    [SerializeField] GameObject textPrintWindow;
    [SerializeField] TMP_Text dialogueText;
    [SerializeField] TMP_Text dayText;
    [SerializeField] private float printSpeed;

    void Awake()
    {
        textPrintWindow.SetActive(false);
    }

    void Update()
    {
        if (GameManager.Instance.isTalking)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                printSpeed = 0;
            }
        }
    }

    public void BigTextPrint(Dialogue[] dialogue, bool strangeFind)
    {
        textPrintWindow.SetActive(true);
        StartCoroutine(CTextPriter(dialogue, strangeFind));
    }

    IEnumerator CTextPriter(Dialogue[] dialogue, bool strangeFind)
    {
        GameManager.Instance.isTalking = true;

        for (int i = 0; i < dialogue.Length; i++)
        {
            printSpeed = 0.07f;
            dialogueText.text = "";

            if (dialogue[i].showimg != null) dialogue[i].showimg.SetActive(true);

            for (int j = 0; j < dialogue[i].desa.Length; j++)
            {
                dialogueText.text += dialogue[i].desa[j];
                yield return new WaitForSeconds(printSpeed);
            }

            yield return new WaitUntil(() => { return Input.GetKeyDown(KeyCode.Space); }); //스페이스 눌릴때까지 대기
            printSpeed = 0.07f;
            if (dialogue[i].showimg != null) dialogue[i].showimg.SetActive(false);

        }

        if (strangeFind)
        {
            GameManager.Instance.NextLevel();
        }
        dialogueText.text = "";
        textPrintWindow.SetActive(false);
        GameManager.Instance.isTalking = false;
    }

    public void DayTextPrint()
    {
        StartCoroutine(DayTextPrinter());
    }

    IEnumerator DayTextPrinter()
    {
        GameManager.Instance.isTalking = true;
        dayText.text = "";
        string tempText = "Day " + GameManager.Instance.currentLevel.ToString();

        for (int i = 0; i < tempText.Length; i++)
        {
            dayText.text += tempText[i];
            yield return new WaitForSeconds(0.2f);
        }
        yield return new WaitForSeconds(1.5f);
        GameManager.Instance.isTalking = false;
        GameManager.Instance.fadeInOut.FadeOut();
    }

}
