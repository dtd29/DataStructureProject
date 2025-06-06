using UnityEngine;

public class StrangeObject : MonoBehaviour
{
    public Dialogue[] findingDialogue;
    public bool isAttendObject;
    public bool isSkipObject;

    void Awake()
    {
        gameObject.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        if (collision.CompareTag("bullet"))
        {
            GameManager.Instance.dialogueManager.BigTextPrint(findingDialogue, true);
            Destroy(collision.gameObject);
            gameObject.SetActive(false);
        }
    }
}
