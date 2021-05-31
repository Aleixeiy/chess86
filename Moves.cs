using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess86
{
    public struct move
    {
        public byte l1;
        public byte n1;
        public byte l2;
        public byte n2;
        public char f;

        public move(byte l1, byte n1, byte l2, byte n2, char f)
        {
            this.l1 = l1;
            this.n1 = n1;
            this.l2 = l2;
            this.n2 = n2;
            this.f = f;
        }
    };

    public struct _moves
    {
        public move[] moves;
        public int n;
    };

    class Moves
    {
        public static int similar(char [,]p1, char [,]p2)
        {
            for (byte i = 0; i <= 7; i++)
                for (byte j = 0; j <= 7; j++)
                    if (p1[i, j] != p2[i, j]) return 0;
            return 1;
        }

        public static int possible(char field, char wb)
        {
            if ((wb == 'w') && (field >= 'a') && (field <= 'z')) return 0;
            if ((wb == 'b') && (field >= 'A') && (field <= 'Z')) return 0;
            return 1;
        }

        public static int another(char field, char wb)
        {
            if ((wb == 'w') && (field >= 'A') && (field <= 'Z')) return 1;
            if ((wb == 'b') && (field >= 'a') && (field <= 'z')) return 1;
            return 0;
        }

        public static int similar(char l, char wb)
        {
            if ((wb == 'w') && (l >= 'a') && (l <= 'z')) return 1;
            if ((wb == 'b') && (l >= 'A') && (l <= 'Z')) return 1;
            return 0;
        }

        public static int attake(char [,]pos, byte l, byte n, char wb)
        {
            char kn, b, r, q, k;
            if (wb == 'w')
            {
                kn = 'n';
                b = 'b';
                r = 'r';
                q = 'q';
                k = 'k';
            }
            else
            {
                kn = 'N';
                b = 'B';
                r = 'R';
                q = 'Q';
                k = 'K';
            }

            if ((l + 2 <= 7) && (n + 1 <= 7) && (pos[l + 2, n + 1] == kn)) return 1;
            if ((l + 2 <= 7) && (n - 1 >= 0) && (pos[l + 2, n - 1] == kn)) return 1;
            if ((l - 2 >= 0) && (n + 1 <= 7) && (pos[l - 2, n + 1] == kn)) return 1;
            if ((l - 2 >= 0) && (n - 1 >= 0) && (pos[l - 2, n - 1] == kn)) return 1;
            if ((l + 1 <= 7) && (n + 2 <= 7) && (pos[l + 1, n + 2] == kn)) return 1;
            if ((l + 1 <= 7) && (n - 2 >= 0) && (pos[l + 1, n - 2] == kn)) return 1;
            if ((l - 1 >= 0) && (n + 2 <= 7) && (pos[l - 1, n + 2] == kn)) return 1;
            if ((l - 1 >= 0) && (n - 2 >= 0) && (pos[l - 1, n - 2] == kn)) return 1;

            if ((l + 1 <= 7) && (n + 1 <= 7) && (pos[l + 1, n + 1] == k)) return 1;
            if ((l + 1 <= 7) && (n - 1 >= 0) && (pos[l + 1, n - 1] == k)) return 1;
            if ((l - 1 >= 0) && (n + 1 <= 7) && (pos[l - 1, n + 1] == k)) return 1;
            if ((l - 1 >= 0) && (n - 1 >= 0) && (pos[l - 1, n - 1] == k)) return 1;
            if ((l + 1 <= 7) && (pos[l + 1, n] == k)) return 1;
            if ((l - 1 >= 0) && (pos[l - 1, n] == k)) return 1;
            if ((n + 1 <= 7) && (pos[l, n + 1] == k)) return 1;
            if ((n - 1 >= 0) && (pos[l, n - 1] == k)) return 1;

            if (wb == 'b')
            {
                if ((l + 1 <= 7) && (n + 1 <= 6) && (pos[l + 1, n + 1] == 'P')) return 1;
                if ((l - 1 >= 0) && (n + 1 <= 6) && (pos[l - 1, n + 1] == 'P')) return 1;
            }
            else
            {
                if ((l + 1 <= 7) && (n - 1 >= 1) && (pos[l + 1, n - 1] == 'p')) return 1;
                if ((l - 1 >= 0) && (n - 1 >= 1) && (pos[l - 1, n - 1] == 'p')) return 1;
            }

            int i1 = 0;
            int i2 = 0;
            int i3 = 0;
            int i4 = 0;
            int i5 = 0;
            int i6 = 0;
            int i7 = 0;
            int i8 = 0;

            int i = 1;
            while (((i1 == 0) || (i2 == 0) || (i3 == 0) || (i4 == 0) ||
                (i5 == 0) || (i6 == 0) || (i7 == 0) || (i8 == 0)) && (i <= 7))
            {
                if ((i1 == 0) && (l + i <= 7) && (n + i <= 7) &&
                    ((pos[l + i, n + i] == b) || (pos[l + i, n + i] == q))) return 1;
                if ((i2 == 0) && (l + i <= 7) && (n - i >= 0) &&
                    ((pos[l + i, n - i] == b) || (pos[l + i, n - i] == q))) return 1;
                if ((i3 == 0) && (l - i >= 0) && (n + i <= 7) &&
                    ((pos[l - i, n + i] == b) || (pos[l - i, n + i] == q))) return 1;
                if ((i4 == 0) && (l - i >= 0) && (n - i >= 0) &&
                    ((pos[l - i, n - i] == b) || (pos[l - i, n - i] == q))) return 1;
                if ((i5 == 0) && (n + i <= 7) &&
                    ((pos[l, n + i] == r) || (pos[l, n + i] == q))) return 1;
                if ((i6 == 0) && (n - i >= 0) &&
                    ((pos[l, n - i] == r) || (pos[l, n - i] == q))) return 1;
                if ((i7 == 0) && (l + i <= 7) &&
                    ((pos[l + i, n] == r) || (pos[l + i, n] == q))) return 1;
                if ((i8 == 0) && (l - i >= 0) &&
                    ((pos[l - i, n] == r) || (pos[l - i, n] == q))) return 1;

                if ((i1 == 0) && (l + i <= 7) && (n + i <= 7) && (pos[l + i, n + i] != '\0')) i1 = 1;
                if ((i2 == 0) && (l + i <= 7) && (n - i >= 0) && (pos[l + i, n - i] != '\0')) i2 = 1;
                if ((i3 == 0) && (l - i >= 0) && (n + i <= 7) && (pos[l - i, n + i] != '\0')) i3 = 1;
                if ((i4 == 0) && (l - i >= 0) && (n - i >= 0) && (pos[l - i, n - i] != '\0')) i4 = 1;
                if ((i5 == 0) && (n + i <= 7) && (pos[l, n + i] != '\0')) i5 = 1;
                if ((i6 == 0) && (n - i >= 0) && (pos[l, n - i] != '\0')) i6 = 1;
                if ((i7 == 0) && (l + i <= 7) && (pos[l + i, n] != '\0')) i7 = 1;
                if ((i8 == 0) && (l - i >= 0) && (pos[l - i, n] != '\0')) i8 = 1;

                i++;
            }

            return 0;
        }

        public static int good(char [,]pos, byte l1, byte n1, byte l2, byte n2, char wb)
        {
            char [,]pos1 = new char[8, 8];
            for (byte i = 0; i <= 7; i++)
                for (byte j = 0; j <= 7; j++)
                    pos1[i, j] = pos[i, j];

            char k;
            if (wb == 'w') k = 'k';
            else k = 'K';

            if (wb == 'w') wb = 'b';
            else wb = 'w';

            if ((l2 == 8) && (n2 == 8))
            {
                pos1[l1, n1] = '\0';
            }
            else
            {
                if ((pos1[l1, n1] == 'p') && (l1 != l2) && (pos1[l2, n2] == '\0')) pos1[l2, n1] = '\0';
                if ((pos1[l1, n1] == 'P') && (l1 != l2) && (pos1[l2, n2] == '\0')) pos1[l2, n1] = '\0';

                pos1[l2, n2] = pos1[l1, n1];
                if ((l1 != 0) || (n1 != 0) || (l2 != 0) || (n2 != 0)) pos1[l1, n1] = '\0';
            }

            byte lk = 0;
            byte nk = 0;

            for (byte i = 0; i <= 7; i++)
                for (byte j = 0; j <= 7; j++)
                    if (pos1[i, j] == k)
                    {
                        lk = i;
                        nk = j;
                        break;
                    }

            if (attake(pos1, lk, nk, wb) == 1) return 0;
            else return 1;
        }

        public static _moves getMoves(char [,]pos, char wb, byte lc, byte rc, byte prohod)
        {
            move []moves = new move[100];
            for (int o = 0; o < 100; o++)
            {
                moves[o].l1 = 0;
                moves[o].n1 = 0;
                moves[o].l2 = 0;
                moves[o].n2 = 0;
                moves[o].f = '\0';
            }

            int size = -1;
            char f;



            for (byte i = 0; i <= 7; i++)
                for (byte j = 0; j <= 7; j++)
                {
                    //////////////////////////////////////////////////////////////кони
                    if (wb == 'w') f = 'n'; else
                        f = 'N';

                    if (pos[i, j] == f)
                    {
                        int g = 0;
                        if (good(pos, i, j, 8, 8, wb) == 1) 
                        g = 1;

                        if ((i + 2 >= 0) && (i + 2 <= 7) && (j + 1 >= 0) && (j + 1 <= 7) &&
                            (possible(pos[i + 2, j + 1], wb) == 1))
                        if ((g == 1) || (good(pos, i, j, (byte)(i + 2), (byte)(j + 1), wb) == 1))
                        {
                            size++;
                            moves[size] = new move(i, j, (byte)(i + 2), (byte)(j + 1), '\0');
                        }
                        if ((i + 1 >= 0) && (i + 1 <= 7) && (j + 2 >= 0) && (j + 2 <= 7) &&
                            (possible(pos[i + 1, j + 2], wb) == 1))
                        if ((g == 1) || (good(pos, i, j, (byte)(i + 1), (byte)(j + 2), wb) == 1))
                        {
                            size++;
                            moves[size] = new move(i, j, (byte)(i + 1), (byte)(j + 2), '\0');
                        }
                        if ((i - 2 >= 0) && (i - 2 <= 7) && (j + 1 >= 0) && (j + 1 <= 7) &&
                            (possible(pos[i - 2, j + 1], wb) == 1))
                        if ((g == 1) || (good(pos, i, j, (byte)(i - 2), (byte)(j + 1), wb) == 1))
                        {
                            size++;
                            moves[size] = new move(i, j, (byte)(i - 2), (byte)(j + 1), '\0');
                        }
                        if ((i + 1 >= 0) && (i + 1 <= 7) && (j - 2 >= 0) && (j - 2 <= 7) &&
                            (possible(pos[i + 1, j - 2], wb) == 1))
                        if ((g == 1) || (good(pos, i, j, (byte)(i + 1), (byte)(j - 2), wb) == 1))
                        {
                            size++;
                            moves[size] = new move(i, j, (byte)(i + 1), (byte)(j - 2), '\0');
                        }
                        if ((i - 1 >= 0) && (i - 1 <= 7) && (j + 2 >= 0) && (j + 2 <= 7) &&
                            (possible(pos[i - 1, j + 2], wb) == 1))
                        if ((g == 1) || (good(pos, i, j, (byte)(i - 1), (byte)(j + 2), wb) == 1))
                        {
                            size++;
                            moves[size] = new move(i, j, (byte)(i - 1), (byte)(j + 2), '\0');
                        }
                        if ((i + 2 >= 0) && (i + 2 <= 7) && (j - 1 >= 0) && (j - 1 <= 7) &&
                            (possible(pos[i + 2, j - 1], wb) == 1))
                        if ((g == 1) || (good(pos, i, j, (byte)(i + 2), (byte)(j - 1), wb) == 1))
                        {
                            size++;
                            moves[size] = new move(i, j, (byte)(i + 2), (byte)(j - 1), '\0');
                        }
                        if ((i - 1 >= 0) && (i - 1 <= 7) && (j - 2 >= 0) && (j - 2 <= 7) &&
                            (possible(pos[i - 1, j - 2], wb) == 1))
                        if ((g == 1) || (good(pos, i, j, (byte)(i - 1), (byte)(j - 2), wb) == 1))
                        {
                            size++;
                            moves[size] = new move(i, j, (byte)(i - 1), (byte)(j - 2), '\0');
                        }
                        if ((i - 2 >= 0) && (i - 2 <= 7) && (j - 1 >= 0) && (j - 1 <= 7) &&
                            (possible(pos[i - 2, j - 1], wb) == 1))
                        if ((g == 1) || (good(pos, i, j, (byte)(i - 2), (byte)(j - 1), wb) == 1))
                        {
                            size++;
                            moves[size] = new move(i, j, (byte)(i - 2), (byte)(j - 1), '\0');
                        }
                    }
                    //////////////////////////////////////////////////////////////кони

                         //////////////////////////////////////////////////////////////кароль
                    if (wb == 'w') f = 'k';
                        else
                            f = 'K';

                    if (pos[i, j] == f)
                    {
                        if ((i + 1 >= 0) && (i + 1 <= 7) && (j + 1 >= 0) && (j + 1 <= 7) &&
                            (possible(pos[i + 1, j + 1], wb) == 1))
                        if (good(pos, i, j, (byte)(i + 1), (byte)(j + 1), wb) == 1)
                        {
                            size++;
                            moves[size] = new move(i, j, (byte)(i + 1), (byte)(j + 1), '\0');
                        }
                        if ((i + 1 >= 0) && (i + 1 <= 7) && (j - 1 >= 0) && (j - 1 <= 7) &&
                            (possible(pos[i + 1, j - 1], wb) == 1))
                        if (good(pos, i, j, (byte)(i + 1), (byte)(j - 1), wb) == 1)
                        {
                            size++;
                            moves[size] = new move(i, j, (byte)(i + 1), (byte)(j - 1), '\0');
                        }
                        if ((i - 1 >= 0) && (i - 1 <= 7) && (j + 1 >= 0) && (j + 1 <= 7) &&
                            (possible(pos[i - 1, j + 1], wb) == 1))
                        if (good(pos, i, j, (byte)(i - 1), (byte)(j + 1), wb) == 1)
                        {
                            size++;
                            moves[size] = new move(i, j, (byte)(i - 1), (byte)(j + 1), '\0');
                        }
                        if ((i - 1 >= 0) && (i - 1 <= 7) && (j - 1 >= 0) && (j - 1 <= 7) &&
                            (possible(pos[i - 1, j - 1], wb) == 1))
                        if (good(pos, i, j, (byte)(i - 1), (byte)(j - 1), wb) == 1)
                        {
                            size++;
                            moves[size] = new move(i, j, (byte)(i - 1), (byte)(j - 1), '\0');
                        }
                        if ((i >= 0) && (i <= 7) && (j + 1 >= 0) && (j + 1 <= 7) &&
                            (possible(pos[i, j + 1], wb) == 1))
                        if (good(pos, i, j, i, (byte)(j + 1), wb) == 1)
                        {
                            size++;
                            moves[size] = new move(i, j, i, (byte)(j + 1), '\0');
                        }
                        if ((i >= 0) && (i <= 7) && (j - 1 >= 0) && (j - 1 <= 7) &&
                            (possible(pos[i, j - 1], wb) == 1))
                        if (good(pos, i, j, i, (byte)(j - 1), wb) == 1)
                        {
                            size++;
                            moves[size] = new move(i, j, i, (byte)(j - 1), '\0');
                        }
                        if ((i + 1 >= 0) && (i + 1 <= 7) && (j >= 0) && (j <= 7) &&
                            (possible(pos[i + 1, j], wb) == 1))
                        if (good(pos, i, j, (byte)(i + 1), j, wb) == 1)
                        {
                            size++;
                            moves[size] = new move(i, j, (byte)(i + 1), j, '\0');
                        }
                        if ((i - 1 >= 0) && (i - 1 <= 7) && (j >= 0) && (j <= 7) &&
                            (possible(pos[i - 1, j], wb) == 1))
                        if (good(pos, i, j, (byte)(i - 1), j, wb) == 1)
                        {
                            size++;
                            moves[size] = new move(i, j, (byte)(i - 1), j, '\0');
                        }
                    }
        //////////////////////////////////////////////////////////////кароль

        //////////////////////////////////////////////////////////////ладья

                    if (wb == 'w') f = 'r';
                    else
                        f = 'R';
                    byte i1 = i;
                    byte j1 = j;

                    if (pos[i, j] == f)
                    {
                        int g = 0;
                        if (good(pos, i, j, 8, 8, wb) == 1) 
                        g = 1;

                        i1 = i;
                        j1 = j;
                        int con = 1;
                        while ((i1 < 7) && (con == 1))
                        {
                            i1++;
                            if (possible(pos[i1, j1], wb) == 1)
                                if ((g == 1) || (good(pos, i, j, i1, j1, wb) == 1))
                                {
                                    size++;
                                    moves[size] = new move(i, j, i1, j1, '\0');
                                }
                            if (pos[i1, j1] != '\0') con = 0;
                        }

                        i1 = i;
                        j1 = j;
                        con = 1;
                        while ((j1 < 7) && (con == 1))
                        {
                            j1++;
                            if (possible(pos[i1, j1], wb) == 1)
                                if ((g == 1) || (good(pos, i, j, i1, j1, wb) == 1))
                                {
                                    size++;
                                    moves[size] = new move(i, j, i1, j1, '\0');
                                }
                            if (pos[i1, j1] != '\0') con = 0;
                        }

                        i1 = i;
                        j1 = j;
                        con = 1;
                        while ((i1 > 0) && (con == 1))
                        {
                            i1--;
                            if (possible(pos[i1, j1], wb) == 1)
                                if ((g == 1) || (good(pos, i, j, i1, j1, wb) == 1))
                                {
                                    size++;
                                    moves[size] = new move(i, j, i1, j1, '\0');
                                }
                            if (pos[i1, j1] != '\0') con = 0;
                        }

                        i1 = i;
                        j1 = j;
                        con = 1;
                        while ((j1 > 0) && (con == 1))
                        {
                            j1--;
                            if (possible(pos[i1, j1], wb) == 1)
                                if ((g == 1) || (good(pos, i, j, i1, j1, wb) == 1))
                                {
                                    size++;
                                    moves[size] = new move(i, j, i1, j1, '\0');
                                }
                            if (pos[i1, j1] != '\0') con = 0;
                        }
                    }

        //////////////////////////////////////////////////////////////ладья

        //////////////////////////////////////////////////////////////слон

                    if (wb == 'w') f = 'b';
                    else
                        f = 'B';
                    i1 = i;
                    j1 = j;

                    if (pos[i, j] == f)
                    {
                        int g = 0;
                        if (good(pos, i, j, 8, 8, wb) == 1) 
                        g = 1;

                        i1 = i;
                        j1 = j;
                        int con = 1;
                        while ((i1 < 7) && (j1 < 7) && (con == 1))
                        {
                            i1++;
                            j1++;
                            if (possible(pos[i1, j1], wb) == 1)
                                if ((g == 1) || (good(pos, i, j, i1, j1, wb) == 1))
                                {
                                    size++;
                                    moves[size] = new move(i, j, i1, j1, '\0');
                                }
                            if (pos[i1, j1] != '\0') con = 0;
                        }

                        i1 = i;
                        j1 = j;
                        con = 1;
                        while ((i1 < 7) && (j1 > 0) && (con == 1))
                        {
                            i1++;
                            j1--;
                            if (possible(pos[i1, j1], wb) == 1)
                                if ((g == 1) || (good(pos, i, j, i1, j1, wb) == 1))
                                {
                                    size++;
                                    moves[size] = new move(i, j, i1, j1, '\0');
                                }
                            if (pos[i1, j1] != '\0') con = 0;
                        }

                        i1 = i;
                        j1 = j;
                        con = 1;
                        while ((i1 > 0) && (j1 < 7) && (con == 1))
                        {
                            i1--;
                            j1++;
                            if (possible(pos[i1, j1], wb) == 1)
                                if ((g == 1) || (good(pos, i, j, i1, j1, wb) == 1))
                                {
                                    size++;
                                    moves[size] = new move(i, j, i1, j1, '\0');
                                }
                            if (pos[i1, j1] != '\0') con = 0;
                        }

                        i1 = i;
                        j1 = j;
                        con = 1;
                        while ((i1 > 0) && (j1 > 0) && (con == 1))
                        {
                            i1--;
                            j1--;
                            if (possible(pos[i1, j1], wb) == 1)
                                if ((g == 1) || (good(pos, i, j, i1, j1, wb) == 1))
                                {
                                    size++;
                                    moves[size] = new move(i, j, i1, j1, '\0');
                                }
                            if (pos[i1, j1] != '\0') con = 0;
                        }
                    }

        //////////////////////////////////////////////////////////////слон

        //////////////////////////////////////////////////////////////ферзь

                    if (wb == 'w') f = 'q';
                    else
                        f = 'Q';
                    i1 = i;
                    j1 = j;

                    if (pos[i, j] == f)
                    {
                        int g = 0;
                        if (good(pos, i, j, 8, 8, wb) == 1) 
                        g = 1;

                        i1 = i;
                        j1 = j;
                        int con = 1;
                        while ((i1 < 7) && (con == 1))
                        {
                            i1++;
                            if (possible(pos[i1, j1], wb) == 1)
                                if ((g == 1) || (good(pos, i, j, i1, j1, wb) == 1))
                                {
                                    size++;
                                    moves[size] = new move(i, j, i1, j1, '\0');
                                }
                            if (pos[i1, j1] != '\0') con = 0;
                        }

                        i1 = i;
                        j1 = j;
                        con = 1;
                        while ((j1 < 7) && (con == 1))
                        {
                            j1++;
                            if (possible(pos[i1, j1], wb) == 1)
                                if ((g == 1) || (good(pos, i, j, i1, j1, wb) == 1))
                                {
                                    size++;
                                    moves[size] = new move(i, j, i1, j1, '\0');
                                }
                            if (pos[i1, j1] != '\0') con = 0;
                        }

                        i1 = i;
                        j1 = j;
                        con = 1;
                        while ((i1 > 0) && (con == 1))
                        {
                            i1--;
                            if (possible(pos[i1, j1], wb) == 1)
                                if ((g == 1) || (good(pos, i, j, i1, j1, wb) == 1))
                                {
                                    size++;
                                    moves[size] = new move(i, j, i1, j1, '\0');
                                }
                            if (pos[i1, j1] != '\0') con = 0;
                        }

                        i1 = i;
                        j1 = j;
                        con = 1;
                        while ((j1 > 0) && (con == 1))
                        {
                            j1--;
                            if (possible(pos[i1, j1], wb) == 1)
                                if ((g == 1) || (good(pos, i, j, i1, j1, wb) == 1))
                                {
                                    size++;
                                    moves[size] = new move(i, j, i1, j1, '\0');
                                }
                            if (pos[i1, j1] != '\0') con = 0;
                        }

                        i1 = i;
                        j1 = j;
                        con = 1;
                        while ((i1 < 7) && (j1 < 7) && (con == 1))
                        {
                            i1++;
                            j1++;
                            if (possible(pos[i1, j1], wb) == 1)
                                if ((g == 1) || (good(pos, i, j, i1, j1, wb) == 1))
                                {
                                    size++;
                                    moves[size] = new move(i, j, i1, j1, '\0');
                                }
                            if (pos[i1, j1] != '\0') con = 0;
                        }

                        i1 = i;
                        j1 = j;
                        con = 1;
                        while ((i1 < 7) && (j1 > 0) && (con == 1))
                        {
                            i1++;
                            j1--;
                            if (possible(pos[i1, j1], wb) == 1)
                                if ((g == 1) || (good(pos, i, j, i1, j1, wb) == 1))
                                {
                                    size++;
                                    moves[size] = new move(i, j, i1, j1, '\0');
                                }
                            if (pos[i1, j1] != '\0') con = 0;
                        }

                        i1 = i;
                        j1 = j;
                        con = 1;
                        while ((i1 > 0) && (j1 < 7) && (con == 1))
                        {
                            i1--;
                            j1++;
                            if (possible(pos[i1, j1], wb) == 1)
                                if ((g == 1) || (good(pos, i, j, i1, j1, wb) == 1))
                                {
                                    size++;
                                    moves[size] = new move(i, j, i1, j1, '\0');
                                }
                            if (pos[i1, j1] != '\0') con = 0;
                        }

                        i1 = i;
                        j1 = j;
                        con = 1;
                        while ((i1 > 0) && (j1 > 0) && (con == 1))
                        {
                            i1--;
                            j1--;
                            if (possible(pos[i1, j1], wb) == 1)
                                if ((g == 1) || (good(pos, i, j, i1, j1, wb) == 1))
                                {
                                    size++;
                                    moves[size] = new move(i, j, i1, j1, '\0');
                                }
                            if (pos[i1, j1] != '\0') con = 0;
                        }
                    }

        //////////////////////////////////////////////////////////////ферзь

        //////////////////////////////////////////////////////////////белая пешка
                    if ((wb == 'w') && (pos[i, j] == 'p'))
                    {
                        int g = 0;
                        if (good(pos, i, j, 8, 8, wb) == 1) 
                        g = 1;

                        if ((pos[i, j + 1] == '\0') && (j != 6)) // на 1 клетку вперед
                            if ((g == 1) || (good(pos, i, j, i, (byte)(j + 1), wb) == 1))
                            {
                                size++;
                                moves[size] = new move(i, j, i, (byte)(j + 1), '\0');
                            }
                        if ((pos[i, j + 1] == '\0') && (j == 6))
                            if ((g == 1) || (good(pos, i, j, i, (byte)(j + 1), wb) == 1))
                            {
                                size++;
                                moves[size] = new move(i, j, i, (byte)(j + 1), 'n');
                                size++;
                                moves[size] = new move(i, j, i, (byte)(j + 1), 'b');
                                size++;
                                moves[size] = new move(i, j, i, (byte)(j + 1), 'r');
                                size++;
                                moves[size] = new move(i, j, i, (byte)(j + 1), 'q');
                            }

                        if ((i != 0) && (another(pos[i - 1, j + 1], wb) == 1) && (j != 6)) //бой влево
                            if ((g == 1) || (good(pos, i, j, (byte)(i - 1), (byte)(j + 1), wb) == 1))
                            {
                                size++;
                                moves[size] = new move(i, j, (byte)(i - 1), (byte)(j + 1), '\0');
                            }
                        if ((i != 0) && (another(pos[i - 1, j + 1], wb) == 1) && (j == 6))
                            if ((g == 1) || (good(pos, i, j, (byte)(i - 1), (byte)(j + 1), wb) == 1))
                            {
                                size++;
                                moves[size] = new move(i, j, (byte)(i - 1), (byte)(j + 1), 'n');
                                size++;
                                moves[size] = new move(i, j, (byte)(i - 1), (byte)(j + 1), 'b');
                                size++;
                                moves[size] = new move(i, j, (byte)(i - 1), (byte)(j + 1), 'r');
                                size++;
                                moves[size] = new move(i, j, (byte)(i - 1), (byte)(j + 1), 'q');
                            }

                        if ((i != 7) && (another(pos[i + 1, j + 1], wb) == 1) && (j != 6)) //бой вправо
                            if ((g == 1) || (good(pos, i, j, (byte)(i + 1), (byte)(j + 1), wb) == 1))
                            {
                                size++;
                                moves[size] = new move(i, j, (byte)(i + 1), (byte)(j + 1), '\0');
                            }
                        if ((i != 7) && (another(pos[i + 1, j + 1], wb) == 1) && (j == 6))
                            if ((g == 1) || (good(pos, i, j, (byte)(i + 1), (byte)(j + 1), wb) == 1))
                            {
                                size++;
                                moves[size] = new move(i, j, (byte)(i + 1), (byte)(j + 1), 'n');
                                size++;
                                moves[size] = new move(i, j, (byte)(i + 1), (byte)(j + 1), 'b');
                                size++;
                                moves[size] = new move(i, j, (byte)(i + 1), (byte)(j + 1), 'r');
                                size++;
                                moves[size] = new move(i, j, (byte)(i + 1), (byte)(j + 1), 'q');
                            }

                        if ((j == 1) && (pos[i, j + 1] == '\0') && (pos[i, j + 2] == '\0')) // на 2 клетки вперед
                            if ((g == 1) || (good(pos, i, j, i, (byte)(j + 2), wb) == 1))
                            {
                                size++;
                                moves[size].l1 = i;
                                moves[size].n1 = j;
                                moves[size].l2 = i;
                                moves[size].n2 = (byte)(j + 2);
                                moves[size] = new move(i, j, i, (byte)(j + 2), '\0');
                            }

                        if ((j == 4) && (prohod == i + 1)) // на проходе вправо
                            if (good(pos, i, j, (byte)(i + 1), (byte)(j + 1), wb) == 1)
                            {
                                size++;
                                moves[size] = new move(i, j, (byte)(i + 1), (byte)(j + 1), '\0');
                            }

                        if ((j == 4) && (prohod == i - 1)) // на проходе влево
                            if (good(pos, i, j, (byte)(i - 1), (byte)(j + 1), wb) == 1)
                            {
                                size++;
                                moves[size] = new move(i, j, (byte)(i - 1), (byte)(j + 1), '\0');
                            }
                    }
        //////////////////////////////////////////////////////////////белая пешка

        //////////////////////////////////////////////////////////////черная пешка
                    if ((wb == 'b') && (pos[i, j] == 'P'))
                    {
                        int g = 0;
                        if (good(pos, i, j, 8, 8, wb) == 1) 
                        g = 1;

                        if ((pos[i, j - 1] == '\0') && (j != 1)) // на 1 клетку вперед
                            if ((g == 1) || (good(pos, i, j, i, (byte)(j - 1), wb) == 1))
                            {
                                size++;
                                moves[size] = new move(i, j, i, (byte)(j - 1), '\0');
                            }
                        if ((pos[i, j - 1] == '\0') && (j == 1))
                            if ((g == 1) || (good(pos, i, j, i, (byte)(j - 1), wb) == 1))
                            {
                                size++;
                                moves[size] = new move(i, j, i, (byte)(j - 1), 'N');
                                size++;
                                moves[size] = new move(i, j, i, (byte)(j - 1), 'B');
                                size++;
                                moves[size] = new move(i, j, i, (byte)(j - 1), 'R');
                                size++;
                                moves[size] = new move(i, j, i, (byte)(j - 1), 'Q');
                            }

                        if ((i != 0) && (another(pos[i - 1, j - 1], wb) == 1) && (j != 1)) //бой влево
                            if ((g == 1) || (good(pos, i, j, (byte)(i - 1), (byte)(j - 1), wb) == 1))
                            {
                                size++;
                                moves[size] = new move(i, j, (byte)(i - 1), (byte)(j - 1), '\0');
                            }
                        if ((i != 0) && (another(pos[i - 1, j - 1], wb) == 1) && (j == 1))
                            if ((g == 1) || (good(pos, i, j, (byte)(i - 1), (byte)(j - 1), wb) == 1))
                            {
                                size++;
                                moves[size] = new move(i, j, (byte)(i - 1), (byte)(j - 1), 'N');
                                size++;
                                moves[size] = new move(i, j, (byte)(i - 1), (byte)(j - 1), 'B');
                                size++;
                                moves[size] = new move(i, j, (byte)(i - 1), (byte)(j - 1), 'R');
                                size++;
                                moves[size] = new move(i, j, (byte)(i - 1), (byte)(j - 1), 'Q');
                            }

                        if ((i != 7) && (another(pos[i + 1, j - 1], wb) == 1) && (j != 1)) //бой вправо
                            if ((g == 1) || (good(pos, i, j, (byte)(i + 1), (byte)(j - 1), wb) == 1))
                            {
                                size++;
                                moves[size] = new move(i, j, (byte)(i + 1), (byte)(j - 1), '\0');
                            }
                        if ((i != 7) && (another(pos[i + 1, j - 1], wb) == 1) && (j == 1))
                            if ((g == 1) || (good(pos, i, j, (byte)(i + 1), (byte)(j - 1), wb) == 1))
                            {
                                size++;
                                moves[size] = new move(i, j, (byte)(i + 1), (byte)(j - 1), 'N');
                                size++;
                                moves[size] = new move(i, j, (byte)(i + 1), (byte)(j - 1), 'B');
                                size++;
                                moves[size] = new move(i, j, (byte)(i + 1), (byte)(j - 1), 'R');
                                size++;
                                moves[size] = new move(i, j, (byte)(i + 1), (byte)(j - 1), 'Q');
                            }

                        if ((j == 6) && (pos[i, j - 1] == '\0') && (pos[i, j - 2] == '\0')) // на 2 клетки вперед
                            if ((g == 1) || (good(pos, i, j, i, (byte)(j - 2), wb) == 1))
                            {
                                size++;
                                moves[size] = new move(i, j, i, (byte)(j - 2), '\0');
                            }

                        if ((j == 3) && (prohod == i + 1)) // на проходе вправо
                            if (good(pos, i, j, (byte)(i + 1), (byte)(j - 1), wb) == 1)
                            {
                                size++;
                                moves[size] = new move(i, j, (byte)(i + 1), (byte)(j - 1), '\0');
                            }

                        if ((j == 3) && (prohod == i - 1)) // на проходе влево
                            if (good(pos, i, j, (byte)(i - 1), (byte)(j - 1), wb) == 1)
                            {
                                size++;
                                moves[size] = new move(i, j, (byte)(i - 1), (byte)(j - 1), '\0');
                            }
                    }
                    //////////////////////////////////////////////////////////////черная пешка

                }

            //////////////////////////////////////////////////////////////рокировка белых
                if (wb == 'w')
                {
                    if ((lc == 1) && (attake(pos, 4, 0, 'b') == 0)
                        && (pos[3, 0] == '\0') && (attake(pos, 3, 0, 'b') == 0)
                        && (pos[2, 0] == '\0') && (attake(pos, 2, 0, 'b') == 0)
                        && (pos[1, 0] == '\0'))
                    {
                        size++;
                        moves[size] = new move(4, 0, 2, 0, '\0');
                    }

                    if ((rc == 1) && (attake(pos, 4, 0, 'b') == 0)
                        && (pos[5, 0] == '\0') && (attake(pos, 5, 0, 'b') == 0)
                        && (pos[6, 0] == '\0') && (attake(pos, 6, 0, 'b') == 0))
                    {
                        size++;
                        moves[size] = new move(4, 0, 6, 0, '\0');
                    }
                }
        //////////////////////////////////////////////////////////////рокировка белых

        //////////////////////////////////////////////////////////////рокировка черных
                if (wb == 'b')
                {
                    if ((lc == 1) && (attake(pos, 4, 7, 'w') == 0)
                        && (pos[3, 7] == '\0') && (attake(pos, 3, 7, 'w') == 0)
                        && (pos[2, 7] == '\0') && (attake(pos, 2, 7, 'w') == 0)
                        && (pos[1, 7] == '\0'))
                    {
                        size++;
                        moves[size] = new move(4, 7, 2, 7, '\0');
                    }

                    if ((rc == 1) && (attake(pos, 4, 7, 'w') == 0)
                        && (pos[5, 7] == '\0') && (attake(pos, 5, 7, 'w') == 0)
                        && (pos[6, 7] == '\0') && (attake(pos, 6, 7, 'w') == 0))
                    {
                        size++;
                        moves[size] = new move(4, 7, 6, 7, '\0');
                    }
                }
        //////////////////////////////////////////////////////////////рокировка черных

            _moves all;
            all.moves = new move[100];
            for (int o = 0; o < 100; o++)
            {
                all.moves[o].l1 = 0;
                all.moves[o].n1 = 0;
                all.moves[o].l2 = 0;
                all.moves[o].n2 = 0;
                all.moves[o].f = '\0';
            }





            int t = 0;
            while ((moves[t].l1 != '\0') || (moves[t].n1 != '\0') ||
                (moves[t].l2 != '\0') || (moves[t].n2 != '\0'))
            {
                all.moves[t].l1 = moves[t].l1;
                all.moves[t].n1 = moves[t].n1;
                all.moves[t].l2 = moves[t].l2;
                all.moves[t].n2 = moves[t].n2;
                all.moves[t].f = moves[t].f;
                t++;
            }

            all.n = size + 1;
            return all;
        }


        public static int getMovesIs(char[,] pos, char wb, byte lc, byte rc, byte prohod)
        {
            move[] moves = new move[100];
            for (int o = 0; o < 100; o++)
            {
                moves[o].l1 = 0;
                moves[o].n1 = 0;
                moves[o].l2 = 0;
                moves[o].n2 = 0;
                moves[o].f = '\0';
            }

            char f;



            for (byte i = 0; i <= 7; i++)
                for (byte j = 0; j <= 7; j++)
                {
                    //////////////////////////////////////////////////////////////кони
                    if (wb == 'w') f = 'n';
                    else
                        f = 'N';

                    if (pos[i, j] == f)
                    {
                        int g = 0;
                        if (good(pos, i, j, 8, 8, wb) == 1)
                            g = 1;

                        if ((i + 2 >= 0) && (i + 2 <= 7) && (j + 1 >= 0) && (j + 1 <= 7) &&
                            (possible(pos[i + 2, j + 1], wb) == 1))
                            if ((g == 1) || (good(pos, i, j, (byte)(i + 2), (byte)(j + 1), wb) == 1))
                            {
                                return 1;
                            }
                        if ((i + 1 >= 0) && (i + 1 <= 7) && (j + 2 >= 0) && (j + 2 <= 7) &&
                            (possible(pos[i + 1, j + 2], wb) == 1))
                            if ((g == 1) || (good(pos, i, j, (byte)(i + 1), (byte)(j + 2), wb) == 1))
                            {
                                return 1;
                            }
                        if ((i - 2 >= 0) && (i - 2 <= 7) && (j + 1 >= 0) && (j + 1 <= 7) &&
                            (possible(pos[i - 2, j + 1], wb) == 1))
                            if ((g == 1) || (good(pos, i, j, (byte)(i - 2), (byte)(j + 1), wb) == 1))
                            {
                                return 1;
                            }
                        if ((i + 1 >= 0) && (i + 1 <= 7) && (j - 2 >= 0) && (j - 2 <= 7) &&
                            (possible(pos[i + 1, j - 2], wb) == 1))
                            if ((g == 1) || (good(pos, i, j, (byte)(i + 1), (byte)(j - 2), wb) == 1))
                            {
                                return 1;
                            }
                        if ((i - 1 >= 0) && (i - 1 <= 7) && (j + 2 >= 0) && (j + 2 <= 7) &&
                            (possible(pos[i - 1, j + 2], wb) == 1))
                            if ((g == 1) || (good(pos, i, j, (byte)(i - 1), (byte)(j + 2), wb) == 1))
                            {
                                return 1;
                            }
                        if ((i + 2 >= 0) && (i + 2 <= 7) && (j - 1 >= 0) && (j - 1 <= 7) &&
                            (possible(pos[i + 2, j - 1], wb) == 1))
                            if ((g == 1) || (good(pos, i, j, (byte)(i + 2), (byte)(j - 1), wb) == 1))
                            {
                                return 1;
                            }
                        if ((i - 1 >= 0) && (i - 1 <= 7) && (j - 2 >= 0) && (j - 2 <= 7) &&
                            (possible(pos[i - 1, j - 2], wb) == 1))
                            if ((g == 1) || (good(pos, i, j, (byte)(i - 1), (byte)(j - 2), wb) == 1))
                            {
                                return 1;
                            }
                        if ((i - 2 >= 0) && (i - 2 <= 7) && (j - 1 >= 0) && (j - 1 <= 7) &&
                            (possible(pos[i - 2, j - 1], wb) == 1))
                            if ((g == 1) || (good(pos, i, j, (byte)(i - 2), (byte)(j - 1), wb) == 1))
                            {
                                return 1;
                            }
                    }
                    //////////////////////////////////////////////////////////////кони

                    //////////////////////////////////////////////////////////////кароль
                    if (wb == 'w') f = 'k';
                    else
                        f = 'K';

                    if (pos[i, j] == f)
                    {
                        if ((i + 1 >= 0) && (i + 1 <= 7) && (j + 1 >= 0) && (j + 1 <= 7) &&
                            (possible(pos[i + 1, j + 1], wb) == 1))
                            if (good(pos, i, j, (byte)(i + 1), (byte)(j + 1), wb) == 1)
                            {
                                return 1;
                            }
                        if ((i + 1 >= 0) && (i + 1 <= 7) && (j - 1 >= 0) && (j - 1 <= 7) &&
                            (possible(pos[i + 1, j - 1], wb) == 1))
                            if (good(pos, i, j, (byte)(i + 1), (byte)(j - 1), wb) == 1)
                            {
                                return 1;
                            }
                        if ((i - 1 >= 0) && (i - 1 <= 7) && (j + 1 >= 0) && (j + 1 <= 7) &&
                            (possible(pos[i - 1, j + 1], wb) == 1))
                            if (good(pos, i, j, (byte)(i - 1), (byte)(j + 1), wb) == 1)
                            {
                                return 1;
                            }
                        if ((i - 1 >= 0) && (i - 1 <= 7) && (j - 1 >= 0) && (j - 1 <= 7) &&
                            (possible(pos[i - 1, j - 1], wb) == 1))
                            if (good(pos, i, j, (byte)(i - 1), (byte)(j - 1), wb) == 1)
                            {
                                return 1;
                            }
                        if ((i >= 0) && (i <= 7) && (j + 1 >= 0) && (j + 1 <= 7) &&
                            (possible(pos[i, j + 1], wb) == 1))
                            if (good(pos, i, j, i, (byte)(j + 1), wb) == 1)
                            {
                                return 1;
                            }
                        if ((i >= 0) && (i <= 7) && (j - 1 >= 0) && (j - 1 <= 7) &&
                            (possible(pos[i, j - 1], wb) == 1))
                            if (good(pos, i, j, i, (byte)(j - 1), wb) == 1)
                            {
                                return 1;
                            }
                        if ((i + 1 >= 0) && (i + 1 <= 7) && (j >= 0) && (j <= 7) &&
                            (possible(pos[i + 1, j], wb) == 1))
                            if (good(pos, i, j, (byte)(i + 1), j, wb) == 1)
                            {
                                return 1;
                            }
                        if ((i - 1 >= 0) && (i - 1 <= 7) && (j >= 0) && (j <= 7) &&
                            (possible(pos[i - 1, j], wb) == 1))
                            if (good(pos, i, j, (byte)(i - 1), j, wb) == 1)
                            {
                                return 1;
                            }
                    }
                    //////////////////////////////////////////////////////////////кароль

                    //////////////////////////////////////////////////////////////ладья

                    if (wb == 'w') f = 'r';
                    else
                        f = 'R';
                    byte i1 = i;
                    byte j1 = j;

                    if (pos[i, j] == f)
                    {
                        int g = 0;
                        if (good(pos, i, j, 8, 8, wb) == 1)
                            g = 1;

                        i1 = i;
                        j1 = j;
                        int con = 1;
                        while ((i1 < 7) && (con == 1))
                        {
                            i1++;
                            if (possible(pos[i1, j1], wb) == 1)
                                if ((g == 1) || (good(pos, i, j, i1, j1, wb) == 1))
                                {
                                    return 1;
                                }
                            if (pos[i1, j1] != '\0') con = 0;
                        }

                        i1 = i;
                        j1 = j;
                        con = 1;
                        while ((j1 < 7) && (con == 1))
                        {
                            j1++;
                            if (possible(pos[i1, j1], wb) == 1)
                                if ((g == 1) || (good(pos, i, j, i1, j1, wb) == 1))
                                {
                                    return 1;
                                }
                            if (pos[i1, j1] != '\0') con = 0;
                        }

                        i1 = i;
                        j1 = j;
                        con = 1;
                        while ((i1 > 0) && (con == 1))
                        {
                            i1--;
                            if (possible(pos[i1, j1], wb) == 1)
                                if ((g == 1) || (good(pos, i, j, i1, j1, wb) == 1))
                                {
                                    return 1;
                                }
                            if (pos[i1, j1] != '\0') con = 0;
                        }

                        i1 = i;
                        j1 = j;
                        con = 1;
                        while ((j1 > 0) && (con == 1))
                        {
                            j1--;
                            if (possible(pos[i1, j1], wb) == 1)
                                if ((g == 1) || (good(pos, i, j, i1, j1, wb) == 1))
                                {
                                    return 1;
                                }
                            if (pos[i1, j1] != '\0') con = 0;
                        }
                    }

                    //////////////////////////////////////////////////////////////ладья

                    //////////////////////////////////////////////////////////////слон

                    if (wb == 'w') f = 'b';
                    else
                        f = 'B';
                    i1 = i;
                    j1 = j;

                    if (pos[i, j] == f)
                    {
                        int g = 0;
                        if (good(pos, i, j, 8, 8, wb) == 1)
                            g = 1;

                        i1 = i;
                        j1 = j;
                        int con = 1;
                        while ((i1 < 7) && (j1 < 7) && (con == 1))
                        {
                            i1++;
                            j1++;
                            if (possible(pos[i1, j1], wb) == 1)
                                if ((g == 1) || (good(pos, i, j, i1, j1, wb) == 1))
                                {
                                    return 1;
                                }
                            if (pos[i1, j1] != '\0') con = 0;
                        }

                        i1 = i;
                        j1 = j;
                        con = 1;
                        while ((i1 < 7) && (j1 > 0) && (con == 1))
                        {
                            i1++;
                            j1--;
                            if (possible(pos[i1, j1], wb) == 1)
                                if ((g == 1) || (good(pos, i, j, i1, j1, wb) == 1))
                                {
                                    return 1;
                                }
                            if (pos[i1, j1] != '\0') con = 0;
                        }

                        i1 = i;
                        j1 = j;
                        con = 1;
                        while ((i1 > 0) && (j1 < 7) && (con == 1))
                        {
                            i1--;
                            j1++;
                            if (possible(pos[i1, j1], wb) == 1)
                                if ((g == 1) || (good(pos, i, j, i1, j1, wb) == 1))
                                {
                                    return 1;
                                }
                            if (pos[i1, j1] != '\0') con = 0;
                        }

                        i1 = i;
                        j1 = j;
                        con = 1;
                        while ((i1 > 0) && (j1 > 0) && (con == 1))
                        {
                            i1--;
                            j1--;
                            if (possible(pos[i1, j1], wb) == 1)
                                if ((g == 1) || (good(pos, i, j, i1, j1, wb) == 1))
                                {
                                    return 1;
                                }
                            if (pos[i1, j1] != '\0') con = 0;
                        }
                    }

                    //////////////////////////////////////////////////////////////слон

                    //////////////////////////////////////////////////////////////ферзь

                    if (wb == 'w') f = 'q';
                    else
                        f = 'Q';
                    i1 = i;
                    j1 = j;

                    if (pos[i, j] == f)
                    {
                        int g = 0;
                        if (good(pos, i, j, 8, 8, wb) == 1)
                            g = 1;

                        i1 = i;
                        j1 = j;
                        int con = 1;
                        while ((i1 < 7) && (con == 1))
                        {
                            i1++;
                            if (possible(pos[i1, j1], wb) == 1)
                                if ((g == 1) || (good(pos, i, j, i1, j1, wb) == 1))
                                {
                                    return 1;
                                }
                            if (pos[i1, j1] != '\0') con = 0;
                        }

                        i1 = i;
                        j1 = j;
                        con = 1;
                        while ((j1 < 7) && (con == 1))
                        {
                            j1++;
                            if (possible(pos[i1, j1], wb) == 1)
                                if ((g == 1) || (good(pos, i, j, i1, j1, wb) == 1))
                                {
                                    return 1;
                                }
                            if (pos[i1, j1] != '\0') con = 0;
                        }

                        i1 = i;
                        j1 = j;
                        con = 1;
                        while ((i1 > 0) && (con == 1))
                        {
                            i1--;
                            if (possible(pos[i1, j1], wb) == 1)
                                if ((g == 1) || (good(pos, i, j, i1, j1, wb) == 1))
                                {
                                    return 1;
                                }
                            if (pos[i1, j1] != '\0') con = 0;
                        }

                        i1 = i;
                        j1 = j;
                        con = 1;
                        while ((j1 > 0) && (con == 1))
                        {
                            j1--;
                            if (possible(pos[i1, j1], wb) == 1)
                                if ((g == 1) || (good(pos, i, j, i1, j1, wb) == 1))
                                {
                                    return 1;
                                }
                            if (pos[i1, j1] != '\0') con = 0;
                        }

                        i1 = i;
                        j1 = j;
                        con = 1;
                        while ((i1 < 7) && (j1 < 7) && (con == 1))
                        {
                            i1++;
                            j1++;
                            if (possible(pos[i1, j1], wb) == 1)
                                if ((g == 1) || (good(pos, i, j, i1, j1, wb) == 1))
                                {
                                    return 1;
                                }
                            if (pos[i1, j1] != '\0') con = 0;
                        }

                        i1 = i;
                        j1 = j;
                        con = 1;
                        while ((i1 < 7) && (j1 > 0) && (con == 1))
                        {
                            i1++;
                            j1--;
                            if (possible(pos[i1, j1], wb) == 1)
                                if ((g == 1) || (good(pos, i, j, i1, j1, wb) == 1))
                                {
                                    return 1;
                                }
                            if (pos[i1, j1] != '\0') con = 0;
                        }

                        i1 = i;
                        j1 = j;
                        con = 1;
                        while ((i1 > 0) && (j1 < 7) && (con == 1))
                        {
                            i1--;
                            j1++;
                            if (possible(pos[i1, j1], wb) == 1)
                                if ((g == 1) || (good(pos, i, j, i1, j1, wb) == 1))
                                {
                                    return 1;
                                }
                            if (pos[i1, j1] != '\0') con = 0;
                        }

                        i1 = i;
                        j1 = j;
                        con = 1;
                        while ((i1 > 0) && (j1 > 0) && (con == 1))
                        {
                            i1--;
                            j1--;
                            if (possible(pos[i1, j1], wb) == 1)
                                if ((g == 1) || (good(pos, i, j, i1, j1, wb) == 1))
                                {
                                    return 1;
                                }
                            if (pos[i1, j1] != '\0') con = 0;
                        }
                    }

                    //////////////////////////////////////////////////////////////ферзь

                    //////////////////////////////////////////////////////////////белая пешка
                    if ((wb == 'w') && (pos[i, j] == 'p'))
                    {
                        int g = 0;
                        if (good(pos, i, j, 8, 8, wb) == 1)
                            g = 1;

                        if ((pos[i, j + 1] == '\0') && (j != 6)) // на 1 клетку вперед
                            if ((g == 1) || (good(pos, i, j, i, (byte)(j + 1), wb) == 1))
                            {
                                return 1;
                            }
                        if ((pos[i, j + 1] == '\0') && (j == 6))
                            if ((g == 1) || (good(pos, i, j, i, (byte)(j + 1), wb) == 1))
                            {
                                return 1;
                            }

                        if ((i != 0) && (another(pos[i - 1, j + 1], wb) == 1) && (j != 6)) //бой влево
                            if ((g == 1) || (good(pos, i, j, (byte)(i - 1), (byte)(j + 1), wb) == 1))
                            {
                                return 1;
                            }
                        if ((i != 0) && (another(pos[i - 1, j + 1], wb) == 1) && (j == 6))
                            if ((g == 1) || (good(pos, i, j, (byte)(i - 1), (byte)(j + 1), wb) == 1))
                            {
                                return 1;
                            }

                        if ((i != 7) && (another(pos[i + 1, j + 1], wb) == 1) && (j != 6)) //бой вправо
                            if ((g == 1) || (good(pos, i, j, (byte)(i + 1), (byte)(j + 1), wb) == 1))
                            {
                                return 1;
                            }
                        if ((i != 7) && (another(pos[i + 1, j + 1], wb) == 1) && (j == 6))
                            if ((g == 1) || (good(pos, i, j, (byte)(i + 1), (byte)(j + 1), wb) == 1))
                            {
                                return 1;
                            }

                        if ((j == 1) && (pos[i, j + 1] == '\0') && (pos[i, j + 2] == '\0')) // на 2 клетки вперед
                            if ((g == 1) || (good(pos, i, j, i, (byte)(j + 2), wb) == 1))
                            {
                                return 1;
                            }

                        if ((j == 4) && (prohod == i + 1)) // на проходе вправо
                            if (good(pos, i, j, (byte)(i + 1), (byte)(j + 1), wb) == 1)
                            {
                                return 1;
                            }

                        if ((j == 4) && (prohod == i - 1)) // на проходе влево
                            if (good(pos, i, j, (byte)(i - 1), (byte)(j + 1), wb) == 1)
                            {
                                return 1;
                            }
                    }
                    //////////////////////////////////////////////////////////////белая пешка

                    //////////////////////////////////////////////////////////////черная пешка
                    if ((wb == 'b') && (pos[i, j] == 'P'))
                    {
                        int g = 0;
                        if (good(pos, i, j, 8, 8, wb) == 1)
                            g = 1;

                        if ((pos[i, j - 1] == '\0') && (j != 1)) // на 1 клетку вперед
                            if ((g == 1) || (good(pos, i, j, i, (byte)(j - 1), wb) == 1))
                            {
                                return 1;
                            }
                        if ((pos[i, j - 1] == '\0') && (j == 1))
                            if ((g == 1) || (good(pos, i, j, i, (byte)(j - 1), wb) == 1))
                            {
                                return 1;
                            }

                        if ((i != 0) && (another(pos[i - 1, j - 1], wb) == 1) && (j != 1)) //бой влево
                            if ((g == 1) || (good(pos, i, j, (byte)(i - 1), (byte)(j - 1), wb) == 1))
                            {
                                return 1;
                            }
                        if ((i != 0) && (another(pos[i - 1, j - 1], wb) == 1) && (j == 1))
                            if ((g == 1) || (good(pos, i, j, (byte)(i - 1), (byte)(j - 1), wb) == 1))
                            {
                                return 1;
                            }

                        if ((i != 7) && (another(pos[i + 1, j - 1], wb) == 1) && (j != 1)) //бой вправо
                            if ((g == 1) || (good(pos, i, j, (byte)(i + 1), (byte)(j - 1), wb) == 1))
                            {
                                return 1;
                            }
                        if ((i != 7) && (another(pos[i + 1, j - 1], wb) == 1) && (j == 1))
                            if ((g == 1) || (good(pos, i, j, (byte)(i + 1), (byte)(j - 1), wb) == 1))
                            {
                                return 1;
                            }

                        if ((j == 6) && (pos[i, j - 1] == '\0') && (pos[i, j - 2] == '\0')) // на 2 клетки вперед
                            if ((g == 1) || (good(pos, i, j, i, (byte)(j - 2), wb) == 1))
                            {
                                return 1;
                            }

                        if ((j == 3) && (prohod == i + 1)) // на проходе вправо
                            if (good(pos, i, j, (byte)(i + 1), (byte)(j - 1), wb) == 1)
                            {
                                return 1;
                            }

                        if ((j == 3) && (prohod == i - 1)) // на проходе влево
                            if (good(pos, i, j, (byte)(i - 1), (byte)(j - 1), wb) == 1)
                            {
                                return 1;
                            }
                    }
                    //////////////////////////////////////////////////////////////черная пешка

                }

            
            return 0;
        }

    }
}
