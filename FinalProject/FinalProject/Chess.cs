using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace FinalProject
{
    public partial class Chess : Form
    {
        string player1, player2;
        List<Piece> player1Pieces = new List<Piece>();
        List<Piece> player2Pieces = new List<Piece>();
        bool turnPhase = true;
        bool player1Turn = true;
        string winner = "tie";
        public Chess(string p1, string p2)
        {
            InitializeComponent();
            player1 = p1;
            player2 = p2;
            AddPieces();
            Display();
            lblP2.Text = player1 + " - White";
            lblP1.Text = player2 + " - Black";
        }
        public void AddPieces()
        {
            player1Pieces.Add(new Castle("g81", "White Castle.png"));
            player1Pieces.Add(new Castle("g88", "White Castle.png"));
            player1Pieces.Add(new Horse("g82", "White Horse.png"));
            player1Pieces.Add(new Horse("g87", "White Horse.png"));
            player1Pieces.Add(new Bishop("g83", "White Bishop.png"));
            player1Pieces.Add(new Bishop("g86", "White Bishop.png"));
            player1Pieces.Add(new King("g85", "White King.png"));
            player1Pieces.Add(new Queen("g84", "White Queen.png"));
            player1Pieces.Add(new Pawn("g71", "White Pawn.png"));
            player1Pieces.Add(new Pawn("g72", "White Pawn.png"));
            player1Pieces.Add(new Pawn("g73", "White Pawn.png"));
            player1Pieces.Add(new Pawn("g74", "White Pawn.png"));
            player1Pieces.Add(new Pawn("g75", "White Pawn.png"));
            player1Pieces.Add(new Pawn("g76", "White Pawn.png"));
            player1Pieces.Add(new Pawn("g77", "White Pawn.png"));
            player1Pieces.Add(new Pawn("g78", "White Pawn.png"));
            player2Pieces.Add(new Castle("g11", "Black Castle.png"));
            player2Pieces.Add(new Castle("g18", "Black Castle.png"));
            player2Pieces.Add(new Horse("g12", "Black Horse.png"));
            player2Pieces.Add(new Horse("g17", "Black Horse.png"));
            player2Pieces.Add(new Bishop("g13", "Black Bishop.png"));
            player2Pieces.Add(new Bishop("g16", "Black Bishop.png"));
            player2Pieces.Add(new Queen("g14", "Black Queen.png"));
            player2Pieces.Add(new King("g15", "Black King.png"));
            player2Pieces.Add(new Pawn("g21", "Black Pawn.png"));
            player2Pieces.Add(new Pawn("g22", "Black Pawn.png"));
            player2Pieces.Add(new Pawn("g23", "Black Pawn.png"));
            player2Pieces.Add(new Pawn("g24", "Black Pawn.png"));
            player2Pieces.Add(new Pawn("g25", "Black Pawn.png"));
            player2Pieces.Add(new Pawn("g26", "Black Pawn.png"));
            player2Pieces.Add(new Pawn("g27", "Black Pawn.png"));
            player2Pieces.Add(new Pawn("g28", "Black Pawn.png"));
            return;
        }
        public void Display()
        {
            if(player1Turn == true)
                lblTurn.Text = ($"{player1}'s turn");
            else
                lblTurn.Text = ($"{player2}'s turn");
            foreach (Control c in Controls)
            {
                c.BackgroundImage = null;
                foreach (Piece p in player1Pieces)
                {
                    if (p.location == c.Name)
                    {
                        c.BackgroundImage = Image.FromFile(p.image);
                    }
                }
                foreach (Piece p in player2Pieces)
                {
                    if (p.location == c.Name)
                    {
                        c.BackgroundImage = Image.FromFile(p.image);
                    }
                }
            }
            return;
        }
        private void pnl_Click(object sender, EventArgs e)
        {
            if (turnPhase == true)
                Select(sender);
            else
            {
                MovePiece(sender);
                ResetColor();
                Display();
            }
            return;
        }
        private void Select(object sender)
        {
            PictureBox p = (PictureBox)sender;
            if (player1Turn == true)
            {
                foreach (Piece piece in player1Pieces)
                {
                    if (piece.location == p.Name)
                    {
                        turnPhase = false;
                        p.BackColor = Color.LightGreen;
                        List<string> moves = new List<string>();
                        moves = piece.Moves(player1Pieces, player2Pieces);
                        foreach (string s in moves)
                        {
                            foreach (Control c in Controls)
                            {
                                if (s == c.Name & c.BackgroundImage == null)
                                    c.BackColor = Color.Green;
                            }
                            foreach (Piece piece2 in player2Pieces)
                            {
                                if (s == piece2.location)
                                {
                                    foreach (Control c in Controls)
                                    {
                                        if (s == c.Name)
                                            c.BackColor = Color.Green;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                foreach (Piece piece in player2Pieces)
                {
                    if (piece.location == p.Name)
                    {
                        turnPhase = false;
                        p.BackColor = Color.LightGreen;
                        List<string> moves = new List<string>();
                        moves = piece.Moves(player1Pieces, player2Pieces);
                        foreach (string s in moves)
                        {
                            foreach (Control c in Controls)
                            {
                                if (s == c.Name & c.BackgroundImage == null)
                                    c.BackColor = Color.Green;
                            }
                            foreach (Piece piece2 in player1Pieces)
                            {
                                if (s == piece2.location)
                                {
                                    foreach (Control c in Controls)
                                    {
                                        if (s == c.Name)
                                            c.BackColor = Color.Green;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return;
        }
        private void MovePiece(object sender)
        {
            PictureBox p = (PictureBox)sender;
            if(player1Turn == true)
            {
                if (p.BackColor == Color.Green)
                {
                    foreach (Control c in Controls)
                    {
                        if (c is PictureBox & c.BackColor == Color.LightGreen)
                        {
                            foreach (Piece piece in player1Pieces)
                            {
                                if (piece.location == c.Name)
                                {
                                    string backup = piece.location;
                                    piece.location = p.Name;
                                    piece.moved = true;
                                    for (int i = player2Pieces.Count - 1; i >= 0; i--)
                                    {
                                        if (player2Pieces[i].location == p.Name)
                                        {
                                            if (player2Pieces[i].location == p.Name)
                                            {
                                                List<Piece> removeOne = new List<Piece>();
                                                removeOne = player2Pieces;
                                                removeOne.Remove(player2Pieces[i]);
                                                if (Check.P1InCheck(player1Pieces, removeOne) == false)
                                                    player2Pieces = removeOne;
                                            }
                                        }    
                                    }
                                    if (Check.P1InCheck(player1Pieces, player2Pieces) == true)
                                    {
                                        MessageBox.Show("Can not leave yourself in check");
                                        piece.location = backup;
                                        piece.moved = false;
                                        turnPhase = true;
                                        ResetColor();
                                        return;
                                    }
                                    if (piece is King & backup == "g85" & p.Name == "g83")
                                    {
                                        foreach (Piece castle in player1Pieces)
                                        {
                                            if (castle.location == "g81")
                                                castle.location = "g84";
                                        }
                                    }
                                    if (piece is King & backup == "g85" & p.Name == "g87")
                                    {
                                        foreach (Piece castle in player1Pieces)
                                        {
                                            if (castle.location == "g88")
                                                castle.location = "g86";
                                        }
                                    }
                                    if (Check.P2InCheck(player1Pieces, player2Pieces) == true)
                                    {
                                        if (Check.P2InCheckmate(player1Pieces, player2Pieces) == true)
                                        {
                                            Display();
                                            ResetColor();
                                            MessageBox.Show(player1 + " Wins!");
                                            winner = player1;
                                            EndGame();
                                        }
                                    }
                                }
                            }
                            if (player1Turn == true)
                                player1Turn = false;
                            else
                                player1Turn = true;
                        }
                    }
                }
            }
            else
            {
                if (p.BackColor == Color.Green)
                {
                    foreach (Control c in Controls)
                    {
                        if (c is PictureBox & c.BackColor == Color.LightGreen)
                        {
                            foreach (Piece piece in player2Pieces)
                            {
                                if (piece.location == c.Name)
                                {
                                    string backup = piece.location;
                                    piece.location = p.Name;
                                    piece.moved = true;
                                    for (int i = player1Pieces.Count - 1; i >= 0; i--)
                                    {
                                        if (player1Pieces[i].location == p.Name)
                                        {
                                            List<Piece> removeOne = new List<Piece>();
                                            removeOne = player1Pieces;
                                            removeOne.Remove(player1Pieces[i]);
                                            if (Check.P2InCheck(removeOne, player2Pieces) == false)
                                                player1Pieces = removeOne;
                                        }
                                    }
                                    if (Check.P2InCheck(player1Pieces, player2Pieces) == true)
                                    {
                                        MessageBox.Show("Can not leave yourself in check");
                                        piece.location = backup;
                                        piece.moved = false;
                                        turnPhase = true;
                                        ResetColor();
                                        return;
                                    }
                                    if (piece is King & backup == "g15" & p.Name == "g13")
                                    {
                                        foreach (Piece castle in player2Pieces)
                                        {
                                            if (castle.location == "g11")
                                                castle.location = "g14";
                                        }
                                    }
                                    if (piece is King & backup == "g15" & p.Name == "g17")
                                    {
                                        foreach (Piece castle in player2Pieces)
                                        {
                                            if (castle.location == "g18")
                                                castle.location = "g16";
                                        }
                                    }
                                    if (Check.P1InCheck(player1Pieces, player2Pieces) == true)
                                    {
                                        if (Check.P1InCheckmate(player1Pieces, player2Pieces) == true)
                                        {
                                            Display();
                                            ResetColor();
                                            MessageBox.Show(player2 + " Wins!");
                                            winner = player2;
                                            EndGame();
                                        }
                                    }
                                }
                            }
                            if (player1Turn == true)
                                player1Turn = false;
                            else
                                player1Turn = true;
                        }
                    }
                }
            }
            turnPhase = true;
            ResetColor();
            CheckPawns();
            return;
        }

        private void btnSurrender_Click(object sender, EventArgs e)
        {
            lblSure.Visible = true;
            btnNo.Visible = true;
            btnYes.Visible = true;
            btnDraw.Enabled = false;
            foreach(Control c in Controls)
            {
                if (c is PictureBox)
                    c.Enabled = false;
            }
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            lblSure.Visible = false;
            btnNo.Visible = false;
            btnYes.Visible = false;
            btnDraw.Enabled = true;
            foreach (Control c in Controls)
            {
                if (c is PictureBox)
                    c.Enabled = true;
            }
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            if(player1Turn == true)
            {
                MessageBox.Show(player2 + " Wins!");
                winner = player2;
            }
            else
            {
                MessageBox.Show(player1 + " Wins!");
                winner = player1;
            }
            EndGame();
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            btnAccept.Visible = true;
            btnDecline.Visible = true;
            btnSurrender.Enabled = false;
            foreach (Control c in Controls)
            {
                if (c is PictureBox)
                    c.Enabled = false;
            }
            if (player1Turn == true)
                lblAccept.Text = ($" Does {player2} accept?");
            else
                lblAccept.Text = ($" Does {player1} accept?");
        }

        private void btnDecline_Click(object sender, EventArgs e)
        {
            btnAccept.Visible = false;
            btnDecline.Visible = false;
            btnSurrender.Enabled = true;
            foreach (Control c in Controls)
            {
                if (c is PictureBox)
                    c.Enabled = true;
            }
            lblAccept.Text = "";
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This game is a tie.");
            EndGame();
        }

        private void ResetColor()
        {
            foreach(Control c in Controls)
            {
                if(c is PictureBox)
                {
                    if ((c.Name[1] % 2 == 0 & c.Name[2] % 2 == 0) | (c.Name[1] % 2 != 0 & c.Name[2] % 2 != 0))
                        c.BackColor = Color.Bisque;
                    else
                        c.BackColor = Color.Brown;
                }
            }
            return;
        }

        private void Promote(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            foreach (Piece p in player1Pieces)
            {
                if (p is Pawn & p.location[1] == '1')
                {
                    string old = p.location;
                    player1Pieces.Remove(p);
                    if(b.Name == "btnQueen")
                        player1Pieces.Add(new Queen(old, "White Queen.png"));
                    else if (b.Name == "btnHorse")
                        player1Pieces.Add(new Horse(old, "White Horse.png"));
                    else if (b.Name == "btnBishop")
                        player1Pieces.Add(new Bishop(old, "White Bishop.png"));
                    else
                        player1Pieces.Add(new Castle(old, "White Castle.png"));
                    break;

                }
            }
            foreach (Piece p in player2Pieces)
            {
                if (p is Pawn & p.location[1] == '8')
                {
                    string old = p.location;
                    player2Pieces.Remove(p);
                    if (b.Name == "btnQueen")
                        player2Pieces.Add(new Queen(old, "Black Queen.png"));
                    else if (b.Name == "btnHorse")
                        player2Pieces.Add(new Horse(old, "Black Horse.png"));
                    else if (b.Name == "btnBishop")
                        player2Pieces.Add(new Bishop(old, "Black Bishop.png"));
                    else
                        player2Pieces.Add(new Castle(old, "Black Castle.png"));
                    break;

                }
            }
            Display();
            foreach (Control c in Controls)
            {
                if (c is PictureBox)
                    c.Enabled = true;
            }
            lblPromote.Visible = false;
            btnQueen.Visible = false;
            btnHorse.Visible = false;
            btnBishop.Visible = false;
            btnCastle.Visible = false;

        }

        private void CheckPawns()
        {
            foreach(Piece p in player1Pieces)
            {
                if(p is Pawn & p.location[1] == '1')
                {
                    foreach (Control c in Controls)
                    {
                        if (c is PictureBox)
                            c.Enabled = false;
                    }
                    lblPromote.Visible = true;
                    btnQueen.Visible = true;
                    btnHorse.Visible = true;
                    btnBishop.Visible = true;
                    btnCastle.Visible = true;
                }
            }
            foreach (Piece p in player2Pieces)
            {
                if (p is Pawn & p.location[1] == '8')
                {
                    foreach (Control c in Controls)
                    {
                        if (c is PictureBox)
                            c.Enabled = false;
                    }
                    lblPromote.Visible = true;
                    btnQueen.Visible = true;
                    btnHorse.Visible = true;
                    btnBishop.Visible = true;
                    btnCastle.Visible = true;
                }
            }
        }

        private void lblPromote_Click(object sender, EventArgs e)
        {

        }

        private void EndGame()
        {
            List<string> fileNames = new List<string>();
            using (StreamReader reader = new StreamReader("Players.csv"))
            {
                do
                {
                    fileNames.Add(reader.ReadLine());
                } while (!reader.EndOfStream);
                for (int i = 0; i < fileNames.Count; i++)
                {
                    string[] array = { fileNames[i].Split(',')[0], fileNames[i].Split(',')[1], fileNames[i].Split(',')[2], fileNames[i].Split(',')[3], fileNames[i].Split(',')[4] };
                    if(fileNames[i].Split(',')[0] == player1)
                    {
                        array[1] = (int.Parse(array[1]) + 1).ToString();
                        if (winner == player1)
                            array[2] = (int.Parse(array[2]) + 1).ToString();
                        else if(winner == player2)
                            array[3] = (int.Parse(array[3]) + 1).ToString();
                        else
                            array[4] = (int.Parse(array[4]) + 1).ToString();
                        fileNames[i] = ($"{array[0]},{array[1]},{array[2]},{array[3]},{array[4]}");
                    }
                    else if (fileNames[i].Split(',')[0] == player2)
                    {
                        array[1] = (int.Parse(array[1]) + 1).ToString();
                        if (winner == player2)
                            array[2] = (int.Parse(array[2]) + 1).ToString();
                        else if (winner == player1)
                            array[3] = (int.Parse(array[3]) + 1).ToString();
                        else
                            array[4] = (int.Parse(array[4]) + 1).ToString();
                        fileNames[i] = ($"{array[0]},{array[1]},{array[2]},{array[3]},{array[4]}");
                    }
                }
            }
            File.WriteAllText("Players.csv", string.Empty);
            using (StreamWriter writer = new StreamWriter("Players.csv", true))
            {
                foreach(string s in fileNames)
                {
                    writer.WriteLine(s);
                }
            }
            this.Close();
        }
    }
}
