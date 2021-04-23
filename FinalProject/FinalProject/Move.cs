using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Movment options for the castle, bishop and queen.
namespace FinalProject
{
    public static class Move
    {
        public static List<string> UpDown(List<string> moves, bool up, List<Piece> player1Pieces, List<Piece> player2Pieces, string location)
        {            
            int place = int.Parse(location[1].ToString());
            bool unblocked = true;
            do
            {
                if (up == true)
                    place--;
                else
                    place++;
                if (place < 1 | place > 8)
                    unblocked = false;
                else
                {
                    foreach (Piece p in player1Pieces)
                    {
                        if (p.location[1].ToString() == place.ToString() & p.location[2] == location[2])
                            unblocked = false;
                    }
                    foreach (Piece p in player2Pieces)
                    {
                        if (p.location[1].ToString() == place.ToString() & p.location[2] == location[2])
                            unblocked = false;
                    }
                    moves.Add("g" + place + location[2]);
                }
            } while (unblocked == true);
            return moves;
        }
        public static List<string> LeftRight(List<string> moves, bool left, List<Piece> player1Pieces, List<Piece> player2Pieces, string location)
        {
            int place = int.Parse(location[2].ToString());
            bool unblocked = true;
            do
            {
                if (left == true)
                    place--;
                else
                    place++;
                if (place < 1 | place > 8)
                    unblocked = false;
                else
                {
                    foreach (Piece p in player1Pieces)
                    {
                        if (p.location[2].ToString() == place.ToString() & p.location[1] == location[1])
                            unblocked = false;
                    }
                    foreach (Piece p in player2Pieces)
                    {
                        if (p.location[2].ToString() == place.ToString() & p.location[1] == location[1])
                            unblocked = false;
                    }
                    moves.Add("g" + location[1] + place );
                }
            } while (unblocked == true);
            return moves;
        }
        public static List<string> TopLeftBottomRight(List<string> moves, bool left, List<Piece> player1Pieces, List<Piece> player2Pieces, string location)
        {
            int placeVerticle = int.Parse(location[1].ToString());
            int placeHorizontal = int.Parse(location[2].ToString());
            bool unblocked = true;
            do
            {
                if (left == true)
                {
                    placeVerticle--;
                    placeHorizontal--;
                }
                else
                {
                    placeVerticle++;
                    placeHorizontal++;
                }
                if (placeVerticle < 1 | placeHorizontal > 8 | placeHorizontal < 1 | placeVerticle > 8)
                    unblocked = false;
                else
                {
                    foreach (Piece p in player1Pieces)
                    {
                        if (p.location[1].ToString() == placeVerticle.ToString() & p.location[2].ToString() == placeHorizontal.ToString())
                            unblocked = false;
                    }
                    foreach (Piece p in player2Pieces)
                    {
                        if (p.location[1].ToString() == placeVerticle.ToString() & p.location[2].ToString() == placeHorizontal.ToString())
                            unblocked = false;
                    }
                    moves.Add("g" + placeVerticle + placeHorizontal);
                }
            } while (unblocked == true);
            return moves;
        }
        public static List<string> TopRightBottomLeft(List<string> moves, bool left, List<Piece> player1Pieces, List<Piece> player2Pieces, string location)
        {
            int placeVerticle = int.Parse(location[1].ToString());
            int placeHorizontal = int.Parse(location[2].ToString());
            bool unblocked = true;
            do
            {
                if (left == true)
                {
                    placeVerticle++;
                    placeHorizontal--;
                }
                else
                {
                    placeVerticle--;
                    placeHorizontal++;
                }
                if (placeVerticle < 1 | placeHorizontal > 8 | placeHorizontal < 1 | placeVerticle > 8)
                    unblocked = false;
                else
                {
                    foreach (Piece p in player1Pieces)
                    {
                        if (p.location[1].ToString() == placeVerticle.ToString() & p.location[2].ToString() == placeHorizontal.ToString())
                            unblocked = false;
                    }
                    foreach (Piece p in player2Pieces)
                    {
                        if (p.location[1].ToString() == placeVerticle.ToString() & p.location[2].ToString() == placeHorizontal.ToString())
                            unblocked = false;
                    }
                    moves.Add("g" + placeVerticle + placeHorizontal);
                }
            } while (unblocked == true);
            return moves;
        }
        public static bool CastlingP1Left(List<Piece> player1Pieces, List<Piece> player2Pieces)
        {
            foreach(Piece p in player1Pieces)
            {
                if (p.location == "g82" | p.location == "g83" | p.location == "g84")
                    return false;
            }
            foreach (Piece p in player2Pieces)
            {
                if (p.location == "g82" | p.location == "g83" | p.location == "g84")
                    return false;
            }
            foreach (Piece p in player2Pieces)
            {
                if (p.Moves(player1Pieces, player2Pieces).Contains("g81") | p.Moves(player1Pieces, player2Pieces).Contains("g82") | 
                    p.Moves(player1Pieces, player2Pieces).Contains("g83") | p.Moves(player1Pieces, player2Pieces).Contains("g84") |
                    p.Moves(player1Pieces, player2Pieces).Contains("g85"))
                    return false;
            }
            foreach (Piece p in player1Pieces)
            {
                if (p.location == "g81" & p.moved == false)
                    return true;
            }
            return false;
        }
        public static bool CastlingP1Right(List<Piece> player1Pieces, List<Piece> player2Pieces)
        {
            foreach (Piece p in player1Pieces)
            {
                if (p.location == "g86" | p.location == "g87")
                    return false;
            }
            foreach (Piece p in player2Pieces)
            {
                if (p.location == "g86" | p.location == "g87")
                        return false;
            }
            foreach (Piece p in player2Pieces)
            {
                if (p.Moves(player1Pieces, player2Pieces).Contains("g85") | p.Moves(player1Pieces, player2Pieces).Contains("g86") |
                    p.Moves(player1Pieces, player2Pieces).Contains("g87") | p.Moves(player1Pieces, player2Pieces).Contains("g88"))
                    return false;
            }
            foreach (Piece p in player1Pieces)
            {
                if (p.location == "g88" & p.moved == false)
                    return true;
            }
            return false;
        }
        public static bool CastlingP2Left(List<Piece> player1Pieces, List<Piece> player2Pieces)
        {
            foreach (Piece p in player1Pieces)
            {
                if (p.location == "g12" | p.location == "g13" | p.location == "g14")
                    return false;
            }
            foreach (Piece p in player2Pieces)
            {
                if (p.location == "g12" | p.location == "g13" | p.location == "g14")
                    return false;
            }
            foreach (Piece p in player1Pieces)
            {
                if (p.Moves(player1Pieces, player2Pieces).Contains("g11") | p.Moves(player1Pieces, player2Pieces).Contains("g12") |
                    p.Moves(player1Pieces, player2Pieces).Contains("g13") | p.Moves(player1Pieces, player2Pieces).Contains("g14") |
                    p.Moves(player1Pieces, player2Pieces).Contains("g15"))
                    return false;
            }
            foreach (Piece p in player2Pieces)
            {
                if (p.location == "g11" & p.moved == false)
                    return true;
            }
            return false;
        }
        public static bool CastlingP2Right(List<Piece> player1Pieces, List<Piece> player2Pieces)
        {
            foreach (Piece p in player1Pieces)
            {
                if (p.location == "g16" | p.location == "g17")
                    return false;
            }
            foreach (Piece p in player2Pieces)
            {
                if (p.location == "g16" | p.location == "g17")
                    return false;
            }
            foreach (Piece p in player1Pieces)
            {
                if (p.Moves(player1Pieces, player2Pieces).Contains("g15") | p.Moves(player1Pieces, player2Pieces).Contains("g16") |
                    p.Moves(player1Pieces, player2Pieces).Contains("g17") | p.Moves(player1Pieces, player2Pieces).Contains("g18"))
                    return false;
            }
            foreach (Piece p in player2Pieces)
            {
                if (p.location == "g18" & p.moved == false)
                    return true;
            }
            return false;
        }
    }
}
