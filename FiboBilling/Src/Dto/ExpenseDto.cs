using FiboInfraStructure.Src;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace FiboBilling.Src.Dto
{
    public class ExpenseDto : BaseDto
    {
        public string Name { get; set; }
        public string Miti { get; set; }
        public DateTime? Date { get; set; }
        public decimal Amount { get; set; }
        public bool IsExpense { get; set; }
        public List<ExpenseDetailDto> ExpenseDetailDtos { get; set; }
    }
}
