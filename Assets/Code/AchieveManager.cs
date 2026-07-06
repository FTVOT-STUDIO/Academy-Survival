using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class AchieveManager : MonoBehaviour
{
    public GameObject[] lockCharacter;
    public GameObject[] unlockCharacter;
    public GameObject uiNotice;


    enum Achieve { UnlockLuna, UnlockZoomoji }
    Achieve[] achieves;
    WaitForSecondsRealtime wait;


    private void Awake()
    {
        achieves = (Achieve[])Enum.GetValues(typeof(Achieve));
        wait = new WaitForSecondsRealtime(5);

        if (!PlayerPrefs.HasKey("MyDate"))
        {
            Init();
        }
    }

    void Init()
    {
        PlayerPrefs.SetInt("MyDate", 1);

        foreach (Achieve achieve in achieves)
        {
            PlayerPrefs.SetInt(achieve.ToString(), 0);
        }
    }
    void Start()
    {
        UnlockCharater();
    }

    void UnlockCharater()
    {
        for (int index=0; index < lockCharacter.Length; index++)
        {
            string achiveName = achieves[index].ToString();
            bool isUnlock = PlayerPrefs.GetInt(achiveName) == 1;
            lockCharacter[index].SetActive(!isUnlock);
            unlockCharacter[index].SetActive(isUnlock);
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        foreach (Achieve achieve in achieves)
        {
            CheckAchive(achieve);
        }
    }

    void CheckAchive(Achieve achieve)
    {
        bool isAchive = false;

        switch (achieve)
        {
            case Achieve.UnlockLuna:
                isAchive = GameManager.Instance.kill >= 100;
                break;
            case Achieve.UnlockZoomoji:
                isAchive = GameManager.Instance.gameTime == GameManager.Instance.maxGameTime;
                break;
        }

        if (isAchive && PlayerPrefs.GetInt(achieve.ToString()) == 0)
        {
            PlayerPrefs.SetInt(achieve.ToString(), 1);

            for (int index=0; index < uiNotice.transform.childCount; index++)
            {
                bool isActive = index == (int)achieve;
                uiNotice.transform.GetChild(index).gameObject.SetActive(isActive);

            }
            StartCoroutine(NoticeRoutine());

        }
    }

    IEnumerator NoticeRoutine()
    {
        uiNotice.SetActive(true);
        AudioManager.instance.PlaySfx(AudioManager.Sfx.levelUp);



        yield return wait;

        uiNotice.SetActive(false);
    }
}
