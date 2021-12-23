using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MelStore.Brokers.DateTimeBrokers
{
  public class DateProvider : IDateProvider
  {
    public DateTime ObterDataAtual()
    {
      return DateTime.Now;
    }
  }
}
