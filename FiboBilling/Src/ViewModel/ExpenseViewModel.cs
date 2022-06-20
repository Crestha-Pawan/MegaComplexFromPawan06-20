
using FiboInfraStructure.Entity.FiboBilling;
using FiboInfraStructure.Entity.FiboOffice;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FiboBilling.Src.ViewModel
{
    public class ExpenseViewModel
    {
        public List<Expense> Expenses { get; set; }
        public List<ExpenseViewModel> ExpenseVMList { get; set; }
        public List<ExpenseDetail> ExpenseDetails { get; set; }
        public List<Month> MonthList { get; set; }
        public long? YearId { get; set; }
        public long? MonthId { get; set; }
        [NotMapped]
        public DateTime? FromDate { get; set; }
        [NotMapped]
        public DateTime? ToDate { get; set; }
        [NotMapped]
        public string FromMiti { get; set; }
        [NotMapped]
        public string ToMiti { get; set; }
        public string ActionName { get; set; }
        public IList<Year> Years { get; set; } = new List<Year>();
        public SelectList YearList => new SelectList(Years, nameof(Year.Id), nameof(Year.YearName));

    }
}
