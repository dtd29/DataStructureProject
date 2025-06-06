using UnityEngine;

public class SkipObject : MonoBehaviour
{
    [SerializeField] Dialogue[] skipFailDialogue;
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
                if (GameManager.Instance.isAttend)
                {
                    StrangeObject strangeObject = GameManager.Instance.StrangeObjects[GameManager.Instance.currentLevel - 1].GetComponent<StrangeObject>();
                    if (strangeObject.isSkipObject)
                    {
                        GameManager.Instance.dialogueManager.BigTextPrint(strangeObject.findingDialogue, true);
                    }
                }
                else
                {
                    GameManager.Instance.dialogueManager.BigTextPrint(skipFailDialogue, false);   
                }
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
