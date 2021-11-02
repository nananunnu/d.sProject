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

    void Awake()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {

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
        SceneManager.LoadScene("Stage01Scene");
    }

}
