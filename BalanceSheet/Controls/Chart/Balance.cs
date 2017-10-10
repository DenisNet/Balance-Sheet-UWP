using BalanceSheet.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalanceSheet.Controls.Chart
{
    class Balance
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Percentage { get; set; }
    }
}