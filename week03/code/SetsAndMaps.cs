using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character
    /// words (lower case, no duplicates). Using sets, find an O(n)
    /// solution for returning all symmetric pairs of words.
    /// </summary>
    public static string[] FindPairs(string[] words)
    {
        // Store each two-character word as an integer.
        // This avoids creating a new string for every reverse lookup.
        var wordSet = new HashSet<int>();
        var pairs = new List<string>();

        foreach (var word in words)
        {
            int key = (word[0] << 16) | word[1];
            wordSet.Add(key);
        }

        foreach (var word in words)
        {
            // Ignore words such as "aa".
            if (word[0] == word[1])
            {
                continue;
            }

            // Only process the word whose first character is
            // greater than its second character. This ensures
            // each pair is returned only once and matches the
            // expected format, such as "ba & ab".
            if (word[0] > word[1])
            {
                int reverseKey = (word[1] << 16) | word[0];

                if (wordSet.Contains(reverseKey))
                {
                    pairs.Add($"{word} & {word[1]}{word[0]}");
                }
            }
        }

        return pairs.ToArray();
    }

    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.
    /// </summary>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();

        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");

            var degree = fields[3];

            if (degrees.ContainsKey(degree))
            {
                degrees[degree]++;
            }
            else
            {
                degrees.Add(degree, 1);
            }
        }

        return degrees;
    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        word1 = word1.Replace(" ", "").ToLower();
        word2 = word2.Replace(" ", "").ToLower();

        if (word1.Length != word2.Length)
        {
            return false;
        }

        var letterCounts = new Dictionary<char, int>();

        foreach (var letter in word1)
        {
            if (letterCounts.ContainsKey(letter))
            {
                letterCounts[letter]++;
            }
            else
            {
                letterCounts.Add(letter, 1);
            }
        }

        foreach (var letter in word2)
        {
            if (!letterCounts.ContainsKey(letter))
            {
                return false;
            }

            letterCounts[letter]--;

            if (letterCounts[letter] < 0)
            {
                return false;
            }
        }

        foreach (var count in letterCounts.Values)
        {
            if (count != 0)
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// This function will read JSON data from the United States Geological Service
    /// consisting of earthquake data for the current day.
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri =
            "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";

        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream =
            client.Send(getRequestMessage).Content.ReadAsStream();

        using var reader = new StreamReader(jsonStream);

        var json = reader.ReadToEnd();

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        var featureCollection =
            JsonSerializer.Deserialize<FeatureCollection>(json, options);

        var earthquakes = new List<string>();

        if (featureCollection?.Features != null)
        {
            foreach (var feature in featureCollection.Features)
            {
                earthquakes.Add(
                    $"{feature.Properties.Place} - Mag {feature.Properties.Mag}");
            }
        }

        return earthquakes.ToArray();
    }
}