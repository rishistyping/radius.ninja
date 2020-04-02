using System;

[Serializable]
public class Item
{
    string _value;
    string _text;
    string _text2;
    string _code;
    bool _isDefault;

    public Item(string value, string text, string text2, bool isDefault, string code = "")
    {
        _value = value;
        _text = text;
        _text2 = text2;
        _isDefault = isDefault;
        _code = code;
    }

    public string Text
    {
        get { return _text; }
    }

    public string Text2
    {
        get { return _text2; }
    }

    public string Value
    {
        get { return _value; }
    }

    public bool Default
    {
        get { return _isDefault; }
    }

    public string Code
    {
        get { return _code; }
    }
}