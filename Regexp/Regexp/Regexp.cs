using System;
using System.Text.RegularExpressions;
using System.Data.SqlTypes; 
using System.Collections;
using Microsoft.SqlServer.Server;  

    public partial class Regexp
    {
        private class TblResult
        {
            public SqlInt32 NId;
            public SqlString CStr;

            public TblResult(SqlInt32 nId, SqlString cStr)
            {
                NId = nId;
                CStr = cStr;
            }
        }

       [SqlFunction(
       DataAccess = DataAccessKind.Read,
       FillRowMethodName = "Run_FillRow",
       TableDefinition = "nId int, cStr nvarchar(MAX)")]  
        public static IEnumerable Run(SqlString lot_no, SqlString regExpr)
        {
            if (lot_no == null) return null;
            if (regExpr == null) return null;
            string pattern = (String)regExpr;
            Regex rgx = new Regex(pattern, RegexOptions.Multiline);
            MatchCollection matches = rgx.Matches((String)lot_no);
            if (matches.Count > 0)
            {                
                ArrayList reslt = new ArrayList();
                ArrayList t = new ArrayList();
                int i = 1;
                foreach (Match Val in rgx.Matches((String)lot_no))
                {
                    t.Add(!CheckArrayList(reslt, Val.Groups[0].Value));
                    if (!CheckArrayList(reslt, Val.Groups[0].Value))
                    {
                        reslt.Add(new TblResult(i, Val.Groups[0].Value));
                        i++;
                    }
                }
                return reslt;
            }
            return null;
        }

        private static bool CheckArrayList(ArrayList reslt, string s)
        {
            foreach (var item in reslt)
            {
                var o = (TblResult)item;
                if (o.CStr.ToString() == s)
                    return true;
            }
            return false;
        }

        public static void Run_FillRow(
        object tblResultObj,
        out SqlInt32 nId,
        out SqlString cStr)
        {
            TblResult tblResult = (TblResult)tblResultObj;

            nId = tblResult.NId;
            cStr = tblResult.CStr;
        }  
    }
