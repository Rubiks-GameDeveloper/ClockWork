using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeDataPresenter : ClockPresenter
{
    public override void FirstSync(DateTime dateTime)
    {
        GetView().SetTime(dateTime, 0.5f);
        StartCoroutine(ClockTicking(dateTime));
    }

    public override IEnumerator ClockTicking(DateTime dateTime)
    {
        yield return new WaitForSeconds(1);
        var time = dateTime.AddSeconds(1);
        GetModel().SetDateTime(time);
        GetView().SetTime(time, 0.1f);
        StartCoroutine(ClockTicking(time));
    }
}
