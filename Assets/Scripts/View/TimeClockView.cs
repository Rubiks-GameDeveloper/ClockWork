using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class TimeClockView : ClockView
{
    public TimeClockView(ClockPresenter presenter, Transform hourArrow, Transform minuteArrow) : base(presenter, hourArrow, minuteArrow){}


    public override void SetTime(DateTime time, float duration)
    {
        GetHourArrow().DORotate(new Vector3(0, 0, -time.Hour % 12 * 30 - time.Minute * 0.5f), duration);
        GetMinuteArrow().DORotate(new Vector3(0, 0, -time.Minute * 6 - time.Second * 0.1f), duration);
    }
}
