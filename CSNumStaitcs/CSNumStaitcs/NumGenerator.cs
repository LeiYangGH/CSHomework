using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSNumStaitcs
{
    public class NumGenerator
    {
        private int[] nums;
        public NumGenerator(int[] nums)
        {
            this.nums = nums;
        }

        public int[,] Get34Seeds()
        {
            return new int[4, 3]
                   {
                    { nums[0],nums[2],nums[5]},
                    { nums[1],nums[3],nums[5]},
                    { nums[0],nums[3],nums[4]},
                    { nums[1],nums[2],nums[4]},
                   };
        }

        public int[] Result2(int a, int b)
        {
            int r0 = (a + b) % 10;
            int r1 = (a >= b ? a : a + 10) - b;
            return new int[] { r0, r1 };
        }


        public string GetTxt1Line(string description, int a, int b, int c)
        {
            int[] rab = Result2(a, b);
            int[] rbc = Result2(b, c);
            int[] rca = Result2(c, a);
            return $"{description}  {a}{b}{c}-{a}{b}-{b}{c}-{c}{a}={rab[0]}{rab[1]}-{rbc[0]}{rbc[1]}-{rca[0]}{rca[1]}\r\n";
        }

        public string GetNum6String()
        {
            return $"{nums[0]}{nums[1]}{nums[2]}{nums[3]}{nums[4]}{nums[5]}";
        }

        public string GetTxt4Lines()
        {
            int[,] S34 = this.Get34Seeds();
            StringBuilder sb = new StringBuilder();
            sb.Append(GetTxt1Line("奇奇=偶", S34[0, 0], S34[0, 1], S34[0, 2]));
            sb.Append(GetTxt1Line("偶偶=偶", S34[1, 0], S34[1, 1], S34[1, 2]));
            sb.Append(GetTxt1Line("奇偶=奇", S34[2, 0], S34[2, 1], S34[2, 2]));
            sb.Append(GetTxt1Line("偶奇=奇", S34[3, 0], S34[3, 1], S34[3, 2]));
            return sb.ToString();
        }
    }
}
