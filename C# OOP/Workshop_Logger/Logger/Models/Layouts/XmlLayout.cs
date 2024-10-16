﻿

using System;
using System.Text;
using Logger.Contracts;

namespace Logger.Layouts
{
    public class XmlLayout : ILayout
    {
        public string Format => GetFormat();

        private string GetFormat()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("<log>")
                .AppendLine("\t<date>{0}</date>")
                .AppendLine("\t<level>{1}</level>")
                .AppendLine("\t<message>{2}</message>")
                .AppendLine("</log >");

            return sb.ToString().TrimEnd();
        }
    }
}
