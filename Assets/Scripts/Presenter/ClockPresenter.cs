using Model;
using UnityEngine;
using View;

namespace Presenter
{
    public abstract class ClockPresenter : MonoBehaviour
    {
        protected ClockView ClockView { get; private set; }
        protected ClockModel ClockModel { get; private set; }
        public void Init(ClockView view, ClockModel model)
        {
            ClockView = view;
            ClockModel = model;
        }
        public abstract void TimeSync();
    }
}
