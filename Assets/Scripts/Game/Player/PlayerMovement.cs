using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float moveSpeed = 2f;
    [SerializeField] TouchController touchController;
    [SerializeField] StartTimer _startTimer;
    private Vector3 direction;
    bool isMove;

    private void OnEnable()
    {
        touchController.TouchEvent += Movement;
        _startTimer.TimeIsUp += () =>
        {
            isMove = true;
            direction = Vector3.forward;
        };
    }

    void Update()
    {
        if (isMove)
            PlayerMove();
    }

    private void Movement(TouchController.ActionTipe action)
    {
        switch (action)
        {
            case TouchController.ActionTipe.Right:
                direction = Vector3.back;
                break;
            case TouchController.ActionTipe.Left:
                direction = Vector3.forward;
                break;
            case TouchController.ActionTipe.Up:
                direction = Vector3.right;
                break;
            case TouchController.ActionTipe.Down:
                direction = Vector3.left;
                break;
        }
    }

    void PlayerMove()
    {
        Vector3 targetPosition = transform.position + direction;
        targetPosition.x = Mathf.Clamp(targetPosition.x, GridGenerator.GridInfo.GetGridMin_x, GridGenerator.GridInfo.GetGridMax_x);
        targetPosition.z = Mathf.Clamp(targetPosition.z, GridGenerator.GridInfo.GetGridMin_z, GridGenerator.GridInfo.GetGridMax_z);
        targetPosition.y = transform.position.y;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 500f * Time.deltaTime);
        }
    }
}
