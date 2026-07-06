using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[RequireComponent(typeof(Button))] // 버튼 컴포넌트가 필요한 경우

public class ButtonAnimation : MonoBehaviour
{
    public float popScale = 1.1f; // 팝업 효과에 사용할 스케일 값
    public float popDuration = 0.2f; // 팝업 애니메이션 지속 시간
    public AudioClip clickSound; // 클릭 효과음
    private Vector3 originalScale;
    private Button button;
    private AudioSource audioSource;

    private void Start()
    {
        button = GetComponent<Button>();
        originalScale = transform.localScale;

        // AudioSource 컴포넌트 가져오기
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // AudioSource가 없다면 새로 추가
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // 버튼 클릭 이벤트에 DOTween 애니메이션 및 효과음 재생 함수 연결
        button.onClick.AddListener(() =>
        {
            PopAnimation();
            PlayClickSound();
        });
    }

    public void PopAnimation()
    {
        // 버튼을 팝업 효과로 확대하고 다시 원래 크기로 돌립니다.
        transform.DOScale(popScale, popDuration).OnComplete(() =>
        {
            transform.DOScale(originalScale, popDuration);
        });
    }

    private void PlayClickSound()
    {
        // 효과음 재생
        if (audioSource != null && clickSound != null)
        {
            audioSource.PlayOneShot(clickSound);
        }
    }
}