using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OldTVHints : MonoBehaviour
{
    private string _trophiesEarned;

    private List<int> _endingsNotAchieved = new List<int>();

    [SerializeField] private TMP_Text _tvText;

    [SerializeField] private string[] _texts;
    private void Start()
    {
        RollaHint();
    }

    private void UpdateList()
    {
        _trophiesEarned = PlayerPrefs.GetString("save");

        print(_trophiesEarned);
        int whichLoop = 0;
        foreach (char c in _trophiesEarned)
        {
            int ye = c - '0';
            if (ye == 0)
            {
                _endingsNotAchieved.Add(whichLoop);
            }
            whichLoop++;
        }
    }

    public void RollaHint()
    {
        _endingsNotAchieved.Clear();
        UpdateList();
        print(_endingsNotAchieved.Count);
        _tvText.text = _texts[_endingsNotAchieved[Random.Range(0,
            _endingsNotAchieved.Count -1)]];
    }


}
