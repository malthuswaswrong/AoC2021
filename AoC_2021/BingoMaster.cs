using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2021;
public class BingoMaster : ChallengeBase
{
    private readonly ChallengeInput input;
    private readonly Part part;

    public BingoMaster(ChallengeInput input, Part part) : base(input, part)
    {
        this.input = input;
        this.part = part;
    }
    public override int Answer
    {
        get
        {
            BingoBoard? firstBoard = null, lastBoard = null;
            List<int> ballSet = new List<int>();
            foreach (var ball in input.Inputs[0].Split(","))
                ballSet.Add(int.Parse(ball));

            for (int inputIdx = 2; inputIdx < input.Inputs.Count(); inputIdx += 6) //There is a blank line after each board
            {
                List<string> tboardRaw = new List<string> {
                    input.Inputs[inputIdx],
                    input.Inputs[inputIdx + 1],
                    input.Inputs[inputIdx + 2],
                    input.Inputs[inputIdx + 3],
                    input.Inputs[inputIdx + 4]
                };
                var newBoard = new BingoBoard(tboardRaw, ballSet.ToArray());

                if (!newBoard.IsWinner) continue;
                if (firstBoard is null) firstBoard = newBoard;
                if (lastBoard is null) lastBoard = newBoard;
                if (newBoard.TurnWin < firstBoard.TurnWin) firstBoard = newBoard;
                if (newBoard.TurnWin > lastBoard.TurnWin) lastBoard = newBoard;
            }

            return (part == Part.ONE) ? firstBoard.Score.Value : lastBoard.Score.Value;
        }
    }
    public class BingoBoard
    {
        private int[] ballSet;
        private List<BingoCell> board;
        private int rowCnt;
        public BingoBoard(List<string> boardRaw, int[] ballSet)
        {
            this.ballSet = ballSet;
            rowCnt = boardRaw.Count();
            board = new();
            int rowIdx = 0;
            foreach (string rowRaw in boardRaw)
            {
                var t = rowRaw.Split(" ");
                int colIdx = 0;
                foreach (var cell in t)
                {
                    if (!String.IsNullOrEmpty(cell))
                    {
                        board.Add(new BingoCell(rowIdx, colIdx, int.Parse(cell)));
                        colIdx++;
                    }
                }
                rowIdx++;
            }
            for (int turn = 0; turn < ballSet.Length; turn++)
            {
                board.Where(x => x.Number == ballSet[turn]).ToList()
                    .ForEach(cellToMark => cellToMark.Marked = true);

                if (IsWinner)
                {
                    turnWin = turn;
                    winningNumber = ballSet[turn];
                    score = board.Where(cell => !cell.Marked).Sum(cell => cell.Number) * winningNumber;
                    break;
                }
            }
        }

        public bool IsWinner
        {
            get
            {
                for (int xY = 0; xY < rowCnt; xY++)
                {
                    if (board.Where(x => x.X == xY && x.Marked).Count() == rowCnt) return true;
                    if (board.Where(y => y.Y == xY && y.Marked).Count() == rowCnt) return true;
                }
                return false;
            }
        }
        private int? turnWin = null;
        public int? TurnWin => turnWin;

        private int? score = null;
        public int? Score => score;

        private int? winningNumber = null;
        public int? WinningNumber => winningNumber;

        internal class BingoCell
        {
            internal int X { get; set; }
            internal int Y { get; set; }
            internal int Number { get; set; }
            internal bool Marked { get; set; }

            public BingoCell(int X, int Y, int Number)
            {
                this.X = X;
                this.Y = Y;
                this.Number = Number;
                Marked = false;
            }
        }
    }
}
