using System;
using System.Collections;
using UnityEngine;

public abstract class ClockPresenter : MonoBehaviour
{
    private ClockView _clockView;
    private ClockModel _clockModel;
    
    public void SetView(ClockView clockView) => _clockView = clockView;
    public ClockView GetView() => _clockView;
    
    public void SetModel(ClockModel clockModel) => _clockModel = clockModel;
    public ClockModel GetModel() => _clockModel;
    public void Init(ClockView view, ClockModel model)
    {
        _clockView = view;
        _clockModel = model;
    }

    public abstract void FirstSync(DateTime dateTime);
    public abstract IEnumerator ClockTicking(DateTime dateTime);
}
