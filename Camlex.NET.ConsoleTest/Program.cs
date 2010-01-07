﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Xml.Linq;
using Microsoft.SharePoint;


namespace Camlex.NET
{
    class Program
    {
        static void Main(string[] args)
        {
            Camlex
                .Query()
                    .Where(x => x["User"] == (DataTypes.User)"John Smith" && (int)x["foo"] >= 1)
                    .OrderBy(x => x["field1"] as Camlex.Asc)
                    .GroupBy(x => new[] { x["field1"], x["field2"] }, true, 10);
        }
    }
}
