using Model;
using Presenter;
using TMPro;
using UnityEngine;
using View;

public class InitializeScene : MonoBehaviour
{
    [SerializeField] private Transform hourArrow;
    [SerializeField] private Transform minuteArrow;
    [SerializeField] private TextMeshProUGUI digitalClock;

    private void Start()
    {
        var presenter = FindObjectOfType<ClockPresenter>();
        var view = new TimeClockView(presenter, hourArrow, minuteArrow, digitalClock);
        var model = new TimeDataModel(presenter, view);
        presenter.Init(view, model);
        StartCoroutine(model.DOGetUnixTimeNtp());
    }
}
