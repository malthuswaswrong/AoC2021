using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2021;

public class SyntaxChecker : ChallengeBase {
    private readonly ChallengeInput input;
    private readonly Part part;
    private Dictionary<char, int> scoringTablePart1;
    private Dictionary<char, int> scoringTablePart2;
    private readonly string openingCharacters;
    private readonly string closingCharacters;

    public SyntaxChecker(ChallengeInput input, Part part) : base(input, part) {
        this.input = input;
        this.part = part;
        openingCharacters = "([{<";
        closingCharacters = ")]}>";
        scoringTablePart1 = new() {
            { ')', 3 }, { ']', 57 }, { '}', 1197 }, { '>', 25137 }
        };
        scoringTablePart2 = new() {
            { '(', 1 }, { '[', 2 }, { '{', 3 }, { '<', 4 }
        };
    }

    public override long Answer {
        get {
            long part1Score = 0;
            List<long> part2AnswerSet = new ();
            foreach (var line in input.Inputs) {
                List<char> syntaxStack = new();
                bool lineWasValid = true;
                foreach (char c in line) {
                    if (openingCharacters.Contains(c)) syntaxStack.Add(c);
                    else {
                        if (closingCharacters.Contains(c))
                            if (syntaxStack.Last() == openingCharacters[closingCharacters.IndexOf(c)])
                                syntaxStack.RemoveAt(syntaxStack.Count - 1);
                            else {
                                part1Score += scoringTablePart1[c];
                                lineWasValid = false;
                                break;
                            }
                    }
                }

                if (part == Part.TWO && lineWasValid) {
                    long lineAnswer = 0;
                    for (int i = syntaxStack.Count - 1; i >= 0; i--)
                        lineAnswer = (lineAnswer * 5) + scoringTablePart2[syntaxStack[i]];

                    part2AnswerSet.Add(lineAnswer);
                }
            }

            return (part == Part.ONE) ? part1Score : part2AnswerSet.OrderBy(x => x).ToArray()[(int)Math.Floor(part2AnswerSet.Count() / 2d)];
        }
    }
}

