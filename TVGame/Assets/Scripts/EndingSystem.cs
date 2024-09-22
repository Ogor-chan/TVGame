using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
public class EndingSystem : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    [SerializeField] private Zooming _Z;
    [SerializeField] private GameObject _static;

    [SerializeField] private GameObject[] _trophies;
    [SerializeField] private GameObject _playerController;
    [SerializeField] private GameObject _playButton;
    [SerializeField] private OldTVHints _oldTV;
    [SerializeField] private AudioSource ASS;
    [SerializeField] private MenuNavigation MN;

    private string _trophiesEarned;

    private PlayerControl PC;


    private void Start()
    {
        if (!PlayerPrefs.HasKey("firstTime"))
        {
            print("first time");
            PlayerPrefs.SetString("save", "90000000000000009");
            PlayerPrefs.SetInt("firstTime", 0);
            PlayerPrefs.Save();
        }

        _trophiesEarned = PlayerPrefs.GetString("save");
        PC = _playerController.GetComponent<PlayerControl>();
        _oldTV = GameObject.Find("OldTV").GetComponent<OldTVHints>();

        int whichLoop = 0;
        foreach (char c in _trophiesEarned)
        {
            int ye = c - '0';
            if(ye == 1)
            {
                _trophies[whichLoop - 1].SetActive(true);
            }
            whichLoop++;
        }
    }

    public void ActivateEnding(int _whichEnding)
    {
        ASS.Play();
        MN.ASss.Pause();
        PC.PauseVideo();
        _static.SetActive(true);
        _playerController.SetActive(false);
        _oldTV.RollaHint();
        PC.End();

        StringBuilder modifiedString = new StringBuilder(_trophiesEarned);
        modifiedString[_whichEnding + 1] = (char)('0'+ 1);
        _trophiesEarned = modifiedString.ToString();
        PlayerPrefs.SetString("save", _trophiesEarned);
        PlayerPrefs.Save();

        StartCoroutine(EndingAnim(_whichEnding));
    }

    IEnumerator EndingAnim(int _whichEnding)
    {
        yield return new WaitForSecondsRealtime(2f);
        _Z.ZoomOut();
        yield return new WaitForSecondsRealtime(2f);

        GameObject _trophy = _trophies[_whichEnding];
        _trophy.GetComponent<Image>().color = Color.black;
        _trophy.SetActive(true);

        yield return new WaitForSecondsRealtime(1f);

        _trophy.GetComponent<Image>().color = Color.white;

        int howManyZeros = 0;
        foreach (char c in _trophiesEarned)
        {
            if (c == '0')
            {
                howManyZeros++;
            }

        }

        if(howManyZeros == 1)
        {
            StringBuilder modifiedString = new StringBuilder(_trophiesEarned);
            modifiedString[15] = (char)('0' + 1);
            _trophiesEarned = modifiedString.ToString();
            PlayerPrefs.SetString("save", _trophiesEarned);
            PlayerPrefs.Save();
            _trophy = _trophies[14];
            _trophy.GetComponent<Image>().color = Color.black;
            _trophy.SetActive(true);

            yield return new WaitForSecondsRealtime(1f);

            _trophy.GetComponent<Image>().color = Color.white;
        }

        yield return new WaitForSecondsRealtime(2f);
        _playButton.SetActive(true);

    }


    public void PlayButtonClick()
    {
        ASS.Stop();
        MN.ASss.Play();
        MN.ASss.Pause();
        _Z.ZoomIn();
        _static.SetActive(false);
        _playerController.SetActive(true);
        PC.MyASS.Play();
        PC.ReplayVideo();
        PC._pauseLock = false;

        _playButton.SetActive(false);
    }

}
