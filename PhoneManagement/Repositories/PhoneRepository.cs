using Microsoft.EntityFrameworkCore;
using PhoneManagement.Common;
using PhoneManagement.Data;
using PhoneManagement.Dtos;
using PhoneManagement.Entitys;
using System.Data;

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

        public async Task<bool> AddAsync(PhoneDto dto)
        {
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = SqlConstants.AddPhoneProcedure; // Sử dụng hằng số
                command.CommandType = CommandType.StoredProcedure;

                // Thêm các tham số
                var modelParam = command.CreateParameter();
                modelParam.ParameterName = SqlConstants.ParamModel; // Sử dụng hằng số
                modelParam.Value = dto.Model ?? (object)DBNull.Value;
                command.Parameters.Add(modelParam);

                var priceParam = command.CreateParameter();
                priceParam.ParameterName = SqlConstants.ParamPrice; // Sử dụng hằng số
                priceParam.Value = dto.Price;
                command.Parameters.Add(priceParam);

                var stockParam = command.CreateParameter();
                stockParam.ParameterName = SqlConstants.ParamStock; // Sử dụng hằng số
                stockParam.Value = dto.Stock;
                command.Parameters.Add(stockParam);

                var brandIdParam = command.CreateParameter();
                brandIdParam.ParameterName = SqlConstants.ParamBrandId; // Sử dụng hằng số
                brandIdParam.Value = dto.BrandId.HasValue ? (object)dto.BrandId.Value : DBNull.Value;
                command.Parameters.Add(brandIdParam);

                var resultParam = command.CreateParameter();
                resultParam.ParameterName = SqlConstants.ParamResult; // Sử dụng hằng số
                resultParam.Value = 0;
                resultParam.Direction = ParameterDirection.Output;
                resultParam.DbType = DbType.Boolean;
                command.Parameters.Add(resultParam);

                if(command is null && command?.Connection is null)
                {
                    return false;
                }

                // Mở kết nối và thực thi
                if (command.Connection!.State != ConnectionState.Open)
                {
                    await command.Connection.OpenAsync();
                }

                await command.ExecuteNonQueryAsync();

                // Lấy giá trị trả về
                var result = (bool)command.Parameters[SqlConstants.ParamResult].Value!;
                return result;
            }
        }
    }
}
