using Mapster;
using Pharamcy.Application.Features.SaleInvoice.Commands.SaveSaleInvoceCommand;
using Pharamcy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharamcy.Application.Common.Mapping
{
    public class SaleInvoiceMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<SaveSaleInvoceCommand, SalesInvoice>().Map(i=>i.ClientId,i=>i.ClientId==0?null:i.ClientId);
        }
    }
}
