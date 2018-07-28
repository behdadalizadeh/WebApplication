using Alamut.Data.Linq;
using Alamut.Data.Paging;
using Alamut.Helpers.Linq;
using Alamut.Data.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebApplication.Core.DTO.Pagination;
using WebApplication.Core.DTO.Users;
using AutoMapper.QueryableExtensions;
using WebApplication.Core.ViewModel.Users;
using AutoMapper;
using WebApplication.Core.Entities;

namespace WebApplication.Data.Repository
{
    public class UsersRepository
    {
        private readonly ApplicationContext _context;
        public UsersRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IPaginated<UsersSummaryDTO> GetAll(Pagination vm)
        {
            return _context.Users
                .WhereIf(!string.IsNullOrWhiteSpace(vm.Term1) ||
                         !string.IsNullOrWhiteSpace(vm.Term2)
                 , p => (!string.IsNullOrWhiteSpace(vm.Term1) && p.Name != null && p.Name.Contains(vm.Term1)) ||
                        (!string.IsNullOrWhiteSpace(vm.Term2) && p.Family != null && p.Family.Contains(vm.Term2)))
                .OrderByDescending(p => p.Id)
                .ProjectTo<UsersSummaryDTO>()
                .ToPaginated(new PaginatedCriteria(vm.Page, vm.PageSize));
        }

        public Users GetById(int id)
        {
            return _context.Users.Find(id);
        }

        public ServiceResult<int> Create(UsersCreateViewModel vm)
        {
            var entity = Mapper.Map<Users>(vm);
            _context.Users.Add(entity);
            _context.SaveChanges();
            return ServiceResult<int>.Okay(data: entity.Id, message: "عملیات با موفقیت انجام شد.");
        }

        public ServiceResult<int> Edit(int id,UsersEditViewModel vm)
        {
            var entity = GetById(id);
            Mapper.Map(vm, entity);
            _context.SaveChanges();
            return ServiceResult<int>.Okay(data: id, message: "عملیات با موفقیت انجام شد.");
        }

        public ServiceResult<int> Delete(int id)
        {
            var entity = GetById(id);
            _context.Users.Remove(entity);
            return ServiceResult<int>.Okay(data: id, message: "عملیات با موفقیت انجام شد.");
        }
    }
}