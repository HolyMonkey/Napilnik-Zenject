using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ZombiePaddockView : MonoBehaviour
{ 
    private List<GameObject> _zombiesViews;

    private GameObject _view; 
    private ZombiePaddock _paddock; 
    
    [Inject]
    private void Contstructor(List<GameObject> zombiesViews, ZombiePaddock paddock)
    {
        _zombiesViews = zombiesViews;
        _paddock = paddock;
    }

    private void OnEnable()
    {
        _paddock.ProgressNormalized += ShowProgress; 
    }

    private void OnDisable()
    {
        _paddock.ProgressNormalized -= ShowProgress;
    }

    private void ShowProgress(float normalized) 
    {
        if (normalized == 0 && _view != null)
            Destroy(_view);

        int targetView = (int)Mathf.Lerp(0, _zombiesViews.Count, normalized) - 1;

        if (_view != null)
            Destroy(_view);

        _view = Instantiate(_zombiesViews[targetView]);
    }
}
