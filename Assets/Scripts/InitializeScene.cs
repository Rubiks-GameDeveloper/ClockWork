using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeScene : MonoBehaviour
{
    [SerializeField] private Transform hourArrow;
    [SerializeField] private Transform minuteArrow;

    // Start is called before the first frame update
    private void Start()
    {
        var presenter = FindObjectOfType<ClockPresenter>();
        var view = new TimeClockView(presenter, hourArrow, minuteArrow);
        var model = new TimeDataModel(presenter, view);
        presenter.Init(view, model);
        StartCoroutine(model.GetUnixTimeNTP());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
