using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class ClockView
{
    private Transform _hourArrow;
    private Transform _minuteArrow;
    private ClockPresenter _presenter;

    public Transform GetHourArrow()
    {
        return _hourArrow;
    }
    public Transform GetMinuteArrow()
    {
        return _minuteArrow;
    }

    public ClockView(ClockPresenter presenter, Transform hourArrow, Transform minuteArrow)
    {
        _presenter = presenter;

        _hourArrow = hourArrow;
        _minuteArrow = minuteArrow;
    }

    public abstract void SetTime(DateTime time, float duration);
}
