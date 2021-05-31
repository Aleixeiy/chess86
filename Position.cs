using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess86
{
    public class Position
    {
        public char[,] position = new char[8, 8];
        public char who = 'w';
        public byte wlc = 1;
        public byte blc = 1;
        public byte wrc = 1;
        public byte brc = 1;
        public byte prohod = 9;

        public Position(char[,] pos)
        {
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    position[i, j] = pos[i, j];
        }

        public Position(Position position)
        {
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    this.position[i, j] = position.position[i, j];
            who = position.who;
            wlc = position.wlc;
            blc = position.blc;
            wrc = position.wrc;
            brc = position.brc;
            prohod = position.prohod;
        }

        public void set(char[,] pos)
        {
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    position[i, j] = pos[i, j];
        }

        public bool possibleMove(byte l1, byte n1, byte l2, byte n2, char who, byte lc, byte rc, byte prohod)
        {
            _moves moves = Moves.getMoves(this.position, who, lc, rc, prohod);
            for (int i = 0; i < moves.n; i++)
                if ((l1 == moves.moves[i].l1) && (n1 == moves.moves[i].n1) &&
                    (l2 == moves.moves[i].l2) && (n2 == moves.moves[i].n2))
                    return true;
            return false;
        }

        public void move(byte l1, byte n1, byte l2, byte n2)
        {
            move(l1, n1, l2, n2, '\0');
        }

        public void move(byte l1, byte n1, byte l2, byte n2, char f)
        {
            prohod = 9;
            if (((position[l1, n1] == 'p') || (position[l1, n1] == 'P')) && (position[l2, n2] == '\0') && (l1 != l2))
                position[l2, n1] = '\0'; // убрать пешку на проходе

            if (((position[l1, n1] != 'k') && (position[l1, n1] != 'K')) || (Math.Abs(l2 - l1) < 2))
            {
                if (position[l1, n1] == 'k') { wlc = 0; wrc = 0; }
                else
                if (position[l1, n1] == 'K') { blc = 0; brc = 0; }
                else
                if ((position[l1, n1] == 'r') && (l1 == 0) && (n1 == 0)) { wlc = 0; }
                else
                if ((position[l1, n1] == 'r') && (l1 == 7) && (n1 == 0)) { wrc = 0; }
                else
                if ((position[l1, n1] == 'R') && (l1 == 0) && (n1 == 7)) { blc = 0; }
                else
                if ((position[l1, n1] == 'R') && (l1 == 7) && (n1 == 7)) { brc = 0; }
                else
                if ((position[l1, n1] == 'p') && (Math.Abs(n1 - n2) == 2)) { prohod = l1; }
                else
                if ((position[l1, n1] == 'P') && (Math.Abs(n1 - n2) == 2)) { prohod = l1; }

                if (f == '\0')
                    position[l2, n2] = position[l1, n1];
                else
                    position[l2, n2] = f;
                position[l1, n1] = '\0';
            }
            else
            {
                char who;
                if (position[l1, n1] == 'k') { who = 'w'; wlc = 0; wrc = 0; }
                                        else { who = 'b'; blc = 0; brc = 0; }

                position[l2, n2] = position[l1, n1];
                position[l1, n1] = '\0';
                if ((who == 'w') && (l2 - l1 > 0))
                {
                    position[5, 0] = position[7, 0];
                    position[7, 0] = '\0';
                }
                else
                if ((who == 'w') && (l2 - l1 < 0))
                {
                    position[3, 0] = position[0, 0];
                    position[0, 0] = '\0';
                }
                else
                if ((who == 'b') && (l2 - l1 > 0))
                {
                    position[5, 7] = position[7, 7];
                    position[7, 7] = '\0';
                }
                else
                if ((who == 'b') && (l2 - l1 < 0))
                {
                    position[3, 7] = position[0, 7];
                    position[0, 7] = '\0';
                }
            }
            if (who == 'w') who = 'b'; else who = 'w';
        }

        public int getMark()
        {
            int wm = 0;
            int bm = 0;
            for (byte i = 0; i <= 7; i++)
                for (byte j = 0; j <= 7; j++)
                    switch (position[i, j])
                    {
                        case 'p':
                            {
                                wm += 10 + j - 1;
                            }
                            break;
                        case 'n':
                            {
                                wm += 28;
                            }
                            break;
                        case 'b':
                            {
                                wm += 32;
                            }
                            break;
                        case 'r':
                            {
                                wm += 50;
                            }
                            break;
                        case 'q': wm += 90; break;

                        case 'P':
                            {
                                bm += 10 + 7 - j;
                            }
                            break;
                        case 'N':
                            {
                                bm += 28;
                            }
                            break;
                        case 'B':
                            {
                                bm += 32;
                            }
                            break;
                        case 'R':
                            {
                                bm += 50;
                            }
                            break;
                        case 'Q': bm += 90; break;
                    }

            return wm - bm;
        }

        public int isMatePate()
        {
            int all;
            if (who == 'w')
                all = Moves.getMovesIs(position, who, wlc, wrc, prohod);
            else
                all = Moves.getMovesIs(position, who, wlc, wrc, prohod);
            if (all == 0)
            {
                int res = Moves.good(position, 0, 0, 0, 0, who);
                if (res == 1) return 1;
                if (res == 0) return 2;
            }
            return 0;
        }

    }
}
