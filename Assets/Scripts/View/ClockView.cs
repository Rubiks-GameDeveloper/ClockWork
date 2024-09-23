using System;
using Presenter;
using TMPro;
using UnityEngine;

namespace View
{
    public abstract class ClockView
    {
        protected Transform HourArrow { get; private set; }
        protected Transform MinuteArrow { get; private set; }
        protected TextMeshProUGUI DigitalClock { get; private set; }
        private ClockPresenter _presenter;

        protected ClockView(ClockPresenter presenter, Transform hourArrow, Transform minuteArrow, TextMeshProUGUI digitalClock)
        {
            _presenter = presenter;

            HourArrow = hourArrow;
            MinuteArrow = minuteArrow;
            DigitalClock = digitalClock;
        }

        public abstract void SetTime(DateTime time, float duration);
    }
}
