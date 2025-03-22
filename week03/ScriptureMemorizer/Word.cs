using System;

public class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    private void Show()
    {
        _isHidden = false;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public string GetDisplayText()
    {
        string text = "";
        string[] punctuation = { ".", ",", ";", ":", "!", "?" };

        if (_isHidden)
        {
            foreach (char letter in _text)
            {
                // Does not replace punctuation with underscores.
                if (Array.IndexOf(punctuation, letter.ToString()) > -1)
                {
                    text += letter;
                }
                else
                {
                    text += "_";
                }
            }
        }
        else
        {
            text = _text;
        }

        return text;
    }
}
