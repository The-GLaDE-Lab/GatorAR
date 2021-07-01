using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Net;
using System.IO;
using Assets;
using UnityEngine.Networking;
using UnityEngine.UI;

public class WeatherController : MonoBehaviour
{
    private const string API_KEY = "be0480d222310895818eb762d7cea92b";
    private const float API_CHECK_MAXTIME = 10 * 60.0f;
    private float apiCheckCountdown = API_CHECK_MAXTIME;
    private SimpleHelvetica SimpleHelveticaScript;
    public string CityID;
    //public TextMesh TextField;
    public GameObject New3DText;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetWeather(CheckWeatherStatus));
        SimpleHelveticaScript = New3DText.GetComponent<SimpleHelvetica>();
        //SimpleHelveticaScript.Text = "Test";
    }

    // Update is called once per frame
    void Update()
    {
        apiCheckCountdown -= Time.deltaTime;
        if (apiCheckCountdown <= 0)
        {
            apiCheckCountdown = API_CHECK_MAXTIME;
            StartCoroutine(GetWeather(CheckWeatherStatus));
        }
    }

    public void CheckWeatherStatus(WeatherInfo weatherObj)
    {
        //foreach (var item in weatherObj.weather)
        //{
        //    TextField.text += item.ToString();
        //}

        //TextField.text += weatherObj.weather[0].id.ToString() + "\n";
        //TextField.text += weatherObj.weather[0].main.ToString() + "\n";
        //TextField.text += weatherObj.weather[0].description.ToString() + "\n";

        SimpleHelveticaScript.Text = weatherObj.weather[0].id.ToString() + "\n";
        SimpleHelveticaScript.Text += weatherObj.weather[0].main.ToString() + "\n";
        SimpleHelveticaScript.Text += weatherObj.weather[0].description.ToString() + "\n";
        SimpleHelveticaScript.GenerateText();
    }

    IEnumerator GetWeather(Action<WeatherInfo> onSuccess)
    {
        using (UnityWebRequest req = UnityWebRequest.Get(String.Format("http://api.openweathermap.org/data/2.5/weather?id={0}&appid={1}", CityID, API_KEY)))
        {
            yield return req.SendWebRequest();
            while (!req.isDone)
            {
                yield return null;
            }
            byte[] result = req.downloadHandler.data;
            string weatherJSON = System.Text.Encoding.Default.GetString(result);
            WeatherInfo info = JsonUtility.FromJson<WeatherInfo>(weatherJSON);
            onSuccess(info);
        }
    }

}
