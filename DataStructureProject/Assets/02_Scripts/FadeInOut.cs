using UnityEngine;

public class FadeInOut : MonoBehaviour
{
    private GameObject blackPanel;
    private Animator anim;

    void Awake()
    {
        blackPanel = transform.GetChild(0).gameObject;
        anim = GetComponent<Animator>();
        //blackPanel.SetActive(false);
    }


    public void FadeIn()
    {
        blackPanel.SetActive(true);
        Debug.Log("페이드 시작");
        anim.SetTrigger("fadeIn");
    }

    public void FadeInCallBack()
    {
        GameManager.Instance.dialogueManager.DayTextPrint();
        GameManager.Instance.PlayerMoveInit();
    }

    public void FadeOut()
    {
        anim.SetTrigger("fadeOut");
    }

    public void FadeOutCallBack()
    {
        blackPanel.SetActive(false);
        anim.SetBool("fadeOut", false);
        if(GameManager.Instance.currentLevel == 1) GameManager.Instance.tutorialManager.startTutorialStart();
    }
}
