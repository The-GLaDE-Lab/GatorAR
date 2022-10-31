using System.Collections;
using UnityEngine;

public class RobotText : MonoBehaviour
{
    [SerializeField]
    GameObject FirstFloatingText;

    [SerializeField]
    GameObject SecondFloatingText;

    [SerializeField]
    GameObject ThirdFloatingText;

    [SerializeField]
    GameObject FourthFloatingText;

    [SerializeField]
    GameObject Book;

    void Awake()
    {
        FirstFloatingText.SetActive(false);
        SecondFloatingText.SetActive(false);
        ThirdFloatingText.SetActive(false);
        FourthFloatingText.SetActive(false);
        Book.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(InitializeText());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator InitializeText()
    {
        yield return new WaitForSeconds(3);

        FirstFloatingText.SetActive(true);

        yield return new WaitForSeconds(5);

        FirstFloatingText.SetActive(false);
        SecondFloatingText.SetActive(true);

        yield return new WaitForSeconds(6);

        SecondFloatingText.SetActive(false);
        ThirdFloatingText.SetActive(true);

        yield return new WaitForSeconds(4);
        
        ThirdFloatingText.SetActive(false);
        FourthFloatingText.SetActive(true);

        Book.SetActive(true);
    }
}
