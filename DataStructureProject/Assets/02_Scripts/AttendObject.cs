using UnityEngine;

public class AttendObject : MonoBehaviour
{
    [SerializeField] Dialogue[] attendDialogue;
    private bool isEnter;

    void Awake()
    {
        isEnter = false;
    }

    void Update()
    {
        if (isEnter && !GameManager.Instance.isTalking)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameManager.Instance.StrangeObjects[GameManager.Instance.currentLevel - 1].SetActive(true);
                GameManager.Instance.isAttend = true;
                GameManager.Instance.dialogueManager.BigTextPrint(attendDialogue, false);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("플레이어 감지");
            isEnter = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("플레이어 나감");
            isEnter = false;
        }
    }
}
