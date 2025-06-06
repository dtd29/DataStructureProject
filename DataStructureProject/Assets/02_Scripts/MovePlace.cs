using UnityEngine;

public class MovePlace : MonoBehaviour
{
    [SerializeField] Maps targetPlace;
    [SerializeField] GameObject player;

    private bool isEnter;

    void Start()
    {
        isEnter = false;
        player.transform.position = new Vector3(5750, -4940, 0);
    }

    void Update()
    {
        if (isEnter && !GameManager.Instance.isTalking)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GoTargetPlace();
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

    void GoTargetPlace()
    {
        Debug.Log("이동!");
        switch (targetPlace)
        {
            case Maps.street:
                {
                    if (GameManager.Instance.currentMap == Maps.home)
                    {
                        player.transform.position = new Vector3(5750, -4940, 0);
                    }
                    else if (GameManager.Instance.currentMap == Maps.park)
                    {
                        player.transform.position = new Vector3(9860, -4940, 0);
                    }
                    else if (GameManager.Instance.currentMap == Maps.school)
                    {
                        player.transform.position = new Vector3(13000, -4940, 0);
                    }
                    break;
                }

            case Maps.school:
                {
                    player.transform.position = new Vector3(7032, -3102, 0);
                    if (!GameManager.Instance.isEnteredSchool)
                    {
                        GameManager.Instance.isEnteredSchool = true;
                        GameManager.Instance.tutorialManager.SchoolTutorialStart();
                    }
                    break;
                }

            case Maps.park:
                {
                    player.transform.position = new Vector3(5900, -1508, 0);
                    break;
                }

            case Maps.home:
                {
                    player.transform.position = new Vector3(5845, -102, 0);
                    if (!GameManager.Instance.isEnteredHome)
                    {
                        GameManager.Instance.isEnteredHome = true;
                        GameManager.Instance.tutorialManager.HomeTutorialStart();
                    }
                    break;
                }
        }
        GameManager.Instance.currentMap = targetPlace;

    }
}
