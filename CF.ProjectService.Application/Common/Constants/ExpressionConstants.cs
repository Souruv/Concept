using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ProjectService.Application.Common.Constants
{
    public static class ExpressionConstants
    {
        //public static string[] BinaryOperator = new string[4] { "+", "-", "/", "*" };
        public static string[] UnaryOperatorList = { "++", "--" };
        public static string[] BinaryOperatorList = { "<", "=",">","<>","<=", ">=" ,"&"
        , "+" , "-" , "/" , "*","^"
        };
        public static string[] FunctionList = { "if(", "and(", "or(","max(","match(","even(", "concat(" };
    }
}
