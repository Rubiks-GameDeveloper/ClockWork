using System;
using System.Collections;
using Presenter;
using UnityEngine.Networking;
using View;
using Debug = UnityEngine.Debug;

namespace Model
{
    public class TimeDataModel : ClockModel
    {
        public override IEnumerator DOGetUnixTimeNtp()
        {
            using (var client = UnityWebRequest.Get(new Uri("http://localhost/getTime.php", UriKind.RelativeOrAbsolute)))
            {
                yield return client.SendWebRequest();
                try
                {
                    var response = client.downloadHandler.text;
                    var unixTime = DateTime.UnixEpoch;
                    unixTime += TimeSpan.FromMilliseconds(double.Parse(response));
                
                    DateTime = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(unixTime, TimeZoneInfo.Local.Id);;
                
                    client.Dispose();
                    Presenter.TimeSync();
                }
                catch (Exception ex)
                {
                    Debug.LogError($"Error getting current time from NTP server: {ex.Message}");
                }
            }
        }

        public TimeDataModel(ClockPresenter presenter, ClockView view) : base(presenter, view)
        {
        }
    }
}
