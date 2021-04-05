using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Interfaces
{
    /// <summary>
    /// Base repository / thao tác với database
    /// </summary>
    /// <typeparam name="MISAEntity">kieur của thực thể truyền vào</typeparam>
    /// CreatedBy:HuongDoll 05/04/2021
    public interface IBaseRepository<MISAEntity>
    {
        /// <summary>
        /// Lấy toàn bộ dữ liệu
        /// </summary>
        /// <returns>danh sách đối tượng</returns>
        /// CreatedBy:HuongDoll 05/04/2021
        IEnumerable<MISAEntity> GetEntities();
        /// <summary>
        /// Lấy dữ liệu dựa theo id
        /// </summary>
        /// <param name="entityId">id cua dữ liệu cần lấy</param>
        /// <returns>đối tượng</returns>
        /// CreatedBy:HuongDoll 05/04/2021
        MISAEntity GetById(Guid entityId);
        /// <summary>
        /// thêm mới đối tượng
        /// </summary>
        /// <param name="entity">thực thẻ đối tượng</param>
        /// <returns>số bản ghi mới được thêm vào</returns>
        /// CreatedBy:HuongDoll 05/04/2021
        int Insert(MISAEntity entity);
        /// <summary>
        /// chỉnh sửa thông tin đối tượng
        /// </summary>
        /// <param name="entity">thực thể đối tượng cần chỉnh sửa</param>
        /// <param name="entityId">id tham chiếu đến đối tượng cần chỉnh sửa</param>
        /// <returns>số bản ghi được chỉ sửa</returns>
        /// CreatedBy:HuongDoll 05/04/2021
        int UpDate(MISAEntity entity, Guid entityId);
        /// <summary>
        /// xóa thông tin đối tượng
        /// </summary>
        /// <param name="entityId">id tham chiếu đến đối tượng cần xóa</param>
        /// <returns>số bản ghi được xóa thành công</returns>
        /// CreatedBy:HuongDoll 05/04/2021
        int Delete(Guid entityId);

    }
}
