using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventick.Integration.Messages;

public class IntegrationBaseMessage
{
    public Guid Id { get; set; }
    public DateTime CreationDateTime { get; set; }
}