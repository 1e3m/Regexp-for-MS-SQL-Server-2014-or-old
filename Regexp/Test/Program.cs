﻿using System;
using System.Collections;


namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {         
            ArrayList arr; ;
            arr = (ArrayList)Regexp.Run("(FL_S2_3_M1_Q_r_k < 5) & (FL_S2_3_M2_Q_r_k < 5) ? 0 : FL_S2_M1_2.Q_sd * OF_KC_sd * 600 / (FL_S2_3_M1_Q_r_k + FL_S2_3_M2_Q_r_k)", "[A-z][A-z0-9.]*");
            Console.ReadKey();
        }
    }
}
