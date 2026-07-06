using UnityEngine;
using DG.Tweening;

public class PopupAnimation : MonoBehaviour
{
    private RectTransform popupTransform;

    private void Start()
    {
        popupTransform = GetComponent<RectTransform>();
    }

    public void ShowPopup()
    {
        // 팝업 창이 나타날 때의 애니메이션
        popupTransform.localScale = Vector3.zero;
        popupTransform.gameObject.SetActive(true);
        popupTransform.DOScale(Vector3.one, 0.3f).SetEase(Ease.OutBounce);
    }

    public void HidePopup()
    {
        // 팝업 창이 사라질 때의 애니메이션
        popupTransform.DOScale(Vector3.zero, 0.3f).OnComplete(() => popupTransform.gameObject.SetActive(false));
    }
}
