public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        DateTime currentTime = DateTime.Now;
        newEntry._date = currentTime.ToShortDateString();

        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string file)
    {
        using (StreamWriter outputFile = new StreamWriter(file))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.Write($"{entry._date}|{entry._promptText}|{entry._entryText}\n");
            }
        }
    }

    public void LoadFromFile(string file)
    {
        string[] lines = File.ReadAllLines(file);
        _entries = new List<Entry>();

        foreach (string line in lines)
        {
            string[] parts = line.Split("|");

            Entry entry = new Entry();

            entry._date = parts[0];
            entry._promptText = parts[1];
            entry._entryText = parts[2];

            AddEntry(entry);
        }
    }

    public void SearchEntries(string keyword)
    {
        foreach (Entry entry in _entries)
        {
            string entryData = entry._date.ToLower() + entry._promptText.ToLower() + entry._entryText.ToLower();

            if (entryData.Contains(keyword.ToLower()))
            {
                entry.Display();
            }
        }
    }
}
