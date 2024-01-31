using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target;

    [SerializeField] private float _cameraSpeed = 15f;
    private float _maxY = 20f;
    private float _minY = 0f;

    private void Start()
    {
        Time.timeScale = 1.0f;
    }

    private void FixedUpdate()
    {
        if (target != null)
        {
            float cameraY = Mathf.Clamp(target.transform.position.y, _minY, _maxY);
            Vector3 TargetPos = new Vector3(0, cameraY, -10f);
            transform.position = Vector3.Lerp(transform.position, TargetPos, Time.deltaTime * _cameraSpeed);
        }
        else return;
    }
}
