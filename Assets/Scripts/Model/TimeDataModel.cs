using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

public class TimeDataModel : ClockModel
{
    public override IEnumerator GetUnixTimeNTP()
    {
        using (var client = UnityWebRequest.Get(new Uri("http://clockWork/getTime.php", UriKind.RelativeOrAbsolute)))
        {
            yield return client.SendWebRequest();
            try
            {
                var response = client.downloadHandler.text;
                var unixTime = DateTime.UnixEpoch;
                unixTime += TimeSpan.FromMilliseconds(double.Parse(response));
                
                SetDateTime(unixTime);
                dataSync.Invoke(unixTime);

                Debug.Log("Current time in milliseconds since Unix Epoch: " + unixTime);
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
