using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

using NativeWebSocket;

public class ServerTimeCollector : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        //text.text = GetNetworkTime().ToString();
        StartCoroutine(GetUnixTime());
    }
   

    public IEnumerator GetUnixTime()
    {
        using (UnityWebRequest client = UnityWebRequest.Get(new Uri("http://clockWork/getTime.php", UriKind.RelativeOrAbsolute)))
        {
            yield return client.SendWebRequest();
            try
            {
                var response = client.downloadHandler.text;
                var unixTime = response;

                text.text = unixTime;
                Debug.Log("Current time in milliseconds since Unix Epoch: " + unixTime);
            }
            catch (Exception ex)
            {
                Debug.LogError($"Error getting current time from NTP server: {ex.Message}");
            }
        }

        yield return null;
    }
}
