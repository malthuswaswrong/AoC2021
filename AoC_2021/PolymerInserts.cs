using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2021;
public class PolymerInserts : ChallengeBase {
    private readonly Part part;
    string template;
    List<(string match, char insert)> rules;
    public PolymerInserts(ChallengeInput input, Part part) : base(input, part) {
        this.part = part;
        template = input.Inputs[0];
        rules = new();
        for (int i = 2; i < input.Inputs.Count; i++) {
            rules.Add((input.Inputs[i].Substring(0, 2), input.Inputs[i][6]));
        }
    }
    public override long Answer {
        get {
            int loopLimit = (part == Part.ONE) ? 10 : 40;
            Dictionary<string, long> accumulatedPairs = new();
            Dictionary<char, long> charCounts = new();
            for (int i = 0; i < template.Length; i++) {
                if (!charCounts.ContainsKey(template[i])) charCounts.Add(template[i], 0);
                charCounts[template[i]]++;
            }
            for (int i = 0; i < template.Length - 1; i++) {
                string pair = template.Substring(i, 2);
                if (!accumulatedPairs.ContainsKey(pair)) accumulatedPairs.Add(pair, 0);
                accumulatedPairs[pair]++;
            }
            for (int i = 0; i < loopLimit; i++) {
                Dictionary<string, long> newPairs = new();
                foreach (string key in accumulatedPairs.Keys) {
                    var insert = rules.Where(x => x.match == key).Select(y => y.insert).FirstOrDefault();
                    if (!charCounts.ContainsKey(insert)) charCounts.Add(insert, 0);
                    charCounts[insert] += accumulatedPairs[key];
                    string newKey1 = $"{key[0]}{insert}";
                    string newKey2 = $"{insert}{key[1]}";
                    if (!newPairs.ContainsKey(newKey1)) newPairs.Add(newKey1, 0);
                    if (!newPairs.ContainsKey(newKey2)) newPairs.Add(newKey2, 0);
                    newPairs[newKey1] += accumulatedPairs[key];
                    newPairs[newKey2] += accumulatedPairs[key];
                }
                accumulatedPairs = newPairs;
            }

            var min = charCounts.Min(x => x.Value);
            var max = charCounts.Max(x => x.Value);
            return max - min;
        }
    }
    //public long AnswerSlow {
    //    get {
    //        int loopLimit = (part == Part.ONE) ? 10 : 40;

    //        string currentPattern = template;
    //        Dictionary<int, string?> insertLookup;
    //        for (int i = 0; i < loopLimit; i++) {
    //            insertLookup = new();
    //            for (int j = 0; j < currentPattern.Length - 1; j++) {
    //                string search = currentPattern.Substring(j, 2);
    //                insertLookup.Add(j, rules.Where(x => x.match == search).Select(y => y.insert).FirstOrDefault());
    //            }
    //            StringBuilder nextPattern = new();
    //            for (int j = 0; j < currentPattern.Length; j++) {
    //                nextPattern.Append(currentPattern[j]);
    //                if (insertLookup.ContainsKey(j) && insertLookup[j] != null) {
    //                    nextPattern.Append(insertLookup[j]);
    //                }
    //            }
    //            currentPattern = nextPattern.ToString();
    //        }
    //        Dictionary<char, int> cnt = new();
    //        for (int i = 0; i < currentPattern.Length; i++) {
    //            if (!cnt.ContainsKey(currentPattern[i])) cnt.Add(currentPattern[i], 0);
    //            cnt[currentPattern[i]]++;
    //        }
    //        var min = cnt.Min(x => x.Value);
    //        var max = cnt.Max(x => x.Value);
    //        return max - min;
    //    }

    //}
}
