using Microsoft.EntityFrameworkCore;
using SampleCoreBank.Core.Domain.CoreBank.Interfaces.Infrastructures.Data;

namespace SampleCoreBank.Infrastructures.Data.CoreBank
{
    public class CoreBankDbContextReader : Reader, ICoreBankDbContextReader
    {
        public CoreBankDbContextReader(CoreBankDbContext context) : base(context)
        {
        }
    }
}