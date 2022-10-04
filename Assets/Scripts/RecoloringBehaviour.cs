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
    [SerializeField] private float _recoloringTime;
    [SerializeField] private float _sleepTime;
    private float _sleepTimeProgress;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        GenerateNextColor();
    }

    private void GenerateNextColor()
    {
        // Задаю рандомное значение цвета  _startColor 
        _startColor = Random.ColorHSV(0f, 1f, 0.7f, 1f, 1f, 1f);
        //присваиваю цвет _startColor материалу кубика
        GetComponent<Renderer>().material.color = _startColor;
    }

    private void Update()
    {
        //_sleepTimeProgress-счетчик для задержки смены цвета
        //если счетчик для задержки смены цвета меньше чем значение задержки
        if (_sleepTimeProgress < _sleepTime)
        {
            _sleepTimeProgress += Time.deltaTime; //тогда добавляю время в счетчик
            return;
        }


        if (_recoloringTime < _recoloringDuration) //если время для смены цвета не вышло
        {
            //интерполирую цвет
            _recoloringTime += Time.deltaTime;//накапливаю время для смены цвета
            var progress = _recoloringTime / _recoloringDuration; // делю счетчик времени для смены цвета кубика на продолжительсть смены цвета
            var currentColor = Color.Lerp(_startColor, _nextColor, progress); //получаю текущий цвет
            //записываю текущий цвет в следущий цвет
            _nextColor = currentColor;
        }
        else
        {
            _recoloringTime = 0f; //иначе меняю цвет и сбрасываю счетчик в ноль.
            _sleepTimeProgress = 0f;
            GenerateNextColor();
        }
    }
}
