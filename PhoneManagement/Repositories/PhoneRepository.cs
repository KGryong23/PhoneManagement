using PhoneManagement.Data;
using PhoneManagement.Entitys;

namespace PhoneManagement.Repositories
{
    /// <summary>
    /// Repository cho Phone, kế thừa Generic Repository
    /// </summary>
    public class PhoneRepository : Repository<Phone>, IPhoneRepository
    {
        public PhoneRepository(PhoneContext context) : base(context)
        {
        }
    }
}
