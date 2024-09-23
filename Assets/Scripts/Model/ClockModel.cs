using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class ClockModel
{
    public delegate void DataSync(DateTime dateTime);

    public DataSync dataSync;
    private ClockPresenter _presenter;
    private ClockView _view;
    private DateTime _dateTime;

    public ClockView GetView() => _view;
    public ClockPresenter GetPresenter() => _presenter;
    public void SetDateTime(DateTime dateTime) => _dateTime = dateTime;
    public DateTime GetDateTime() => _dateTime;
    public ClockModel(ClockPresenter presenter, ClockView view)
    {
        _presenter = presenter;
        _view = view;
        dataSync = presenter.FirstSync;
    }

    public abstract IEnumerator GetUnixTimeNTP();
}
