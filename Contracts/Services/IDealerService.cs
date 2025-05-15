using Contracts.Entities;
using System.Collections.Generic;

namespace Contracts.Services
{
    public interface IDealerService
    {
        void UpdateVehicle(IEnumerable<IVehicle> vehicles, IInterviewUserContex userContex);
    }
}