using System;

[Serializable]
public class Identity
{
    string _username;
    string _password;

    public Identity(string username, string password)
    {
        _username = username;
        _password = password;
    }

    public string Username
    {
        get { return _username; }
    }

    public string Password
    {
        get { return _password; }
    }
}