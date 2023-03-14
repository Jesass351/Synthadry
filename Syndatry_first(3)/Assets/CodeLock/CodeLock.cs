using UnityEngine.UI;
using TMPro;
using UnityEngine;
using Unity.VisualScripting;

public class CodeLock : MonoBehaviour
{
    [Header("General")]
    public bool unlock;
    public TMP_InputField _InputField;
    public string password = "1234";
    public GameObject[] objectsOn;
    public GameObject[] objectsOff;
    [Header("Messages")]
    public string error = "ERROR";
    public Color errorColor = Color.red;
    public string success = "PASSWORD ACCEPTED";
    public Color successColor = Color.green;
    public string defaultText = "ENTER PASSWORD";
    public Color defaultColor = Color.black;
    [Header("Buttons")]
    public float offset = 10;
    public RectTransform button;
    public RectTransform panel;
    public bool buildButtons;
    public RectTransform[] allButtons;

    void Start()
    {
        unlock = false;
        _InputField.interactable = false;
        _InputField.characterLimit = password.Length;
        ResetPass();
        if (buildButtons)
            BuildGrid();
        else
            SetButton();
    }


    void SetButton()
    {
        int i = 1;
        for (int j = 0; j < allButtons.Length; j++)
        {
            switch(i)
            {
                case 10:
                    allButtons[j].GetComponentInChildren<TextMeshProUGUI>().text = "R";
                    allButtons[j].GetComponent<Button>().onClick.AddListener(() => { ResetPass(); });
                    break;
                case 11:
                    allButtons[j].GetComponentInChildren<TextMeshProUGUI>().text = "0";
                    allButtons[j].GetComponent<Button>().onClick.AddListener(() => { AddKeyPass("0"); });
                    break;
                case 12:
                    allButtons[j].GetComponentInChildren<TextMeshProUGUI>().text = "E";
                    allButtons[j].GetComponent<Button>().onClick.AddListener(() => { EnterPass(); });
                    break;
                default:
                    string number = i.ToString();
                    allButtons[j].GetComponentInChildren<TextMeshProUGUI>().text = number;
                    allButtons[j].GetComponent<Button>().onClick.AddListener(() => { AddKeyPass(number); });
                    break;
            }
            i++;
        }
    }

    
    void BuildGrid()
    {
        float sizeX = button.sizeDelta.x + offset;
        float sizeY = button.sizeDelta.y + offset;
        float posX = -sizeX * 3 / 2 - sizeX / 2;
        float posY = Mathf.Abs(posX) - sizeY / 2;
        float Xreset = posX;
        int i = 0;
        allButtons = new RectTransform[12];
        for (int y = 0; y < 4; y++)
        {
            posY -= sizeY;
            for (int x = 0; x < 3; x++)
            {
                posX += sizeX;
                allButtons[i] = Instantiate(button);
                allButtons[i].SetParent(panel);
                allButtons[i].anchoredPosition = new Vector2(posX, posY);
                allButtons[i].gameObject.name = "Button_ID_" + i;
                i++;
            }
            posX = Xreset;
        }
        SetButton();
        button.gameObject.SetActive(false);
    }


    public void AddKeyPass(string key)
    {
        if (_InputField.text.Length < password.Length)
        {
            _InputField.text += key;
        }
    }


    void ClearText()
    {
        _InputField.text = string.Empty;
    }


    public void EnterPass()
    {
        if (_InputField.text == password)
        {
            foreach(GameObject obj in objectsOn)
            {
                obj.SetActive(true);
            }

            foreach(GameObject obj in objectsOff)
            {
                obj.SetActive(false);
            }

            foreach(RectTransform tr in allButtons)
            {
                tr.GetComponent<Button>().interactable = false;
            }
            unlock = true;
            ClearText();
            _InputField.placeholder.GetComponent<TextMeshProUGUI>().text = success;
            _InputField.placeholder.GetComponent<TextMeshProUGUI>().color = successColor;
        }
        else
        {
            ClearText();
            _InputField.placeholder.GetComponent<TextMeshProUGUI>().text = error;
            _InputField.placeholder.GetComponent<TextMeshProUGUI>().color = errorColor;
        }
    }


    public void ResetPass()
    {
        ClearText();
        _InputField.placeholder.GetComponent<TextMeshProUGUI>().text = defaultText;
        _InputField.placeholder.GetComponent<TextMeshProUGUI>().color = defaultColor;
    }

    public void ClosePanel()
    {
        GameObject.Find("Panel").gameObject.SetActive(false);
    }
}
