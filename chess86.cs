using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using MySql.Data.MySqlClient;

namespace chess86
{
    public struct Field
    {
        public bool exist;
        public byte l;
        public byte n;
        public Field(bool exist, byte l, byte n)
        {
            this.exist = exist;
            this.l = l;
            this.n = n;
        }
    }

    public struct bestMove
    {
        public move move;
        public int mark;
        public bestMove(move move, int mark)
        {
            this.move = move;
            this.mark = mark;
        }
    }

    public struct _marks
    {
        public int[] marks;
        public bool marksIs;
    }

    public partial class chess86 : Form
    {
        
        public static char[,] startPosition = {
        {'r', 'p', '\0', '\0', '\0', '\0', 'P', 'R'},
        {'n', 'p', '\0', '\0', '\0', '\0', 'P', 'N'},
        {'b', 'p', '\0', '\0', '\0', '\0', 'P', 'B'},
        {'q', 'p', '\0', '\0', '\0', '\0', 'P', 'Q'},
        {'k', 'p', '\0', '\0', '\0', '\0', 'P', 'K'},
        {'b', 'p', '\0', '\0', '\0', '\0', 'P', 'B'},
        {'n', 'p', '\0', '\0', '\0', '\0', 'P', 'N'},
        {'r', 'p', '\0', '\0', '\0', '\0', 'P', 'R'}
        };
        public Board board = new Board(0, 10, 0);
        public Position position = new Position(startPosition);
        public char playerColor = 'w';
        public Field activeField = new Field(false, 0, 0);
        NetworkStream stream;
        public int t1 = 180000;
        public int t2 = 180000;
        public long start = 0;
        public long finish = 0;
        public string name = "";
        public string oppName = "";
        public string record = "";

        bool play = false;
        bool wait = false;
        int dep = 0;
        int kolv = 0;
        Thread analiz = null;
        Thread a = null;
        Thread r = null;
        bool change = false;
        _marks marks;

        static TcpClient client;
        IPAddress localAddr = IPAddress.Parse("0.0.0.0");
        int port = 8888;
        TcpListener server;

        public chess86()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            board.posX = chat.Location.X + chat.Width + 10;
            board.square = (panelRight.Location.X - board.posX) / 8;
            server = new TcpListener(localAddr, port);
        }

        private void chess86_Paint(object sender, PaintEventArgs e)
        {
            //Image board = new Bitmap("pic\\board.bmp");
            e.Graphics.DrawImage(board.img, board.posX, board.posY, board.square * 8, board.square * 8);
        ////////////////////////////////////////////////// отрисовка фигур
            for (byte i = 0; i <= 7; i++)
                for (byte j = 0; j <= 7; j++)
                    if (position.position[i, j] != '\0')
                    {
                        if (!((activeField.exist) && (activeField.l == i) && (activeField.n == j)))
                        {
                            char l1, l2, l3;
                            if ((i + j) % 2 == 0) l1 = 'b';
                            else
                                l1 = 'w';
                            if ((position.position[i, j] >= 'a') && (position.position[i, j] <= 'z')) l2 = 'w';
                            else
                                l2 = 'b';
                            l3 = position.position[i, j];

                            string s = "pic\\" + l1 + l2 + l3 + ".bmp";

                            Image figure = new Bitmap(s);
                            int x1 = 0, x2 = board.square, y1 = 0, y2 = board.square;
                            if (playerColor == 'w')
                            {
                                x1 = board.posX + i * board.square;
                                y1 = board.posY + board.square * 7 - (j * board.square);
                            }
                            else
                            {
                                x1 = board.posX + (7 - i) * board.square;
                                y1 = board.posY + board.square * 7 - ((7 - j) * board.square);
                            }
                            e.Graphics.DrawImage(figure, x1, y1, x2, y2);
                        }
                    }
            //активная фигура
            if ((activeField.exist) && (position.position[activeField.l, activeField.n] != '\0'))
            {
                int i = activeField.l;
                int j = activeField.n;
                char l2, l3;
                if ((position.position[i, j] >= 'a') && (position.position[i, j] <= 'z')) l2 = 'w';
                else
                    l2 = 'b';
                l3 = position.position[i, j];

                string s = "pic\\" + l2 + l3 + ".png";

                Image figure = new Bitmap(s);

                int x1 = 0, x2 = 80, y1 = 0, y2 = 80;
                switch (l3)
                {
                    case 'p': { x2 = 40; y2 = 52; } break;
                    case 'P': { x2 = 40; y2 = 52; } break;
                    case 'n': { x2 = 54; y2 = 54; } break;
                    case 'N': { x2 = 54; y2 = 54; } break;
                    case 'b': { x2 = 55; y2 = 56; } break;
                    case 'B': { x2 = 55; y2 = 56; } break;
                    case 'r': { x2 = 46; y2 = 52; } break;
                    case 'R': { x2 = 46; y2 = 52; } break;
                    case 'q': { x2 = 62; y2 = 57; } break;
                    case 'Q': { x2 = 62; y2 = 57; } break;
                    case 'k': { x2 = 56; y2 = 57; } break;
                    case 'K': { x2 = 56; y2 = 57; } break;
                }
                
                float k = (float)4/3 * board.square / 80;
                x2 = (int)((float)x2 * k);
                y2 = (int)((float)y2 * k);
                x1 = Cursor.Position.X - this.Location.X - 9;
                y1 = Cursor.Position.Y - this.Location.Y - 31;
                x1 -= x2 / 2;
                y1 -= y2 / 2;

                e.Graphics.DrawImage(figure, x1, y1, x2, y2);
            }
        ////////////////////////////////////////////////// отрисовка фигур
        }

        private void chess86_MouseDown(object sender, MouseEventArgs e)
        {
            //захват фигуры
            if (!activeField.exist)
            {
                int x = Cursor.Position.X - this.Location.X - 9;
                int y = Cursor.Position.Y - this.Location.Y - 31;
                x -= board.posX;
                y -= board.posY;
                x /= board.square;
                y /= board.square;
                y = 7 - y;
                if (playerColor == 'b')
                {
                    x = 7 - x;
                    y = 7 - y;
                }

                if ((x >= 0) && (x <= 7) && (y >= 0) && (y <= 7) 
                    && (position.position[x, y] != '\0'))
                {
                    activeField.exist = true;
                    activeField.l = (byte)x;
                    activeField.n = (byte)y;
                    Invalidate();
                }
            }
        }

        private void chess86_MouseUp(object sender, MouseEventArgs e)
        {
            //отпустить фигуру
            if (activeField.exist)
            {
                int x = Cursor.Position.X - this.Location.X - 9;
                int y = Cursor.Position.Y - this.Location.Y - 31;
                x -= board.posX;
                y -= board.posY;
                x /= board.square;
                y /= board.square;
                y = 7 - y;
                if (playerColor == 'b')
                {
                    x = 7 - x;
                    y = 7 - y;
                }

                byte lc = position.who == 'w' ? position.wlc : position.blc;
                byte rc = position.who == 'b' ? position.wrc : position.brc;
                if (((x >= 0) && (x <= 7) && (y >= 0) && (y <= 7) &&
                    ((x != activeField.l) || (y != activeField.n)) && 
                    ((playerColor == position.who) || (!play))) &&
                    (position.possibleMove(activeField.l, activeField.n, (byte)x, (byte)y, position.who, lc, rc, position.prohod)))
                {
                    if (((position.position[activeField.l, activeField.n] == 'p') ||
                         (position.position[activeField.l, activeField.n] == 'P')) &&
                         ((y == 7) || (y == 0)))
                    {
                        Form8 form8 = new Form8(activeField.l, activeField.n, (byte)x, (byte)y);
                        form8.FormClosed += new FormClosedEventHandler(form8_Closed);
                        form8.ShowDialog();
                        return;
                    }

                    position.move(activeField.l, activeField.n, (byte)x, (byte)y);
                    this.Refresh();
                    record += (char)(activeField.l + 'a');
                    record += (char)(activeField.n + '1');
                    record += (char)(x + 'a');
                    record += (char)(y + '1');
                    record += " ";
                    if (position.who == 'w') record += "\r\n";
                    textBoxRecord.Text = record;
                    textBoxRecord.Refresh();
                    change = true;
                    string move = "m";
                    move += (char)activeField.l;
                    move += (char)activeField.n;
                    move += (char)x;
                    move += (char)(y);
                    string t = t1.ToString();
                    if (play) send(move + t);
                }
            }
            activeField.exist = false;
            Invalidate();
        }

        private void form8_Closed(object sender, FormClosedEventArgs e)
        {
            Form8 form8 = (Form8)sender;
            if (position.who == 'b') form8.f = char.ToUpper(form8.f);
            position.move(form8.l1, form8.n1, form8.l2, form8.n2, form8.f);
            record += (char)(form8.l1 + 'a');
            record += (char)(form8.n1 + '1');
            record += (char)(form8.l2 + 'a');
            record += (char)(form8.n2 + '1');
            record += form8.f;
            record += " ";
            if (position.who == 'w') record += "\r\n";
            textBoxRecord.Text = record;
            textBoxRecord.Refresh();
            change = true;
            string move = "m";
            move += (char)form8.l1;
            move += (char)form8.n1;
            move += (char)form8.l2;
            move += (char)form8.n2;
            move += form8.f;
            string t = t1.ToString();
            if (play) send(move + t);
        }

        private void chess86_MouseMove(object sender, MouseEventArgs e)
        {
            Invalidate();
        }

        private void send(string s)
        {
            if (isMessage(s)) s = name + ": " + s;
            byte[] data = Encoding.UTF8.GetBytes(s);
            try
            {
                stream.Write(data, 0, data.Length);
                if (isMessage(s)) chat.Text += s + "\r\n";
                Thread.Sleep(100);
            }
            catch
            {
                toChat("Не удалось отправить(");
            }
        }

        private bool isMoveTime(string message)
        {
            if ((message[0] == 'm') &&
                (message[1] <= 7) && (message[1] >= 0) &&
                (message[2] <= 7) && (message[2] >= 0) &&
                (message[3] <= 7) && (message[3] >= 0) &&
                (message[4] <= 7) && (message[4] >= 0)) return true;
            return false;
        }

        private bool isName(string message)
        {
            if ((message[0] == 'n') && (message[1] == '1')) 
                return true;
            return false;
        }

        private bool isResult(string message)
        {
            if ((message[0] == 'r') && (message[1] == '1')) return true;
            return false;
        }

        private bool isDraw(string message)
        {
            if ((message[0] == 'o') && (message[1] == 'd') && (message[2] == '1')) return true;
            return false;
        }

        private bool isResign(string message)
        {
            if ((message[0] == 'o') && (message[1] == 'r') && (message[2] == '1')) return true;
            return false;
        }

        private bool isColorTime(string message)
        {
            if ((message[0] == 'c') && ((message[1] == 'w') || (message[1] == 'b'))) return true;
            return false;
        }

        private bool isMessage(string message)
        {
            if ((!isMoveTime(message)) && 
                (!isColorTime(message)) && 
                (!isDisconnect(message)) &&
                (!isName(message)) &&
                (!isResult(message)) &&
                (!isDraw(message)) &&
                (!isResign(message))) return true;
            return false;
        }

        private bool isDisconnect(string message)
        {
            if ((message[0] == 'd') && (message[1] == '1')) return true;
            return false;
        }

        private void toChat(string text)
        {
            if (InvokeRequired)
                Invoke((Action<string>)toChat, text);
            else
            {
                int i = 0;
                for (; (i < text.Length) && (text[i] != '\0'); i++);
                text = text.Insert(i, "\r\n");
                chat.Text += text;
            }
        }

        private void toTextBox(TextBox textBox, string text)
        {
            if (InvokeRequired)
                Invoke((Action<TextBox, string>)toTextBox, textBox, text);
            else
            {
                textBox.Text = text;
                textBox.Refresh();
            }
        }

        private void closeAll()
        {
            try
            {
                if (client != null) client.Close();
                server.Stop();
                play = false;
                if (analiz != null) analiz.Abort();
                analiz = new Thread(goAnaliz);
                analiz.Start();
            }
            catch
            {

            }
        }

        private void receive()
        {
            while (true)
            {
                byte[] data = new byte[1024];
                try
                {
                    stream.Read(data, 0, data.Length);
                }
                catch
                {
                    closeAll();
                    return;
                }
                string message = Encoding.UTF8.GetString(data);
                if (isMoveTime(message))
                {
                    lock (position) 
                    {
                        char l1 = message[1];
                        char n1 = message[2];
                        char l2 = message[3];
                        char n2 = message[4];
                        char f = '\0';
                        if ((message[5] < '0') || (message[5] > '9')) 
                            f = message[5];
                        position.move((byte)l1, (byte)n1, (byte)l2, (byte)n2, f);
                        record += (char)(l1 + 'a');
                        record += (char)(n1 + '1');
                        record += (char)(l2 + 'a');
                        record += (char)(n2 + '1');
                        if (f != '\0') record += f;
                        record += " ";
                        if (position.who == 'w') record += "\r\n";
                        toTextBox(textBoxRecord, record);

                        /////////////////время соперника
                        string t;
                        if (f == '\0') t = message.Substring(5); else
                            t = message.Substring(6);

                        t2 = Convert.ToInt32(t);
                        lock (timeOpponent) { setTime(t2, timeOpponent); }
                        /////////////////время соперника
                        start = DateTime.Now.Ticks;
                        if (position.isMatePate() == 1)
                        {
                            Result result = new Result(1, name);
                            send("r1" + "1");
                            send("d1");
                            closeAll();
                            result.ShowDialog();
                        } else
                        if (position.isMatePate() == 2)
                        {
                            Result result = new Result(0, name);
                            send("r1" + "0");
                            send("d1");
                            closeAll();
                            result.ShowDialog();
                        }
                        Invalidate();
                    }
                } 
                else
                    if (isColorTime(message))
                    {
                    start = 0;
                    playerColor = message[1];
                    position.who = 'w';
                    string t = message.Substring(2);
                    t1 = Convert.ToInt32(t);
                    t2 = t1;
                    lock (timeOpponent)
                    {
                        setTime(t1, timeYou);
                        setTime(t2, timeOpponent);
                    }
                    Invalidate();
                    } 
                else
                    if (isDisconnect(message))
                    {
                    closeAll();
                    return;
                    }
                else
                    if (isName(message))
                    {
                        if (oppName == "")
                        {
                            oppName = message.Substring(2);
                            toLabel(labelOpponent, oppName);
                            send("n1" + name);
                        }
                    }
                else
                    if (isResult(message))
                    {
                    Result result;
                    if (message[2] == '0') result = new Result(2, name); else
                    if (message[2] == '1') result = new Result(1, name); else
                    result = new Result(0, name);
                    send("d1");
                    closeAll();
                    result.ShowDialog();
                    }
                else
                    if (isDraw(message))
                    {
                    Draw draw = new Draw();
                    draw.FormClosed += new FormClosedEventHandler(Draw_closed);
                    draw.ShowDialog();
                    }
                else
                    if (isResign(message))
                    {
                    Result result = new Result(2, name);
                    send("d1");
                    closeAll();
                    result.ShowDialog();
                    }
                else
                toChat(message);
            }
        }

        private void Draw_closed(object sender, FormClosedEventArgs args)
        {
            bool d = ((Draw)sender).draw;
            if (d)
            {
                Result result = new Result(1, name);
                send("r1" + "1");
                send("d1");
                closeAll();
                result.ShowDialog();
            }
        }

        private void btnServer_Click(object sender, EventArgs e)
        {
            if (!play)
            {
                GameSetting setting = new GameSetting();
                setting.Show();
                setting.FormClosed += new FormClosedEventHandler(GameSetting_closed);
            }
        }

        private void GameSetting_closed(object sender, FormClosedEventArgs args)
        {
            playerColor = ((GameSetting)sender).color;
            t1 = ((GameSetting)sender).minute * 60000;
            t2 = t1;
            setTime(t1, timeYou);
            setTime(t2, timeOpponent);
            if (!wait)
            {
                a = new Thread(accept);
                a.Start();
                wait = true;
            }
        }

        private void accept()
        {
            try
            {
                server.Start();
                client = server.AcceptTcpClient();
                start = 0;
                position.who = 'w';
                wait = false;
                play = true;
                record = "";
                position.set(startPosition);
                stream = client.GetStream();
                ////////////////отправка имени
                send("n1" + name);
                ////////////////отправка имени
                
                ////////////////отправка цвета и контроля
                string color = "c";
                if (playerColor == 'w') color += 'b'; else color += 'w';
                string time = "";
                time += t1.ToString();

                send(color + time);
                ////////////////отправка цвета и контроля
                if (r != null) r.Abort();
                r = new Thread(receive);
                r.Start();
            }
            catch
            {
                toChat("Вероятно, порт занят(");
                wait = false;
            }
        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            try
            {
                server.Stop();
                client = new TcpClient();
                client.Connect(textBoxIP.Text, port);
                play = true;
                position.set(startPosition);
                record = "";
                stream = client.GetStream();
                if (r != null) r.Abort();
                r = new Thread(receive);
                r.Start();
                if (a != null) a.Abort();
            }
            catch
            {
                chat.Text += "Не удалось подключиться" + "\r\n";
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            send(textBoxM.Text);
            textBoxM.Text = "";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if ((t1 <= 0) && (play))
            {
                Result result = new Result(0, name);
                send("r1" + "0");
                send("d1");
                closeAll();
                result.ShowDialog();
            }

            if (play)
            if (position.who == playerColor)
            {
                finish = DateTime.Now.Ticks;
                long t = finish - start;
                if (start == 0) t = 0;
                t1 -= (int)t / 10000;
                setTime(t1, timeYou);
                start = finish;
            }
                else
                {
                    finish = DateTime.Now.Ticks;
                    long t = finish - start;
                    if (start == 0) t = 0;
                    t2 -= (int)t / 10000;
                    setTime(t2, timeOpponent);
                    start = finish;
                }
        }

        private void toLabel(Label label, string text)
        {
            if (InvokeRequired)
                Invoke((Action<Label, string>)toLabel, label, text);
            else
            {
                label.Text = text;
                label.Refresh();
            }
        }

        private void setTime(int time, Label t)
        {
            int min = time / 60000;
            int sec = (time - min * 60000) / 1000;
            string minS = min.ToString();
            string secS = sec.ToString();
            if (sec < 10) secS = "0" + secS;
            toLabel(t, minS + ":" + secS);
        }

        private void chess86_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (play)
            {
                Result result = new Result(0, name);
                send("r1" + "0");
                send("d1");
                closeAll();
                result.ShowDialog();
            }
            try
            {
                if (play) send("d1");
                server.Stop();
                if (client != null) client.Close();
                try
                {
                    if (analiz != null) analiz.Abort();
                }
                catch
                {

                }
                try
                {
                    if (a != null) a.Abort();
                }
                catch
                {

                }

                if (r != null) r.Abort();
            } 
            catch
            {

            }
        }

        private void chess86_ResizeEnd(object sender, EventArgs e)
        {
            board.posX = chat.Location.X + chat.Width + 10;
            board.square = (panelRight.Location.X - board.posX) / 8;
            if (board.square > 98) board.square = 98;
            if (this.Height < board.posY + board.square * 8 + 40)
                this.Height = board.posY + board.square * 8 + 40;
            Invalidate();
        }

        private void chess86_Load(object sender, EventArgs e)
        {
            this.Visible = false;
            StartForm sf = new StartForm();
            sf.FormClosed += new FormClosedEventHandler(sf_Closed);
            sf.ShowDialog();
            analiz = new Thread(goAnaliz);
            analiz.Start();
        }

        private void sf_Closed(object sender, FormClosedEventArgs e)
        {
            StartForm sf = (StartForm)sender;
            if (sf.name == "") this.Close();
            name = sf.name;
            labelYou.Text = name;
            try
            {
                this.Visible = true;
            }
            catch
            {

            }
        }

        private void goAnaliz()
        {
            try
            {
                if (play)
                {
                    toLabel(textMark, "");
                    toLabel(textDepth, "");
                    toLabel(textBest, "");
                    return;
                }

                bestMove move;

                if (position.who == 'w') move = getComputerMove(new Position(position), 0, 1000000);
                else
                    move = getComputerMove(new Position(position), 0, -1000000);

                double m = (double)move.mark / 10;
                toLabel(textMark, "Оценка: " + m.ToString());
                string bm = "Лучший: ";
                bm += (char)(move.move.l1 + 'a');
                bm += (char)(move.move.n1 + '1');
                bm += (char)(move.move.l2 + 'a');
                bm += (char)(move.move.n2 + '1');
                toLabel(textBest, bm);

                if (change)
                {
                    dep = 0;
                    marks.marksIs = false;
                }
                else
                    if (dep < 100)
                    dep++;
                toLabel(textDepth, "Глубина: " + dep.ToString());

                if (Math.Abs(m) > 1000)
                    while (!change) ;
                change = false;

                goAnaliz();
            }
            catch
            {

            }
        }

        public bestMove getComputerMove(Position position, int depth, int prevMark)
        {
            byte lc = position.who == 'w' ? position.wlc : position.blc;
            byte rc = position.who == 'w' ? position.wrc : position.brc;
            _moves all = Moves.getMoves(position.position, position.who, lc, rc, position.prohod);
            
            int[] nums = new int[all.n];
            for (int i = 0; i < all.n; i++)
                nums[i] = i;
            if ((marks.marksIs) && (depth == 0))
                try
                {
                    sort(ref all, ref marks, position.who, ref nums);
                }
                catch
                {

                }
            if (all.n == 0)
            {
                kolv++;
                bestMove best1 = new bestMove(new move(), 0);
                int res = position.isMatePate();
                if (res == 2)
                {
                    if (position.who == 'w') best1.mark = -1000000;
                    if (position.who == 'b') best1.mark = 1000000;
                    return best1;
                }
                if (res == 1)
                {
                    best1.mark = 0;
                    return best1;
                }
            }

            bestMove best;
            best.move = all.moves[0];
            if (position.who == 'w') best.mark = -1000000;
            else
                best.mark = 1000000;

            if (depth == 0) marks.marks = new int[all.n];
            for (int k = 0; k <= all.n - 1; k++)
            {
            if (change) return best;
                byte l1 = all.moves[k].l1;
                byte n1 = all.moves[k].n1;
                byte l2 = all.moves[k].l2;
                byte n2 = all.moves[k].n2;
                char f = all.moves[k].f;
                bool beat = false;
                if (position.position[l2, n2] != '\0') beat = true;

            Position temp = new Position(position);

                position.move(l1, n1, l2, n2, f);

                int newMark;
                    
                bestMove b;
                if ((depth < dep) || ((depth < dep + 20) && (beat)))
                {
                    if (depth > 20)
                    {
                        int y = 0;
                    }
                    b = getComputerMove(position, depth + 1, best.mark);
                    newMark = b.mark;
                }
                else
                newMark = position.getMark();

                if (newMark == 1000000)
                    newMark = 1000000 - depth;
                else
                if (newMark == -1000000)
                    newMark = -1000000 + depth;

                position = temp;

            if (depth == 0)
            {
                marks.marks[nums[k]] = newMark;
            }

            if ((position.who == 'w') && (newMark > best.mark))
                {
                    best.mark = newMark;
                    best.move = all.moves[k];
                    if (newMark >= prevMark)
                        return best;
                }

                if ((position.who == 'b') && (newMark < best.mark))
                {
                    best.mark = newMark;
                    best.move = all.moves[k];
                    if (newMark <= prevMark)
                        return best;
                }

                /////////////////////обновление оценки
                if  (depth == 0)
                {
                    double m = (double)best.mark / 10;
                    toLabel(textMark, "Оценка: " + m.ToString());
                    string bm = "Лучший: ";
                    bm += (char)(best.move.l1 + 'a');
                    bm += (char)(best.move.n1 + '1');
                    bm += (char)(best.move.l2 + 'a');
                    bm += (char)(best.move.n2 + '1');
                    toLabel(textBest, bm);
                }
                /////////////////////обновление оценки

                /////////////////////обновление глубины
                if ((depth == 0) && (all.n != 0))
                {
                    int p = (int)Math.Round(100 * (double)(k + 1) / all.n);
                    if (p >= 10)
                    toLabel(textDepth, "Глубина: " + dep.ToString() + "," + p.ToString()); else
                    toLabel(textDepth, "Глубина: " + dep.ToString() + "," + "0" + p.ToString());
                }
                /////////////////////обновление глубины
                

            }

            if (depth == 0)
            {
                for (int i = 0; i < all.n; i++)
                    if ((all.moves[i].l1 == best.move.l1) && (all.moves[i].n1 == best.move.n1) &&
                        (all.moves[i].l2 == best.move.l2) && (all.moves[i].n2 == best.move.n2))
                        if (position.who == 'w') marks.marks[nums[i]]++; else marks.marks[nums[i]]--;
                marks.marksIs = true;
            }

            return best;
              
        }

        private void sort(ref _moves all, ref _marks marks, char who, ref int[]nums)
        {
            for (int i = 0; i < all.n; i++)
                for (int j = 0; j < all.n - 1; j++)
                    if (((marks.marks[j] > marks.marks[j + 1]) && (who == 'b')) ||
                        ((marks.marks[j] < marks.marks[j + 1]) && (who == 'w')))
                    {
                        int temp = marks.marks[j];
                        marks.marks[j] = marks.marks[j + 1];
                        marks.marks[j + 1] = temp;

                        move tm = all.moves[j];
                        all.moves[j] = all.moves[j + 1];
                        all.moves[j + 1] = tm;

                        int tn = nums[j];
                        nums[j] = nums[j + 1];
                        nums[j + 1] = tn;
                    }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (play)
            {
                send("or1");
                Result result = new Result(0, name);
                closeAll();
                result.ShowDialog();
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!play)
            {
                position = new Position(startPosition);
                this.Refresh();
                record = "";
                textBoxRecord.Text = record;
                textBoxRecord.Refresh();
            }
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            if (play)
                send("od1");
        }

        private void btnRecord_Click(object sender, EventArgs e)
        {
            Save save = new Save(record);
            save.ShowDialog();
        }

        private void btnStatistics_Click(object sender, EventArgs e)
        {

            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                string sql = "SELECT * FROM players WHERE name = '" + name + "';";
                MySqlCommand sqlCom = new MySqlCommand(sql, conn);
                conn.Open();
                sqlCom.ExecuteNonQuery();
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(sqlCom);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);

                var myData = dt.Select();
                foreach (var row in myData)
                    try
                    {
                        int win = (int)row.ItemArray[2];
                        int draw = (int)row.ItemArray[3];
                        int lose = (int)row.ItemArray[4];
                        Statistics st = new Statistics(win, draw, lose);
                        st.ShowDialog();
                        return;
                    }
                    catch
                    {
                    }
            }
            catch
            {
                MessageBox.Show("Не удалось соедениться с базой данных.");
            }

        }
    }
}
