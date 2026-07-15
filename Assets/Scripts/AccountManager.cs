using UnityEngine;

public static class AccountManager
{
    private const string UsersKey = "RegisteredUsers";
    private const string CurrentUserKey = "CurrentUser";

    public static string CurrentUser => PlayerPrefs.GetString(CurrentUserKey, "");
    public static bool IsLoggedIn => !string.IsNullOrEmpty(CurrentUser);

    public static bool Register(string username, string password, out string error)
    {
        username = username.Trim();

        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            error = "Inserisci username e password.";
            return false;
        }

        if (UserExists(username))
        {
            error = "Username gia' registrato.";
            return false;
        }

        string users = PlayerPrefs.GetString(UsersKey, "");
        users = string.IsNullOrEmpty(users) ? username : users + "," + username;
        PlayerPrefs.SetString(UsersKey, users);
        PlayerPrefs.SetString(PasswordKey(username), password);
        PlayerPrefs.SetString(CurrentUserKey, username);
        PlayerPrefs.Save();

        error = null;
        return true;
    }

    public static bool Login(string username, string password, out string error)
    {
        username = username.Trim();

        if (!UserExists(username))
        {
            error = "Utente non trovato.";
            return false;
        }

        if (PlayerPrefs.GetString(PasswordKey(username), "") != password)
        {
            error = "Password errata.";
            return false;
        }

        PlayerPrefs.SetString(CurrentUserKey, username);
        PlayerPrefs.Save();

        error = null;
        return true;
    }

    public static void Logout()
    {
        PlayerPrefs.DeleteKey(CurrentUserKey);
        PlayerPrefs.Save();
    }

    private static bool UserExists(string username)
    {
        string users = PlayerPrefs.GetString(UsersKey, "");
        if (string.IsNullOrEmpty(users)) return false;

        foreach (string user in users.Split(','))
        {
            if (user == username) return true;
        }

        return false;
    }

    private static string PasswordKey(string username) => "Password_" + username;

}
