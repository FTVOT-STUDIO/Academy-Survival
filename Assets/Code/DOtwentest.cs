using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening; 

public class PopupButton : MonoBehaviour
{
    public GameObject popupObject; 
    private bool isPopupVisible = false;

    private void Start()
    {
        
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(TogglePopup);
        }
    }

    private void TogglePopup()
    {
        if (isPopupVisible)
        {
            
            popupObject.transform.DOScale(Vector3.zero, 0.5f).OnComplete(() => popupObject.SetActive(false));
        }
        else
        {
            
            popupObject.SetActive(true);
            popupObject.transform.localScale = Vector3.zero;
            popupObject.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack);
        }

        isPopupVisible = !isPopupVisible;
    }
}
