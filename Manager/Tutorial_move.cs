using UnityEngine;
using DG.Tweening;
using System.Collections;
using UnityEngine.UI;


public class Tutorial_move : MonoBehaviour
{
    [Header("Core")]
    [SerializeField] private float waitingTime;
    [SerializeField] private bool ShowTuto;

    [Header("Object")]
    [SerializeField] private RectTransform toptuto;
    [SerializeField] private RectTransform bottuto;
    [SerializeField] Image Line;


    void Start()
    {
        if (!PlayerPrefs.HasKey("show"))
        {
            PlayerPrefs.SetInt("show", 1);
            Load();
        }
        else
        {
            Load();
        }
        UpdateButtonIcon();
       
    }

    private void Update()
    {
       ImageController();
    }

    public void UpTutorial()
    {
      
        toptuto.DOAnchorPos(new Vector2(0, 700), 1.5f);

        _ = StartCoroutine(topBack());

    }

    public void BotTutorial()
    {

        bottuto.DOAnchorPos(new Vector2(0, -530), 1.5f);

        _ = StartCoroutine(BotBack());

    }

    IEnumerator topBack()
    {
        yield return new WaitForSeconds(waitingTime);

        toptuto.DOAnchorPos(new Vector2(0, 1500), 1.5f);

    }

    IEnumerator BotBack()
    {
        yield return new WaitForSeconds(waitingTime);

        bottuto.DOAnchorPos(new Vector2(0, -1500), 1.5f);

    }

    public void OnpressTuto()
    {
        if (ShowTuto == false)
        {
            ShowTuto = true;
          

        }
        else
        {
            ShowTuto = false;
           
        }
        Save();
        UpdateButtonIcon();
    }
    private void UpdateButtonIcon()
    {
        if (ShowTuto == false)
        {
            Line.enabled = true;
        }
        else
        {
            Line.enabled = false;
        }

    }

    private void ImageController()
    {
        if (ShowTuto == true)
        {
            toptuto.gameObject.SetActive(true);
            bottuto.gameObject.SetActive(true);
        }

        if (ShowTuto == false)
        {
            toptuto.gameObject.SetActive(false);
            bottuto.gameObject.SetActive(false);
        }
    }

    private void Load()
    {
        ShowTuto = PlayerPrefs.GetInt("show") == 1;
    }
    private void Save()
    {
        PlayerPrefs.SetInt("show", ShowTuto ? 1 : 0);
    }

 
}
