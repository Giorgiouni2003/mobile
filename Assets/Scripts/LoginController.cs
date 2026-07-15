using UnityEngine;
using UnityEngine.UI;

public class LoginController : MonoBehaviour
{
    public GameObject loginPanel;
    public GameObject mainPanel;
    public InputField usernameField;
    public InputField passwordField;
    public Text messageText;
    public Text welcomeText;

    private void Start()
    {
        if (AccountManager.IsLoggedIn) {
            ShowMainPanel();
        } else {
            ShowLoginPanel();
        }
    }

    public void Login()
    {
        if (AccountManager.Login(usernameField.text, passwordField.text, out string error)) {
            ShowMainPanel();
        } else {
            messageText.text = error;
        }
    }

    public void Register()
    {
        if (AccountManager.Register(usernameField.text, passwordField.text, out string error)) {
            ShowMainPanel();
        } else {
            messageText.text = error;
        }
    }

    public void Logout()
    {
        AccountManager.Logout();
        usernameField.text = "";
        passwordField.text = "";
        ShowLoginPanel();
    }

    private void ShowMainPanel()
    {
        loginPanel.SetActive(false);
        mainPanel.SetActive(true);
        welcomeText.text = "Ciao, " + AccountManager.CurrentUser + "!";
    }

    private void ShowLoginPanel()
    {
        loginPanel.SetActive(true);
        mainPanel.SetActive(false);
        messageText.text = "";
    }

}
