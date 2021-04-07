using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MISA.Core.Interfaces;

namespace MISA.Core.Services
{
    public class BaseService<MISAEntity> : IBaseService<MISAEntity>
    {
        IBaseRepository<MISAEntity> _baseRepository;
        public BaseService(IBaseRepository<MISAEntity> baseRepository)
        {
            _baseRepository = baseRepository;
        }
        public virtual int Delete(Guid entityId)
        {
            throw new NotImplementedException();
        }

        public MISAEntity GetById(Guid entityId)
        {
            var entity = _baseRepository.GetById(entityId);
            return entity;
        }

        public IEnumerable<MISAEntity> GetEntities()
        {
            var entities = _baseRepository.GetEntities();
            return entities;
        }

        public int Insert(MISAEntity entity)
        {
            //validate
            ValidateEntity(entity, "insert");
            //them moi
            
            var entities = _baseRepository.Insert(entity);
            return entities;
        }

        public virtual int UpDate(MISAEntity entity, Guid entityId)
        {
            throw new NotImplementedException();
        }

        public virtual bool ValidateEntity(MISAEntity entity, string fun)
        {
            return true;
        }
     }
}
