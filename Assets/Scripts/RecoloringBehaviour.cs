using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using Random = UnityEngine.Random;


public class RecoloringBehaviour : MonoBehaviour
{
    private float _recoloringDuration = 2f;
    private Color _startColor;
    private Color _nextColor;
    private Renderer _renderer;
   // [SerializeField] private float _recoloringTime;
    [SerializeField] private float _sleepTime;
    private float _sleepTimeProgress;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        GenerateNextColor();
    }

    private void GenerateNextColor()
    {
        var color = Random.ColorHSV(0f, 1f, 0.8f, 1f, 1f, 1f);
        GetComponent<Renderer>().material.color = color;
        _startColor = _renderer.material.color;
        _nextColor = Random.ColorHSV(0f, 1f, 0.8f, 1f, 1f, 1f);
    }

    private void Update()
    {
        //var progress = _recoloringTime / _recoloringDuration;
        //var currentColor = Color.Lerp(_startColor, _nextColor, progress);
     
        if (_sleepTimeProgress < _sleepTime)
        {
            _sleepTimeProgress += Time.deltaTime;
          
            if (_sleepTimeProgress >= _sleepTime)
            {
                _sleepTimeProgress = 0f;
                GenerateNextColor();
            }
        }
    }
}