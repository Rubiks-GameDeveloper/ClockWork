using System;
using DG.Tweening;
using Presenter;
using TMPro;
using UnityEngine;

namespace View
{
    public class TimeClockView : ClockView
    {
        public TimeClockView(ClockPresenter presenter, Transform hourArrow, Transform minuteArrow, TextMeshProUGUI digitalClock) : base(presenter, hourArrow, minuteArrow, digitalClock){}
        public override void SetTime(DateTime time, float duration)
        {
            HourArrow.DORotate(new Vector3(0, 0, -time.Hour % 12 * 30 - time.Minute * 0.5f), duration);
            MinuteArrow.DORotate(new Vector3(0, 0, -time.Minute * 6 - time.Second * 0.1f), duration);
            DigitalClock.text = time.ToLongTimeString();
        }
    }
}
