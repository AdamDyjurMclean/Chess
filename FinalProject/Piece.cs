using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public abstract class Piece
    {
        public string location { get; set; }
        public string image;
        public bool moved = false;
        public virtual List<string> Moves(List<Piece> player1Pieces, List<Piece> player2Pieces)
        {
            List<string> data = new List<string>();
            return data;
        }
    }
    public class Castle : Piece
    {
        public Castle(string l, string i)
        {
            location = l;
            image = i;
        }
        public override List<string> Moves(List<Piece> player1Pieces, List<Piece> player2Pieces)
        {
            List<string> moves = new List<string>();
            moves = Move.UpDown(moves, true, player1Pieces, player2Pieces, location);
            moves = Move.UpDown(moves, false, player1Pieces, player2Pieces, location);
            moves = Move.LeftRight(moves, true, player1Pieces, player2Pieces, location);
            moves = Move.LeftRight(moves, false, player1Pieces, player2Pieces, location);
            return moves;
        }
    }
    public class Horse : Piece
    {
        public Horse(string l, string i)
        {
            location = l;
            image = i;
        }
        public override List<string> Moves(List<Piece> player1Pieces, List<Piece> player2Pieces)
        {
            List<string> moves = new List<string>();
            moves.Add("g" + (int.Parse(location[1].ToString()) + 2).ToString() + (int.Parse(location[2].ToString()) + 1).ToString());
            moves.Add("g" + (int.Parse(location[1].ToString()) + 2).ToString() + (int.Parse(location[2].ToString()) - 1).ToString());
            moves.Add("g" + (int.Parse(location[1].ToString()) - 2).ToString() + (int.Parse(location[2].ToString()) + 1).ToString());
            moves.Add("g" + (int.Parse(location[1].ToString()) - 2).ToString() + (int.Parse(location[2].ToString()) - 1).ToString());
            moves.Add("g" + (int.Parse(location[1].ToString()) + 1).ToString() + (int.Parse(location[2].ToString()) + 2).ToString());
            moves.Add("g" + (int.Parse(location[1].ToString()) + 1).ToString() + (int.Parse(location[2].ToString()) - 2).ToString());
            moves.Add("g" + (int.Parse(location[1].ToString()) - 1).ToString() + (int.Parse(location[2].ToString()) + 2).ToString());
            moves.Add("g" + (int.Parse(location[1].ToString()) - 1).ToString() + (int.Parse(location[2].ToString()) - 2).ToString());
            return moves;
        }
    }
    public class Bishop : Piece
    {
        public Bishop(string l, string i)
        {
            location = l;
            image = i;
        }
        public override List<string> Moves(List<Piece> player1Pieces, List<Piece> player2Pieces)
        {
            List<string> moves = new List<string>();
            moves = Move.TopLeftBottomRight(moves, true, player1Pieces, player2Pieces, location);
            moves = Move.TopLeftBottomRight(moves, false, player1Pieces, player2Pieces, location);
            moves = Move.TopRightBottomLeft(moves, true, player1Pieces, player2Pieces, location);
            moves = Move.TopRightBottomLeft(moves, false, player1Pieces, player2Pieces, location);
            return moves;
        }
    }
    public class Queen : Piece
    {
        public Queen(string l, string i)
        {
            location = l;
            image = i;
        }
        public override List<string> Moves(List<Piece> player1Pieces, List<Piece> player2Pieces)
        {
            List<string> moves = new List<string>();
            moves = Move.UpDown(moves, true, player1Pieces, player2Pieces, location);
            moves = Move.UpDown(moves, false, player1Pieces, player2Pieces, location);
            moves = Move.LeftRight(moves, true, player1Pieces, player2Pieces, location);
            moves = Move.LeftRight(moves, false, player1Pieces, player2Pieces, location);
            moves = Move.TopLeftBottomRight(moves, true, player1Pieces, player2Pieces, location);
            moves = Move.TopLeftBottomRight(moves, false, player1Pieces, player2Pieces, location);
            moves = Move.TopRightBottomLeft(moves, true, player1Pieces, player2Pieces, location);
            moves = Move.TopRightBottomLeft(moves, false, player1Pieces, player2Pieces, location);
            return moves;
        }
    }
    public class King : Piece
    {
        public King(string l, string i)
        {
            location = l;
            image = i;
        }
        public override List<string> Moves(List<Piece> player1Pieces, List<Piece> player2Pieces)
        {
            List<string> moves = new List<string>();
            moves.Add("g" + (int.Parse(location[1].ToString()) + 1).ToString() + location[2]);
            moves.Add("g" + (int.Parse(location[1].ToString()) - 1).ToString() + location[2]);
            moves.Add("g" + location[1] + (int.Parse(location[2].ToString()) + 1).ToString());
            moves.Add("g" + location[1] + (int.Parse(location[2].ToString()) - 1).ToString());
            moves.Add("g" + (int.Parse(location[1].ToString()) + 1).ToString() + (int.Parse(location[2].ToString()) + 1).ToString());
            moves.Add("g" + (int.Parse(location[1].ToString()) + 1).ToString() + (int.Parse(location[2].ToString()) - 1).ToString());
            moves.Add("g" + (int.Parse(location[1].ToString()) - 1).ToString() + (int.Parse(location[2].ToString()) + 1).ToString());
            moves.Add("g" + (int.Parse(location[1].ToString()) - 1).ToString() + (int.Parse(location[2].ToString()) - 1).ToString());
            if(moved == false)
            {
                if (image[0] == 'W')
                {
                    if (Move.CastlingP1Left(player1Pieces, player2Pieces) == true)
                        moves.Add("g83");
                    if (Move.CastlingP1Right(player1Pieces, player2Pieces) == true)
                        moves.Add("g87");
                }
                else
                {
                    if (Move.CastlingP2Left(player1Pieces, player2Pieces) == true)
                        moves.Add("g13");
                    if (Move.CastlingP2Right(player1Pieces, player2Pieces) == true)
                        moves.Add("g17");
                }
            }
            for(int i = moves.Count - 1; i >= 0; i--)
            {
                if (moves[i].Contains("0") | moves[i].Contains("9"))
                    moves.RemoveAt(i);
            }
            return moves;
        }
    }
    public class Pawn : Piece
    {
        public Pawn(string l, string i)
        {
            location = l;
            image = i;
        }
        public override List<string> Moves(List<Piece> player1Pieces, List<Piece> player2Pieces)
        {
            bool blocked = false;
            List<string> moves = new List<string>();
            if(image[0] == 'W')
            {
                foreach(Piece p in player1Pieces)
                {
                    if (p.location[1].ToString() == (Int32.Parse(location[1].ToString()) - 1).ToString() & p.location[2] == location[2])
                    {
                        blocked = true;
                    }
                }
                foreach (Piece p in player2Pieces)
                {
                    if (p.location[1].ToString() == (Int32.Parse(location[1].ToString()) - 1).ToString() & p.location[2] == location[2])
                    {
                        blocked = true;
                    }
                }
                if (blocked == false)
                    moves.Add("g" + (Int32.Parse(location[1].ToString()) - 1).ToString() + location[2]);
                if(blocked == false & moved == false)
                {
                    foreach (Piece p in player1Pieces)
                    {
                        if (p.location[1].ToString() == (Int32.Parse(location[1].ToString()) - 2).ToString() & p.location[2] == location[2])
                        {
                            blocked = true;
                        }
                    }
                    foreach (Piece p in player2Pieces)
                    {
                        if (p.location[1].ToString() == (Int32.Parse(location[1].ToString()) - 2).ToString() & p.location[2] == location[2])
                        {
                            blocked = true;
                        }
                    }
                    if (blocked == false)
                        moves.Add("g" + (Int32.Parse(location[1].ToString()) - 2).ToString() + location[2]);
                }
                foreach(Piece p in player2Pieces)
                {
                    if(p.location[1].ToString() == (Int32.Parse(location[1].ToString()) - 1).ToString() & p.location[2].ToString() == (Int32.Parse(location[2].ToString()) - 1).ToString())
                    {
                        moves.Add("g" + (Int32.Parse(location[1].ToString()) - 1).ToString() + (Int32.Parse(location[2].ToString()) - 1).ToString());
                    }
                    if (p.location[1].ToString() == (Int32.Parse(location[1].ToString()) - 1).ToString() & p.location[2].ToString() == (Int32.Parse(location[2].ToString()) + 1).ToString())
                    {
                        moves.Add("g" + (Int32.Parse(location[1].ToString()) - 1).ToString() + (Int32.Parse(location[2].ToString()) + 1).ToString());
                    }
                }
            }
            else
            {
                foreach (Piece p in player1Pieces)
                {
                    if (p.location[1].ToString() == (Int32.Parse(location[1].ToString()) + 1).ToString() & p.location[2] == location[2])
                    {
                        blocked = true;
                    }
                }
                foreach (Piece p in player2Pieces)
                {
                    if (p.location[1].ToString() == (Int32.Parse(location[1].ToString()) + 1).ToString() & p.location[2] == location[2])
                    {
                        blocked = true;
                    }
                }
                if (blocked == false)
                    moves.Add("g" + (Int32.Parse(location[1].ToString()) + 1).ToString() + location[2]);
                if (blocked == false & moved == false)
                {
                    foreach (Piece p in player1Pieces)
                    {
                        if (p.location[1].ToString() == (Int32.Parse(location[1].ToString()) + 2).ToString() & p.location[2] == location[2])
                        {
                            blocked = true;
                        }
                    }
                    foreach (Piece p in player2Pieces)
                    {
                        if (p.location[1].ToString() == (Int32.Parse(location[1].ToString()) + 2).ToString() & p.location[2] == location[2])
                        {
                            blocked = true;
                        }
                    }
                    if (blocked == false)
                        moves.Add("g" + (Int32.Parse(location[1].ToString()) + 2).ToString() + location[2]);
                }
                foreach (Piece p in player1Pieces)
                {
                    if (p.location[1].ToString() == (Int32.Parse(location[1].ToString()) + 1).ToString() & p.location[2].ToString() == (Int32.Parse(location[2].ToString()) - 1).ToString())
                    {
                        moves.Add("g" + (Int32.Parse(location[1].ToString()) + 1).ToString() + (Int32.Parse(location[2].ToString()) - 1).ToString());
                    }
                    if (p.location[1].ToString() == (Int32.Parse(location[1].ToString()) + 1).ToString() & p.location[2].ToString() == (Int32.Parse(location[2].ToString()) + 1).ToString())
                    {
                        moves.Add("g" + (Int32.Parse(location[1].ToString()) + 1).ToString() + (Int32.Parse(location[2].ToString()) + 1).ToString());
                    }
                }
            }
            return moves;
        }
    }
    
}
