using FiboBilling.Src.Dto;
using FiboInfraStructure.Entity.FiboBilling;
using System;
using System.Collections.Generic;
using System.Text;
using FiboInfraStructure;
namespace FiboBilling.InfraStructure.Assembler
{
    public interface IBillingAssembler
    {
        void copyTo(Billing billing, BillingDto dto);
        void copyFrom(BillingDto dto, Billing billing);
        void modifyTo(Billing billing, BillingDto dto);
    }

    public class BillingAssembler : IBillingAssembler
    {
        public void copyFrom(BillingDto dto, Billing billing)
        {
            dto.Id = billing.Id;
            dto.CreatedBy = billing.CreatedBy;
            dto.CreatedDate = billing.CreatedDate;
            dto.BillingAmount = billing.BillingAmount;
            dto.ClientId = billing.ClientId;
            dto.YearId = billing.YearId;
            dto.DueAmount = billing.DueAmount;
            dto.DueDate = billing.DueDate.ToNepDate();
            dto.Fine = billing.Fine;
            dto.Discount = billing.Discount;
            dto.CashReceived = billing.CashReceived;
            dto.IsRent = billing.IsRent;
            dto.IsElectricity = billing.IsElectricity;
            dto.ElectricityFineAmount = billing.ElectricityFineAmount;
            dto.GrandTotal = billing.GrandTotal;
            dto.BillNo = billing.BillNo;
            dto.IsDue = billing.IsDue;
            dto.MaintenanceCharge = billing.MaintenanceCharge;
            dto.DuePaid = billing.DuePaid;
        }

        public void copyTo(Billing billing, BillingDto dto)
        {
            billing.CreatedBy = dto.CreatedBy;
            billing.CreatedDate = DateTime.Now;
            billing.BillingAmount = dto.BillingAmount;
            billing.ClientId = dto.ClientId;
            billing.YearId = (long?)dto.YearId;
            billing.DueAmount = dto.DueAmount;
            billing.DueDate = dto.DueDate.ToEnglishDate();
            billing.Fine = dto.Fine;
            billing.Discount = dto.Discount;
            billing.CashReceived = dto.CashReceived;
            billing.IsRent = dto.IsRent;
            billing.IsElectricity = dto.IsElectricity;
            billing.ElectricityFineAmount = dto.ElectricityFineAmount;
            billing.GrandTotal = dto.GrandTotal;
            billing.BillNo = dto.BillNo;
            billing.IsDue = dto.IsDue;
            billing.MaintenanceCharge = dto.MaintenanceCharge;
            billing.DuePaid = dto.DuePaid;
        }

        public void modifyTo(Billing billing, BillingDto dto)
        {
            billing.Id = dto.Id;
            billing.CreatedBy = dto.CreatedBy;
            billing.CreatedDate = DateTime.Now;
            billing.ModifiedBy = dto.ModifiedBy;
            billing.ModifiedDate = DateTime.Now;
            billing.BillingAmount = dto.BillingAmount;
            billing.ClientId = dto.ClientId;
            billing.YearId = (long?)dto.YearId;
            billing.DueAmount = dto.DueAmount;
            billing.DueDate = dto.DueDate.ToEnglishDate();
            billing.Fine = dto.Fine;
            billing.Discount = dto.Discount;
            billing.CashReceived = dto.CashReceived;
            billing.IsRent = dto.IsRent;
            billing.IsElectricity = dto.IsElectricity;
            billing.ElectricityFineAmount = dto.ElectricityFineAmount;
            billing.GrandTotal = dto.GrandTotal;
            billing.BillNo = dto.BillNo;
            billing.IsDue = dto.IsDue;
            billing.MaintenanceCharge = dto.MaintenanceCharge;
            billing.DuePaid = dto.DuePaid;
        }
    }
}
