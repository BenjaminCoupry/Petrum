using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;


namespace Petrum
{
    public partial class Petrum : Form
    {
        public Petrum(bool Host, int Port,string IP = null)
        {
            InitializeComponent();
            Path = System.Environment.CurrentDirectory;
            chargementOK = true;
            try
            {
                bpLapin = (Bitmap)Bitmap.FromFile(Path + "/Lapin.bmp");
                bpHerbe = (Bitmap)Bitmap.FromFile(Path + "/Herbe.bmp");
                bpLoup = (Bitmap)Bitmap.FromFile(Path + "/Loup.bmp");
            }
            catch(Exception e)
            {
                MessageBox.Show("Textures Introuvables "+e.Message);
                chargementOK = false;
            }
            this.Resize += Petrum_Resize;
            this.KeyDown += MainWindow_KeyDown;
            MessageReciver.DoWork += MessageReciver_DoWork;
            CheckForIllegalCrossThreadCalls = false;
            Plat = new Plateau(herbeInit);
            Maj();
            if (Host)
            {
                Joueur = 0;
                Serveur = new TcpListener(System.Net.IPAddress.Any, Port);
                Serveur.Start();
                UnfreezePlateau();
                Sock = Serveur.AcceptSocket();
            }
            else
            {
                Joueur = 1;
                try
                {
                    Client = new TcpClient(IP, Port);
                    Sock = Client.Client;
                    MessageReciver.RunWorkerAsync();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Close();
                }
            }
        }

        private void Petrum_Resize(object sender, EventArgs e)
        {
            Maj();
        }
        private bool chargementOK;
        private Bitmap bpLapin;
        private Bitmap bpHerbe;
        private Bitmap bpLoup;
        private void MessageReciver_DoWork(object sender, DoWorkEventArgs e)
        {
            if(CheckFin())
            {
                return;
            }
            else
            {
                FreezePlateau();
                MouvementAdv();
                if(!CheckFin())
                {
                    UnfreezePlateau();
                }
            }
        }
        private string Path;
        private int Joueur;
        private Mouvement mouvCourant = new Mouvement(-1, -1,-1,-1);
        private int NbTours = 0;
        private int nbSerie = 0;
        private int TailleSerie = 3;
        private int LongueurPartie = 30;
        private int herbeInit = 10;
        private bool Frozen;
        private int Points=0;
        private int PointsAdv=0;
        private Socket Sock;
        private BackgroundWorker MessageReciver = new BackgroundWorker();
        private TcpListener Serveur = null;
        private TcpClient Client = null;
        private Plateau Plat;
        private bool CheckFin()
        {
            int[] nb = Plat.nbPieces();
            bool fini = NbTours > LongueurPartie || (NbTours >2 &&(nb[0] ==0 || nb[1] ==0)) ;
            if (fini)
            {
                if(Points>PointsAdv)
                {
                    MessageBox.Show("Victoire !");
                }
                else
                {
                    MessageBox.Show("Defaite !");
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        private void FreezePlateau()
        {
            Frozen = true;
            buttGO.Enabled = false;
            labStatus.Text = "En attente";
        }
        private void UnfreezePlateau()
        {
            Frozen = false;
            buttGO.Enabled = true;
            labStatus.Text = "A vous !";
        }
        //Appeler
        private void EnvoyerMouvement(Mouvement mouv)
        {
            if (Plat.EffectuerMouvement(mouv,Joueur))
            {
                nbSerie++;
                Sock.Send(mouv.toBuffer());
                if (nbSerie >= TailleSerie)
                {
                    nbSerie = 0;
                    NbTours += 1;
                    Plat.MajLoups(Joueur);
                    MajPts(false);
                    MessageReciver.RunWorkerAsync();
                }
            }
            Maj();
        }
        private Mouvement RecevoirMouvement()
        {
            byte[] buffer = Mouvement.getBuffer();
            Sock.Receive(buffer);
            
            return new Mouvement(buffer);
        }
        private void MouvementAdv()
        {
            for (int i = 0; i < TailleSerie; i++)
            {
                Plat.EffectuerMouvement(RecevoirMouvement(),1-Joueur);
                Maj();
            }
            Plat.MajLoups(1-Joueur);
            MajPts(true);
            NbTours += 1;
            Maj();
            Plat.SonReussite();
        }
        public class Mouvement
        {
            public int mode;
            int x0;
            int y0;
            int x1;
            int y1;
            public Mouvement(byte[] infos)
            {
                mode = infos[0];
                x0 = infos[1];
                x1 = infos[2];
                y0 = infos[3];
                y1 = infos[4];
            }

            public Mouvement(int x0, int y0, int x1, int y1)
            {
                mode = 0;
                this.x0 = x0;
                this.y0 = y0;
                this.x1 = x1;
                this.y1 = y1;
            }

            public static byte[] getBuffer()
            {
                return new byte[5];
            }
            public byte[] toBuffer()
            {
                byte[] ret = getBuffer();
                ret [0] = (byte)mode;
                ret[1] = (byte)x0;
                ret[2] = (byte)x1;
                ret[3] = (byte)y0;
                ret[4] = (byte)y1;
                return ret;
            }
            public void Select(Point p,Plateau plat)
            {
                int x = p.X;
                int y = p.Y;
                if(x0==-1 && y0 ==-1)
                {
                    x0 = x;
                    y0 = y;
                    Console.Beep(200, 80);
                }
                else if ((mode ==0)&&(x0 != -1 && y0 != -1 && x1 == -1 && y1 == -1 && (x0 != x || y0 !=y)))
                {
                    x1 = x;
                    y1 = y;
                    Console.Beep(200, 80);
                }
                else
                {
                    x0 = -1;
                    y0 = -1;
                    x1 = -1;
                    y1 = -1;
                    Console.Beep(120, 100);
                }

            }
            public bool Pret(Plateau plat, int Joueur)
            {
                if (mode == 0)
                {
                    return x1 != -1 && y1 != -1 && x0 != -1 && y0 != -1;
                }
                else
                {
                    return x0 != -1 && y0 != -1;
                }
            }
            public Point getP1()
            {
                return new Point(x0, y0);
            }
            public Point getP2()
            {
                return new Point(x1, y1);
            }
            public void setMode(int md)
            {
                mode = md;
            }
        }
        public class Plateau
        {
            public static int X=15;
            public static int Y=15;
            private Piece[,] Pieces;
            private List<Piece>[] prises;
            public Plateau(int herbeInit)
            {
                prises = new List<Piece>[2];
                prises[0] = new List<Piece>();
                prises[1] = new List<Piece>();
                for(int i=0;i<herbeInit;i++)
                {
                    prises[0].Add(new Piece(GenrePiece.Herbe,0));
                    prises[1].Add(new Piece(GenrePiece.Herbe, 1));
                }
                genererGrille();
            }
            private void genererGrille()
            {
                Pieces = new Piece[X, Y];
                for (int x = 0; x < X; x++)
                {
                    for (int y = 0; y < Y; y++)
                    {
                        Pieces[x, y] = new Piece();
                    }
                }
            }
            public void SonErreur()
            {
                Console.Beep(500, 100);
                Console.Beep(350, 100);
            }
            public void SonReussite()
            {
                Console.Beep(80, 100);
            }
            public bool EffectuerMouvement(Mouvement mouv, int Joueur)
            {
                Point p1 = mouv.getP1();
                Point p2 = mouv.getP2();
                bool ret = false;
                if (mouv.mode ==0)
                {
                    //deplacement
                    if (DeplacementLegal(p1,p2))
                    {
                        ret = Deplacer(p1, p2, Joueur);
                    }
                    else
                    {
                        ret = false;
                    }
                }
               else if(mouv.mode == 1)
               {
                    //Sacrifice
                    ret =  Sacrifier(p1, Joueur);
               }
               else if(mouv.mode == 2)
               {
                    //Placer Lapin
                    ret =  Placer(p1, Joueur, GenrePiece.Lapin);
               }
               else if (mouv.mode == 3)
               {
                    //Placer Herbe
                    ret =  Placer(p1, Joueur, GenrePiece.Herbe);
               }
               else if (mouv.mode == 4)
               {
                    //Placer Loup
                    ret =  Placer(p1, Joueur, GenrePiece.Loup);
               }
               else
               {
                    ret =  false;
               }
                if(!ret)
                {
                    SonErreur();
                }
                else
                {
                    SonReussite();
                }
                return ret;

            }
            private Bitmap grilleVide(int x, int y)
            {
                Bitmap ret = new Bitmap(x, y);
                int x_ = x / X;
                int y_ = y / Y;
                Color cl = Color.Black;
                using (Graphics g = Graphics.FromImage(ret))
                {
                    for (int i = 0; i < X; i++)
                    {
                        for (int j = 0; j < X; j++)
                        {
                            if (cl == Color.Black)
                            {
                                cl = Color.White;
                            }
                            else
                            {
                                cl = Color.Black;
                            }
                            SolidBrush sb = new SolidBrush(cl);
                            g.FillRectangle(sb, i * x_, j * y_, x_, y_);
                        }
                    }
                }
                return ret;
            }
            private Bitmap grilleSelect(Bitmap grille,Mouvement mv)
            {
                int x_ = grille.Width / X;
                int y_ = grille.Height / Y;
                Color cl = Color.Black;
                Pen p1 = new Pen(Brushes.Blue,4);
                Pen p2 = new Pen(Brushes.Red,4);
                using (Graphics g = Graphics.FromImage(grille))
                {
                    Point pt1 = mv.getP1();
                    Point pt2 = mv.getP2();
                    if (pt1.X != -1 && pt1.Y != -1)
                    {
                        g.DrawRectangle(p1, pt1.X * x_, pt1.Y * y_, x_, y_);
                    }
                    if ((pt2.X != -1 && pt2.Y != -1)&& (mv.mode ==0))
                    {
                        g.DrawRectangle(p2, pt2.X * x_, pt2.Y * y_, x_, y_);
                    }
                    if ((pt1.X != -1 && pt1.Y != -1 && pt2.X != -1 && pt2.Y != -1)&&(mv.mode ==0))
                    {
                        g.DrawLine(p1, pt1.X * x_+x_/2, pt1.Y * y_+y_/2, pt2.X * x_+x_/2, pt2.Y * y_+y_/2);
                    }
                }
                return grille;
            }
            private Bitmap dessinerPieces(Bitmap grille, int Joueur, Bitmap bpLoup, Bitmap bpLapin, Bitmap bpHerbe, bool bitmapOK)
            {
                int x_ = grille.Width / X;
                int y_ = grille.Height / Y;
                Pen p1 = new Pen(Color.Red, 4);
                Pen p2 = new Pen(Color.Blue, 4);
                using (Graphics g = Graphics.FromImage(grille))
                {
                    for (int i = 0; i < X; i++)
                    {
                        for (int j = 0; j < X; j++)
                        {
                            Piece pc = getPiece(i, j);
                            if (!pc.PieceVide)
                            {
                                SolidBrush sb;
                                Bitmap select;
                                if (pc.getGenre() == GenrePiece.Herbe)
                                {
                                    sb = new SolidBrush(Color.Green);
                                    select = bpHerbe;
                                }
                                else if (pc.getGenre() == GenrePiece.Lapin)
                                {
                                    sb = new SolidBrush(Color.Gold);
                                    select = bpLapin;
                                }
                                else
                                {
                                    sb = new SolidBrush(Color.Gray);
                                    select = bpLoup;
                                }
                                if(bitmapOK)
                                {
                                    if (pc.Joueur != Joueur)
                                    {
                                        g.DrawEllipse(p1, i * x_, j * y_, x_, y_);
                                    }
                                    else
                                    {
                                        g.DrawEllipse(p2, i * x_, j * y_, x_, y_);
                                    }
                                    g.DrawImage(select, i * x_, j * y_, x_, y_);
                                }
                                else
                                {
                                    g.FillEllipse(sb, i * x_, j * y_, x_, y_);
                                    if (pc.Joueur != Joueur)
                                    {
                                        g.DrawEllipse(p1, i * x_, j * y_, x_, y_);
                                    }
                                    else
                                    {
                                        g.DrawEllipse(p2, i * x_, j * y_, x_, y_);
                                    }
                                }
                                
                            }
                        }
                    }
                }
                return grille;
            }
            public Bitmap getBitmap(int x, int y,Mouvement mouvCourant,int Joueur, Bitmap bpLoup, Bitmap bpLapin, Bitmap bpHerbe,bool bitmapOK)
            {
                return dessinerPieces(grilleSelect(grilleVide(x,y),mouvCourant),Joueur,bpLoup,bpLapin,bpHerbe,bitmapOK);
            }
            public Bitmap getBitmapPrises(int x, int y, int Joueur, Bitmap bpLoup, Bitmap bpLapin, Bitmap bpHerbe,bool bitmapOK)
            {
                Bitmap retour = new Bitmap(x, y);
                using (Graphics gr = Graphics.FromImage(retour))
                {
                    int nb = prises[Joueur].Count;
                    if (nb != 0)
                    {
                        int r = x;
                        int delta = (y-r) / nb;
                        Pen p1 = new Pen(Color.Red, 5);
                        Pen p2 = new Pen(Color.Blue, 5);
                        for (int i = 0; i < nb; i++)
                        {
                            SolidBrush sb;
                            Piece pc = prises[Joueur].ElementAt(i);
                            Bitmap select;
                            if (pc.getGenre() == GenrePiece.Herbe)
                            {
                                sb = new SolidBrush(Color.Green);
                                select = bpHerbe;
                            }
                            else if (pc.getGenre() == GenrePiece.Lapin)
                            {
                                sb = new SolidBrush(Color.Gold);
                                select = bpLapin;
                            }
                            else
                            {
                                sb = new SolidBrush(Color.Gray);
                                select = bpLoup;
                            }
                            if (!bitmapOK)
                            {
                                gr.FillEllipse(sb, 0, i * delta, r, r);
                                if (pc.Joueur != Joueur)
                                {
                                    gr.DrawEllipse(p1, 0, i * delta, r, r);
                                }
                                else
                                {
                                    gr.DrawEllipse(p2, 0, i * delta, r, r);
                                }
                            }
                            else
                            {
                                if (pc.Joueur != Joueur)
                                {
                                    gr.DrawEllipse(p1, 0, i * delta, r, r);
                                }
                                else
                                {
                                    gr.DrawEllipse(p2, 0, i * delta, r, r);
                                }
                                gr.DrawImage(select, 0, i * delta, r, r);
                            }
                            
                        }
                    }
                }

                    return retour;
            }
            public Piece getPiece(int x,int y)
            {
                if(x>=X || x<0 || y>=Y || y<0)
                {
                    return new Piece();
                }
                else
                {
                    return Pieces[x, y];
                }
            }
            public int[] Points()
            {
                int[] retour = new int[2];
                retour[0] = 0;
                retour[1] = 0;
                for(int x =0;x<X;x++)
                {
                    for (int y = 0; y <Y; y++)
                    {
                        Piece pc = getPiece(x, y);
                        if (!pc.PieceVide)
                        {
                            retour[pc.Joueur] += Points(x, y, pc.Joueur);
                        }
                    }
                }
                return retour;
            }
            public int Points(int x,int y, int joueur)
            {
                Piece pc = getPiece(x, y);
                if (pc.PieceVide || pc.Joueur != joueur)
                {
                    return 0;
                }
                else
                {
                    if (pc.getGenre() == GenrePiece.Loup)
                    {
                        return 2;
                    }
                    else if(pc.getGenre() == GenrePiece.Herbe)
                    {
                        return 0;
                    }
                    else if (pc.getGenre() == GenrePiece.Lapin)
                    {
                        if(EntourageFavorable(x,y,true))
                        {
                            return 1;
                        }
                        else
                        {
                            return 0;
                        }
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            private bool EntourageFavorable(int x, int y, bool plantesSauvent)
            {
                bool retour = true;
                for(int i=-1;i<=1;i++)
                {
                    for (int j = -1; j <= 1; j++)
                    {
                        if(i!=0 ||j!=0)
                        {
                            Piece pc = getPiece(x + i, y + j);
                            if (pc.getGenre() == GenrePiece.Lapin)
                            {
                                retour = false;
                                if(!plantesSauvent)
                                {
                                    return false;
                                }
                            }
                            else if(plantesSauvent && pc.getGenre() == GenrePiece.Herbe)
                            {
                                return true;
                            }
                            else if ((!plantesSauvent) && pc.getGenre() == GenrePiece.Herbe)
                            {
                                return false;
                            }
                        }
                    }
                }
                return retour;
            }
            public bool Deplacer(Point p1, Point p2, int joueur)
            {
                Piece pc1 = getPiece(p1.X,p1.Y);
                Piece pc2 = getPiece(p2.X, p2.Y);
                bool retour = false;
                if(!pc1.PieceVide && pc1.Joueur == joueur)
                {
                    bool manger = (!pc2.PieceVide) && (pc2.Joueur != pc1.Joueur) && ((pc1.getGenre() == GenrePiece.Loup && pc2.getGenre() == GenrePiece.Lapin) ||
                        (pc1.getGenre() == GenrePiece.Lapin && pc2.getGenre() == GenrePiece.Herbe));
                    if (pc2.PieceVide || manger)
                    {
                        Pieces[p1.X, p1.Y] = new Piece();
                        Pieces[p2.X, p2.Y] = pc1;
                        if(manger)
                        {
                            prises[pc1.Joueur].Add(pc2);
                        }
                        retour = true;
                    }
                }
                return retour;
            }
            public bool Placer(Point p1, int Joueur, GenrePiece genre)
            {
                if (Pieces[p1.X,p1.Y].PieceVide)
                {
                    bool ok = ((genre == GenrePiece.Lapin || genre == GenrePiece.Herbe) && Consommer(GenrePiece.Herbe, Joueur, 1)) ||
                        (genre == GenrePiece.Loup && Consommer(GenrePiece.Lapin, Joueur, 1));
                    if (ok)
                    {
                        Pieces[p1.X, p1.Y] = new Piece(genre, Joueur);
                    }
                    return ok;
                }
                else
                {
                    return false;
                }
            }
            public bool Sacrifier(Point p1,int Joueur)
            {
                Piece pc = getPiece(p1.X, p1.Y);
                if (pc.Joueur ==Joueur && pc.getGenre() == GenrePiece.Lapin)
                {
                    prises[Joueur].Add(pc);
                    Pieces[p1.X, p1.Y] = new Piece();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool DeplacementLegal(Point p1,Point p2)
            {
                GenrePiece gp = getPiece(p1.X, p1.Y).getGenre();
                if(gp==GenrePiece.Herbe || gp==GenrePiece.Vide)
                {
                    return false;
                }
                else if(gp == GenrePiece.Lapin)
                {
                    return Math.Max(Math.Abs(p1.X - p2.X), Math.Abs(p1.Y - p2.Y)) <= 1;
                }
                else if (gp == GenrePiece.Loup)
                {
                    int dist = 3;
                    if(! EntourageFavorable(p1.X,p1.Y,false))
                    {
                        dist = 1;
                    }
                    return (Math.Abs(p1.X - p2.X)<=dist) &&  (Math.Abs(p1.Y - p2.Y)== 0) || (Math.Abs(p1.Y - p2.Y) <= dist) && (Math.Abs(p1.X - p2.X) == 0) ||
                        (Math.Abs(p1.X - p2.X) <= dist) && (Math.Abs(p1.Y - p2.Y) == Math.Abs(p1.X - p2.X));
                }
                return false;
            }
            public bool Consommer(GenrePiece gp, int Joueur, int nb)
            {
                int nbConso = 0;
                List<Piece> newList = new List<Piece>();
                foreach(Piece pc in prises[Joueur])
                {
                    if(pc.getGenre()!= gp)
                    {
                        newList.Add(pc);
                    }
                    else
                    {
                        if(nbConso<nb)
                        {
                            nbConso++;
                        }
                        else
                        {
                            newList.Add(pc);
                        }
                    }
                }
                if(nbConso == nb)
                {
                    prises[Joueur] = newList;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public void MajLoups( int Joueur)
            {
                int nb = 0;

                for (int x = 0; x < X; x++)
                {
                    for (int y = 0; y < Y; y++)
                    {
                        Piece pc = getPiece(x, y);
                        if (pc.getGenre() == GenrePiece.Loup && pc.Joueur == Joueur)
                        {
                            nb += 1;
                        }
                    }
                }
                bool ok;
                ok = Consommer(GenrePiece.Lapin, Joueur, nb);
                if(!ok)
                {
                    for (int x = 0; x < X; x++)
                    {
                        for (int y = 0; y < Y; y++)
                        {
                            Piece pc = getPiece(x, y);
                            if (pc.getGenre() == GenrePiece.Loup)
                            {
                                if(pc.Joueur == Joueur)
                                {
                                    Pieces[x, y] = new Piece();
                                    prises[1 - pc.Joueur].Add(pc);
                                }
                            }
                        }
                    }
                }
            }
            public int[] nbPieces()
            {
                int[] nb = new int[2];
                nb[0] = 0;
                nb[1] = 0;
                for (int x = 0; x < X; x++)
                {
                    for (int y = 0; y < Y; y++)
                    {
                        Piece pc = getPiece(x, y);
                        if (!pc.PieceVide)
                        {
                            nb[pc.Joueur]++;
                        }
                    }
                }
                return nb;
            }
            public void donPlante(int Joueur)
            {
                prises[Joueur].Add(new Piece(GenrePiece.Herbe, Joueur));
            }
        }
        public enum GenrePiece { Loup,Lapin,Herbe,Vide };
        public class Piece
        {
            GenrePiece genre;
            public bool PieceVide;
            public int Joueur;
            public Piece()
            {
                PieceVide = true;
                Joueur = -1;
                genre = GenrePiece.Vide;
            }

            public Piece(GenrePiece genre, int joueur)
            {
                PieceVide = false;
                this.genre = genre;
                Joueur = joueur;
            }

            public bool Deplaceable(int JoueurActif)
            {
                return Joueur == JoueurActif && genre != GenrePiece.Herbe;
            }
            public GenrePiece getGenre()
            {
                return genre;
            }
        }

        private void MajPts(bool sync)
        {
            int[] pt = Plat.Points();
            if (!sync)
            {
                Points += pt[Joueur];
                Plat.donPlante(Joueur);
            }
            else
            {
                PointsAdv += pt[1 - Joueur];
                Plat.donPlante(1 - Joueur);
            }
        }
        private void Maj()
        {
            Affichage.Image = Plat.getBitmap(Affichage.Width, Affichage.Height,mouvCourant,Joueur,bpLoup,bpLapin,bpHerbe,chargementOK);
            pbPrises.Image = Plat.getBitmapPrises(pbPrises.Width, pbPrises.Height, Joueur, bpLoup, bpLapin, bpHerbe, chargementOK);
            labCoup.Text = "Coups : "+ (TailleSerie- nbSerie).ToString();
            labTour.Text = "Tour : " + NbTours.ToString();
            labScore.Text = "Votre Score : " + Points;
            labSoreAdv.Text = "Score Adversaire : " + PointsAdv;
            affMode();
        }
        private void Petrum_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageReciver.WorkerSupportsCancellation = true;
            MessageReciver.CancelAsync();
            if(Serveur != null)
            {
                Serveur.Stop();
            }
        }

        private void buttGO_Click(object sender, EventArgs e)
        {
            ActionGo();
        }
        private void ActionGo()
        {
            if (!Frozen)
            {
                if (mouvCourant.Pret(Plat, Joueur))
                {
                    Mouvement envoi = mouvCourant;
                    mouvCourant = new Mouvement(-1, -1, -1, -1);
                    mouvCourant.mode = choixMode.Value;
                    EnvoyerMouvement(envoi);
                }
                else
                {
                    Plat.SonErreur();
                }
            }
        }

        

        private void Affichage_Click(object sender, EventArgs e)
        {
            if (!Frozen)
            {
                MouseEventArgs me = (MouseEventArgs)e;
                Point coord = me.Location;
                double kx = coord.X / (double)Affichage.Width;
                double ky = coord.Y / (double)Affichage.Height;
                int x = (int)Math.Floor(kx * Plateau.X);
                int y = (int)Math.Floor(ky * Plateau.X);
                Console.WriteLine(x + " " + y);
                mouvCourant.Select(new Point(x,y),Plat);
                Maj();
            }
            else
            {
                Plat.SonErreur();
            }
            
        }
        private void affMode()
        {
            switch(choixMode.Value)
            {
                case 0:
                    labelMode.Text = "Deplacer";
                    break;
                case 1:
                    labelMode.Text = "Sacrifier";
                    break;
                case 2:
                    labelMode.Text = "Placer Lapin";
                    break;
                case 3:
                    labelMode.Text = "Placer Herbe";
                    break;
                case 4:
                    labelMode.Text = "Placer Loup";
                    break;
            }
        }

        private void choixMode_Scroll(object sender, EventArgs e)
        {
            actionScroll();
            
        }
        private void actionScroll()
        {
            mouvCourant.mode = choixMode.Value;
            Maj(); ;
        }
        void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.S)
            {
                ActionGo();
            }
            else if(e.KeyCode == Keys.D)
            {
                choixMode.Value = Math.Min(choixMode.Value + 1, choixMode.Maximum);
                actionScroll();
            }
            else if (e.KeyCode == Keys.Q)
            {
                choixMode.Value = Math.Max(choixMode.Value - 1, choixMode.Minimum);
                actionScroll();
            }
        }
    }
}
