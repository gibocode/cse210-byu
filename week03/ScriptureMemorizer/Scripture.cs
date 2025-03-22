using System;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words = new List<Word>();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;

        string[] words = text.Split(' ');

        foreach (string word in words)
        {
            _words.Add(new Word(word));
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        Random random = new Random();
        int wordsVisible = CountVisibleWords();

        if (numberToHide > wordsVisible)
        {
            numberToHide = wordsVisible;
        }

        for (int i = 0; i < numberToHide; i++)
        {
            int index = random.Next(0, _words.Count);
            Word word = _words[index];

            while (word.IsHidden())
            {
                index = random.Next(0, _words.Count);
                word = _words[index];
            }

            word.Hide();
        }
    }

    public string GetDisplayText()
    {
        string displayText = _reference.GetDisplayText() + " - ";

        foreach (Word word in _words)
        {
            displayText += word.GetDisplayText() + " ";
        }

        return displayText.Trim();
    }

    public bool IsCompletelyHidden()
    {
        bool completelyHidden = true;

        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                completelyHidden = false;
                break;
            }
        }

        return completelyHidden;
    }

    /**
     * Counts the number of words that are not hidden.
     * This method is used to determine the number of words that can be hidden.
     */
    private int CountVisibleWords()
    {
        int count = 0;

        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                count++;
            }
        }

        return count;
    }
}
