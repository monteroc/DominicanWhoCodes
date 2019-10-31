using System;
using System.Threading.Tasks;

namespace DominicanWhoCodes.Services
{
    public interface IEssentialsService
    {
        Task OpenBrowserAsync(Uri uri);
    }
}
