using UnityEngine;

public enum Maps
{
    street,
    school,
    park,
    home
}

public class GameManager : Singleton<GameManager>
{
    [Header("현재단계")]
    public int currentLevel = 0;

    [Header("현재 맵")]
    public Maps currentMap;

    [Header("이상현상 물체")]
    public GameObject[] StrangeObjects;

    [Header("메니저들")]
    public DialogueManager dialogueManager;
    public TutorialManager tutorialManager;

    [Header("플레이어")]
    [SerializeField] GameObject player;

    [Header("페이드")]
    public FadeInOut fadeInOut;

    [Header("바꾸기 XX")]
    public bool isEnteredSchool;
    public bool isEnteredHome;
    public bool isTalking;
    public bool isAttend;

    protected override void Awake()
    {
        Debug.Log("초기화");
        base.Awake();

        isTalking = false;
        isEnteredSchool = false;
        currentMap = Maps.street;
        currentLevel = 1;
    }

    void Start()
    {
        for (int i = 0; i < StrangeObjects.Length; i++)
        {
            StrangeObjects[i].SetActive(false);
        }
        StrangeObjects[0].SetActive(true);
    }

    public void NextLevel()
    {
        currentLevel++;
        fadeInOut.FadeIn();
        for (int i = 0; i < StrangeObjects.Length; i++)
        {
            StrangeObjects[i].SetActive(false);
        }

        if (!StrangeObjects[currentLevel - 1].GetComponent<StrangeObject>().isAttendObject)
        {
            StrangeObjects[currentLevel - 1].SetActive(true);
        }

        currentMap = Maps.street;
        isAttend = false;
    }

    public void PlayerMoveInit()
    {
        player.transform.position = new Vector3(5750, -4940, 0);
    }

}
