using System.Collections;
using UnityEngine;

using UnityEngine.Playables;

public class ConcertReferences : MonoBehaviour
{

    #region  PUBLIC PARAMETERS
    public PlayableDirector _playableDirector = null;

    public Animator _centerBack = null;
    public Animator _rightBack = null;

    public Transform _spectatorsTransform = null;
    public Transform _probes = null;

    public Transform _spectatorsLights = null;

    public Transform _redLights = null;

    public Transform _cinemachineCameras = null;

    public float fadeTime = 0.4f;

    #endregion

    #region PROTECTED PARAMETERS

    protected Animator[] _spectatorsAnimators = null;

    //protected MainGameManager _mainGameManager = null;

    //protected PerJointImpostorInstancedIndirectGrid[] _spectatorsGrids = null;

    #endregion
    #region  UPDATE

    protected virtual void Awake()
    {
      //  _mainGameManager = FindObjectOfType(typeof(MainGameManager)) as MainGameManager;

      //if (_spectatorsTransform != null)
      //{
      //    _spectatorsGrids = _spectatorsTransform.GetComponentsInChildren<PerJointImpostorInstancedIndirectGrid>(true);
      //}

      //  if (_mainGameManager != null)
      //  {
      //      if (_cinemachineCameras != null)
      //          _cinemachineCameras.gameObject.SetActive(false);
      //      if (_playableDirector != null)
      //          _playableDirector.gameObject.SetActive(false);
      //  }
      //  else
      //  {
      //     // foreach (PerJointImpostorInstancedIndirectGrid grid in _spectatorsGrids)
      //        //  grid._minRadiusToVoids = 0.0f;          

      //      if (_cinemachineCameras != null)
      //          _cinemachineCameras.gameObject.SetActive(true);
      //      if (_playableDirector != null)
      //          _playableDirector.gameObject.SetActive(true);
      //  }

        if (_cinemachineCameras != null)
            _cinemachineCameras.gameObject.SetActive(true);
        if (_playableDirector != null)
            _playableDirector.gameObject.SetActive(true);
    }

    #endregion

    #region  SIGNAL RECEIVERS

    public virtual void BackBandSits()
    {
        if (_centerBack != null)
            _centerBack.SetTrigger("Play");

        if (_rightBack != null)
            _rightBack.SetTrigger("Play");
    }

    public void TriggerCrowdAnimation(string name)
    {
        if (_spectatorsAnimators == null && _spectatorsTransform != null)
            _spectatorsAnimators = _spectatorsTransform.GetComponentsInChildren<Animator>(true);
        foreach (Animator animator in _spectatorsAnimators)
        {
            if (animator.gameObject.activeInHierarchy)
               animator.SetTrigger(name);
        }
    }

    public void TriggerCrowdAnimationDelayed(string name)
    {
        if (_spectatorsAnimators == null && _spectatorsTransform != null)
            _spectatorsAnimators = _spectatorsTransform.GetComponentsInChildren<Animator>(true);
        foreach (Animator animator in _spectatorsAnimators)
        {
            if (animator.gameObject.activeInHierarchy)
                StartCoroutine(SetTriggerDelayed(1, animator, name));
            //     animator.SetTrigger(name);
        }
    }
    #endregion

    IEnumerator SetTriggerDelayed(float maxDelay, Animator animator, string name)
    {
        float delay = Random.Range(0, maxDelay);
        yield return new WaitForSeconds(delay);
        animator.SetTrigger(name);
    }

}
