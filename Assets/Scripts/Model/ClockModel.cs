using System;
using System.Collections;
using Presenter;
using View;

namespace Model
{
    public abstract class ClockModel
    {
        protected ClockPresenter Presenter { get; private set; }
        public ClockView View { get; private set; }
        public DateTime DateTime { get; set; }

        protected ClockModel(ClockPresenter presenter, ClockView view)
        {
            Presenter = presenter;
            View = view;
        }
        public abstract IEnumerator DOGetUnixTimeNtp();
    }
}
