using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

namespace Presenter
{
    public class TimeDataPresenter : ClockPresenter
    {
        private DateTime _startTime;

        private IEnumerator ClockTicking(DateTime dateTime)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            yield return new WaitForSeconds(1);
            var time = dateTime.AddSeconds(1);

            if (time.Hour > _startTime.Hour)
            {
                StartCoroutine(ClockModel.DOGetUnixTimeNtp());
                _startTime = time;
            }

            ClockModel.DateTime = time + stopWatch.Elapsed.Add(new TimeSpan(0, 0, -1));
        
            ClockView.SetTime(time  + stopWatch.Elapsed.Add(new TimeSpan(0, 0, -1)), 0.1f);

            StartCoroutine(ClockTicking(time + stopWatch.Elapsed.Add(new TimeSpan(0, 0, -1))));
            ClockModel.DateTime += stopWatch.Elapsed.Add(new TimeSpan(0, 0, -1));
        
            stopWatch.Stop();
        }

        public override void TimeSync()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            StopAllCoroutines();
            StartCoroutine(ClockTicking(ClockModel.DateTime + stopWatch.Elapsed));
            ClockView.SetTime(ClockModel.DateTime + stopWatch.Elapsed, 0.1f);
        
            ClockModel.DateTime += stopWatch.Elapsed;
            stopWatch.Stop();
        }
    }
}
