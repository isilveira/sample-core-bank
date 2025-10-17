using Microsoft.EntityFrameworkCore;
using SampleCoreBank.Core.Domain.CoreBank.Interfaces.Infrastructures.Data;

namespace SampleCoreBank.Infrastructures.Data.CoreBank
{
    public class CoreBankDbContextWriter : Writer, ICoreBankDbContextWriter
    {
        public CoreBankDbContextWriter(CoreBankDbContext context) : base(context)
        {
        }
    }
}