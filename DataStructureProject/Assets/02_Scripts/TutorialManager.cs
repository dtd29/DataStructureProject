using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [Header("Dialogue 메니저")]
    [SerializeField] DialogueManager dialogueManager;

    [Header("시작튜토리얼")]
    [SerializeField] Dialogue[] startTutorial;

    [Header("출석튜토리얼")]
    [SerializeField] Dialogue[] schoolTurorlal;

    [Header("집튜토리얼")]
    [SerializeField] Dialogue[] homeTurorlal;

    public void startTutorialStart()
    {
        dialogueManager.BigTextPrint(startTutorial, false);
    }

    public void SchoolTutorialStart()
    {
        dialogueManager.BigTextPrint(schoolTurorlal, false);
    }

    public void HomeTutorialStart()
    {
        dialogueManager.BigTextPrint(homeTurorlal, false);
    }
}
