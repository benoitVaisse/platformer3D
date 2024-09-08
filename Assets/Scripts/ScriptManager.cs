using System.Collections;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ScriptManager : MonoBehaviour
{
    private static ScriptManager _instance;
    public static ScriptManager GetInstance() { return _instance; }

    private const string PLAYEROBJECTNAME = "CharacterPainEpice";
    private const string CANVASOBJECTNAME = "Canvas";

    public GameObject canvas;
    public Sprite heart;
    public Sprite heartEmpty;

    private void Awake()
    {
        _instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.Find(CANVASOBJECTNAME);
        heart = Resources.Load<Sprite>("heart");
        heartEmpty = Resources.Load<Sprite>("heart-empty");

        InitHeart();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void InitHeart()
    {
        PlayerLifeSystem playerController = GameObject.Find(PLAYEROBJECTNAME).GetComponent<PlayerLifeSystem>();
        for (int i = 1; i<= playerController.life; i++)
        {
            canvas.transform.Find($"heart{i}").GetComponent<Image>().sprite = heart;
        }
    }

    public void SetUIlife(int life, bool isAdded)
    {
        if (canvas.transform.Find($"heart{life}") is Transform image && image.GetComponent<Image>() is Image heartImage)
        {
            heartImage.sprite = isAdded ? heart : heartEmpty;
            
        }
    } 

    public void SetNumberCoin(int coin)
    {
        if (canvas.transform.Find($"CoinText") is Transform coinText && coinText.GetComponent<TMP_Text>() is TMP_Text text)
        {
            text.SetText(coin.ToString().PadLeft(2, '0'));
        }
    }

    public void SetTextInfo(string text)
    {
        if (canvas.transform.Find($"TextInfo") is Transform textInfoTransform && textInfoTransform.GetComponent<TMP_Text>() is TMP_Text textInfo)
        {
            textInfo.SetText(text);
        }
    }
}
