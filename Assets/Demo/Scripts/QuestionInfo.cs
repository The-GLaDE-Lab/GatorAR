using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionInfo : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(DelayHide());
    }

    // Update is called once per frame
    void Update()
    {
        var cameraForward = Camera.current.transform.forward;
        var cameraBearing = new Vector3(cameraForward.x, 0, cameraForward.z).normalized;
        transform.rotation = Quaternion.LookRotation(cameraBearing);
    }

    void Hide()
    {
        gameObject.SetActive(false);
    }

    IEnumerator DelayHide()
    {
        yield return new WaitForSeconds(2f);
        Hide();
    }
}
