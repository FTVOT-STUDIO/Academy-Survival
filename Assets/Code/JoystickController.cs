using UnityEngine;

public class JoystickController : MonoBehaviour
{
    private Vector3 initialPosition; // 조이스틱의 초기 위치
    private Vector3 currentPosition; // 현재 조이스틱 위치

    private bool isActive = true; // 조이스틱 활성/비활성 상태

    void Start()
    {
        // 조이스틱의 초기 위치 저장
        initialPosition = transform.position;
    }

    void Update()
    {
        if (!isActive)
        {
            // 조이스틱이 비활성 상태라면 입력을 초기화
            currentPosition = initialPosition;
        }
        else
        {
            // 현재 조이스틱 위치 가져오기
            currentPosition = transform.position;
        }
    }

    // 조이스틱 초기화 메서드
    public void ResetJoystick()
    {
        // 조이스틱을 초기 위치로 되돌림
        transform.position = initialPosition;
        // 입력 초기화
        currentPosition = initialPosition;
    }

    // 조이스틱 활성/비활성 상태 설정 메서드
    public void SetActive(bool active)
    {
        isActive = active;

        // 조이스틱 비활성화 시 초기화
        if (!isActive)
        {
            ResetJoystick();
        }
    }

    // 현재 조이스틱 입력 반환
    public Vector2 GetJoystickInput()
    {
        // 조이스틱 입력을 중심에서 현재 위치로 계산
        Vector2 input = new Vector2(
            (currentPosition.x - initialPosition.x) / (initialPosition.x * 2),
            (currentPosition.y - initialPosition.y) / (initialPosition.y * 2)
        );

        // 입력값을 클램핑하여 -1과 1 사이로 유지
        input = Vector2.ClampMagnitude(input, 1f);

        return input;
    }
}
