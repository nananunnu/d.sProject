using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //타이핑 구현
    public static GameManager instance;
    
    private AudioSource audioSource;

    public GameObject player;

    //public Text characterMsg;
    public Text explainMsg;
    public Text warnMsg;
    public GameObject warnPanel;
    public Button startBtn;

    bool isDeselected = false;

    void Awake()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();

        startBtn.onClick.AddListener(() => SceneTrans());
    }

    static public void SetMsgText(string text, float time = 1f)
    {
        instance.explainMsg.text = "";
        instance.audioSource.Play();
        instance.explainMsg.DOText(text, time).OnComplete(() =>
        {
            instance.audioSource.Stop();
        });
    }

    public void SceneTrans()
    {
        if(DataManager.instance.isSelectP1 && DataManager.instance.isSelectP2)
        {
            SceneManager.LoadScene("Stage01Scene");
        }
        else
        {
            warnPanel.SetActive(true);
            warnMsg.text = "플레이어 모두가 캐릭터를 선택하지 않았습니다";

            StartCoroutine(Panel());
        }
    }

    //코루틴으로 3초 뒤에 

    IEnumerator Panel()
    {
        yield return new WaitForSeconds(3);
        warnPanel.SetActive(false);

        StopAllCoroutines();
    }

}
