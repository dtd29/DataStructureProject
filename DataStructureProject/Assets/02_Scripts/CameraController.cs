using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float smoothing = 0.2f;
    float minCameraBoundary;
    float maxCameraBoundary;
    float cameraY;

    private void Update()
    {
        switch (GameManager.Instance.currentMap)
        {
            case Maps.street:
                {
                    minCameraBoundary = 6368;
                    maxCameraBoundary = 12640;
                    cameraY = -4676;
                    break;
                }
            case Maps.school:
                {
                    minCameraBoundary = 6368;
                    maxCameraBoundary = 6436;
                    cameraY = -2874;
                    break;
                }
            case Maps.park:
                {
                    minCameraBoundary = 6368;
                    maxCameraBoundary = 9428;
                    cameraY = -1254;
                    break;
                }
            case Maps.home:
                {
                    minCameraBoundary = 6368;
                    maxCameraBoundary = 10434;
                    cameraY = 131;
                    break;
                }
        }
    }

    private void FixedUpdate()
    {
        Vector3 targetPos = new Vector3(player.position.x, cameraY, this.transform.position.z);

        targetPos.x = Mathf.Clamp(targetPos.x, minCameraBoundary, maxCameraBoundary);

        transform.position = Vector3.Lerp(transform.position, targetPos, smoothing);
    }
}