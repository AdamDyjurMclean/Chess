using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public static class Check
    {
        public static bool P1InCheck(List<Piece> player1Pieces, List<Piece> player2Pieces)
        {
            string kingLocation = "";
            foreach (Piece p in player1Pieces)
            {
                if (p is King)
                    kingLocation = p.location;
            }
            foreach (Piece p in player2Pieces)
            {
                if (p.location != "removed")
                {
                    if (p.Moves(player1Pieces, player2Pieces).Contains(kingLocation))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public static bool P2InCheck(List<Piece> player1Pieces, List<Piece> player2Pieces)
        {
            string kingLocation = "";
            foreach (Piece p in player2Pieces)
            {
                if (p is King)
                    kingLocation = p.location;
            }
            foreach (Piece p in player1Pieces)
            {
                if (p.location != "removed")
                {
                    if (p.Moves(player1Pieces, player2Pieces).Contains(kingLocation))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public static bool P1InCheckmate(List<Piece> player1Pieces, List<Piece> player2Pieces)
        {
            foreach (Piece p in player1Pieces)
            {
                string backup = p.location;
                string backup2 = "";
                if (backup != "removed")
                {
                    foreach (string s in p.Moves(player1Pieces, player2Pieces))
                    {
                        bool valid = true;
                        foreach (Piece piece in player1Pieces)
                        {
                            if (piece.location == s)
                                valid = false;
                        }
                        if (valid == true)
                        {
                            foreach (Piece piece in player2Pieces)
                            {
                                if (piece.location == s)
                                {
                                    backup2 = s;
                                    piece.location = "removed";
                                }
                            }
                            p.location = s;
                            if (P1InCheck(player1Pieces, player2Pieces) == false)
                            {
                                p.location = backup;
                                foreach (Piece piece in player2Pieces)
                                {
                                    if (piece.location == "removed")
                                        piece.location = backup2;
                                }
                                return false;
                            }
                        }
                    }
                    p.location = backup;
                    foreach(Piece piece in player2Pieces)
                    {
                        if (piece.location == "removed")
                            piece.location = backup2;
                    }
                }
            }
            return true;
        }
        public static bool P2InCheckmate(List<Piece> player1Pieces, List<Piece> player2Pieces)
        {
            foreach (Piece p in player2Pieces)
            {
                string backup = p.location;
                string backup2 = "";
                if (backup != "removed")
                {
                    foreach (string s in p.Moves(player1Pieces, player2Pieces))
                    {
                        bool valid = true;
                        foreach (Piece piece in player2Pieces)
                        {
                            if (piece.location == s)
                                valid = false;
                        }
                        if (valid == true)
                        {
                            foreach (Piece piece in player1Pieces)
                            {
                                if (piece.location == s)
                                {
                                    backup2 = s;
                                    piece.location = "removed";
                                }
                            }
                            p.location = s;
                            if (P2InCheck(player1Pieces, player2Pieces) == false)
                            {
                                p.location = backup;
                                foreach (Piece piece in player1Pieces)
                                {
                                    if (piece.location == "removed")
                                        piece.location = backup2;
                                }
                                return false;
                            }
                        }
                    }
                    p.location = backup;
                    foreach (Piece piece in player1Pieces)
                    {
                        if (piece.location == "removed")
                            piece.location = backup2;
                    }
                }
            }
            return true;
        }
    }
}
