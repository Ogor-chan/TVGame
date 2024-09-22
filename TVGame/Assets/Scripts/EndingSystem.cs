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

    private string _trophiesEarned;

    private PlayerControl PC;
    private void Start()
    {
        _trophiesEarned = PlayerPrefs.GetString("save");
        PC = _playerController.GetComponent<PlayerControl>();

        print(_trophiesEarned);
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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ActivateEnding(0);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            PlayerPrefs.SetString("save", 9000000000000009.ToString());
            PlayerPrefs.Save();
        }
    }
    public void ActivateEnding(int _whichEnding)
    {
        PC.PauseVideo();
        _static.SetActive(true);
        _playerController.SetActive(false);

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

        yield return new WaitForSecondsRealtime(2f);
        _playButton.SetActive(true);

    }


    public void PlayButtonClick()
    {
        _Z.ZoomIn();
        _static.SetActive(false);
        _playerController.SetActive(true);
        PC.ReplayVideo();
        PC._pauseLock = false;

        _playButton.SetActive(false);
    }

}
