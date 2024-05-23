using System.Drawing.Drawing2D;

namespace balon_prvi
{
    public partial class Form1 : Form
    {
        Graphics g;

        int x, y, a = 20;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;

            //Crtam elipsu
            g.FillEllipse(Brushes.Yellow, x - 3 * a, y - 8 * a, 6 * a, 8 * a);

            //Ctam cvor
            byte[] tip_tacke = new byte[3]; //Ovo indikuje da li su linije, isprekidane linije itd
            tip_tacke[0] = (byte)1;//1 znaci da su linije
            tip_tacke[1] = (byte)1;
            tip_tacke[2] = (byte)1;
            Point[] tacke = new Point[3];//Ovo predstavlja tri coska trougla
            tacke[0] = new Point(x, y);
            tacke[1] = new Point(x - a, y + a);
            tacke[2] = new Point(x + a, y + a);
            GraphicsPath p = new GraphicsPath(tacke, tip_tacke);//Ovo je trougao
            g.FillPath(Brushes.Magenta, p);//Ovo izcrtava torugao

            Point[] tacke2 = new Point[2];
            tacke2[0] = new Point(x, y + a);
            tacke2[1] = new Point(x - a, y + 2 * a);
            g.DrawLine(Pens.Cyan, tacke2[0], tacke2[1]);

            Point[] tacke3 = new Point[2];
            tacke3[0] = new Point(x - a, y + 2 * a);
            tacke3[1] = new Point(x + a, y + 3 * a);
            g.DrawLine(Pens.Cyan, tacke3[0], tacke3[1]);

            Point[] tacke4 = new Point[2];
            tacke4[0] = new Point(x + a, y + 3 * a);
            tacke4[1] = new Point(x - a, y + 4 * a);
            g.DrawLine(Pens.Cyan, tacke4[0], tacke4[1]);

            Point[] tacke5 = new Point[2];
            tacke5[0] = new Point(x - a, y + 4 * a);
            tacke5[1] = new Point(x + a, y + 5 * a);
            g.DrawLine(Pens.Cyan, tacke5[0], tacke5[1]);
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            this.Size = new Size(800, 600);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            g = this.CreateGraphics();  //MSDN dokumentacija kaze da je ovo pozeljno da bude ovde
            this.Size = new Size(800, 600);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            g.Dispose(); //MSDN preporucuje da se ovo stavi ovde (nije neophodno zato sto postoji garbage collector ali je pozeljno)
        }
    }
}
