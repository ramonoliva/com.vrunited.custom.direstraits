using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class ConcertStarter : MonoBehaviour
{

    #region PUBLIC ATTRIBUTES

    public static bool START_CONCERT = false;

    public PlayableDirector _playableDirector = null;
    public AudioSource _ambience = null;

    #endregion

    #region CREATION AND DESTRUCTION

    protected virtual void Start()
    {
        if (_playableDirector)
        {
            _playableDirector.gameObject.SetActive(false);
        }
    }

    #endregion

    #region GET AND SET

    //[ButtonMethod]
    public virtual void StartConcert()
    {
        _playableDirector.gameObject.SetActive(true);
        StartCoroutine(CoDisableAmbience());
    }

    #endregion

    #region UPDATE

    // Update is called once per frame
    protected virtual void Update()
    {
        if (!_playableDirector.gameObject.activeSelf && START_CONCERT)
        {
            StartConcert();
        }

        //if (InputManager.GetButtonDown(InputManager.DEFAULT_BUTTON_CONTINUE))
        //{
        //    _playableDirector.gameObject.SetActive(true);
        //}
    }

    protected virtual IEnumerator CoDisableAmbience()
    {
        float maxTime = 5;
        for (float elapsedTime = 0; elapsedTime <= maxTime; elapsedTime += Time.deltaTime)
        {
            _ambience.volume = Mathf.Lerp(1, 0, elapsedTime / maxTime);
            yield return null;
        }

        _ambience.gameObject.SetActive(false);
    }

    #endregion

}