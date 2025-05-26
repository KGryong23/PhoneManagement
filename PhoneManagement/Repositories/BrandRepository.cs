using PhoneManagement.Data;
using PhoneManagement.Entitys;

namespace PhoneManagement.Repositories
{
    /// <summary>
    /// Repository cho Brand, kế thừa Generic Repository
    /// </summary>
    public class BrandRepository : Repository<Brand>, IBrandRepository
    {
        public BrandRepository(PhoneContext context) : base(context)
        {
        }
    }
}
