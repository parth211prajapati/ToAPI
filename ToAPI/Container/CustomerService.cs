/*using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ToAPI.Helper;
using ToAPI.Modal;
using ToAPI.Repos;
using ToAPI.Repos.Models;
using ToAPI.Service;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ToAPI.Container
{
    public class CustomerService : ICustomerService
    {

        public readonly LearndataContextb context;
        private readonly IMapper mapper;
        public CustomerService(LearndataContextb context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public string Code { get; private set; }

        public async Task<APIResponse> Create(CustomerModal data)
        { 
            APIResponse response = new APIResponse();
            try
            {

                TblCustomer _customer = this.mapper.Map<CustomerModal, TblCustomer>(data);
                await this.context.TblCustomers.AddAsync(_customer);
                await this.context.SaveChangesAsync();
                response.ResponseCode = 201;
                response.Result = data.Code;
            }
            catch (Exception ex)
            {
                response.ResponseCode = 400;
                response.Errormessage = ex.Message;
            }
            return response;
        }

        public async Task<CustomerModal> Getabycode(string code)
        {
            CustomerModal _response = new CustomerModal();
            var _data = await this.context.TblCustomers.FindAsync(code);
            if (_data != null)
            {
                _response = this.mapper.Map<TblCustomer,CustomerModal>(_data);

            }
            return _response;
        }

        public async Task< List<CustomerModal>> Getall()
        {
            List<CustomerModal> _response = new List<CustomerModal>();
            var _data = await   this.context.TblCustomers.ToListAsync();
            if(_data != null)
            {
                _response=this.mapper.Map<List<TblCustomer>,List<CustomerModal>>(_data);

            }
            return _response;
        }

        public Task Getcode(string code)
        {
            throw new NotImplementedException();
        }

        public async Task<APIResponse> Remove(string code)
        {
            APIResponse response = new APIResponse();
            try
            {

           
                var _customer=await this.context.TblCustomers.FindAsync(code);
                if(_customer != null)
                {
                    this.context.TblCustomers.Remove(_customer);
                    await this.context.SaveChangesAsync();
                    response.ResponseCode = 201;
                    response.Result = Code;
                }

                else
                {

                    response.ResponseCode = 404;
                    response.Errormessage = "Data Not Found";

                }
             
            }
            catch (Exception ex)
            {
                response.ResponseCode = 400;
                response.Errormessage = ex.Message;
            }
            return response;
        }

        public async Task<APIResponse> Update(CustomerModal data, string code)
        {
            APIResponse response = new APIResponse();
            try
            {


                var _customer = await this.context.TblCustomers.FindAsync(code);
                if (_customer != null)
                {

                    _customer.Name = data.Name;
                    _customer.Email = data.Email;
                    _customer.Phone = data.Phone;
                    _customer.IsActive = data.IsActive;
                    _customer.Creditlimit = data.Creditlimit;

                    await this.context.SaveChangesAsync();
                    response.ResponseCode = 201;
                    response.Result = Code;
                }

                else
                {

                    response.ResponseCode = 404;
                    response.Errormessage = "Data Not Found";

                }

            }
            catch (Exception ex)
            {
                response.ResponseCode = 400;
                response.Errormessage = ex.Message;
            }
            return response;
        }

        Task<List<CustomerModal>> ICustomerService.Getabycode(string code)
        {
            throw new NotImplementedException();
        }
    }
}*/


using AutoMapper;
using LearnAPI.Service;
using Microsoft.EntityFrameworkCore;
using ToAPI.Helper;
using ToAPI.Modal;
using ToAPI.Repos;
using ToAPI.Repos.Models;

using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ToAPI.Container
{
    public class CustomerService : ICustomerService
    {
        private readonly LearndataContextb context;
        private readonly IMapper mapper;
        private readonly ILogger<CustomerService> logger;

        public CustomerService(LearndataContextb context, IMapper mapper, ILogger<CustomerService> logger)
        {
            this.context = context;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<APIResponse> Create(CustomerModal data)
        {
            APIResponse response = new APIResponse();
            try
            {
                this.logger.LogInformation("Create Begins");
                TblCustomer _customer = this.mapper.Map<CustomerModal, TblCustomer>(data);
                await this.context.TblCustomers.AddAsync(_customer);
                await this.context.SaveChangesAsync();
                response.ResponseCode = 201;
                response.Result = data.Code;
            }
            catch (Exception ex)
            {
                response.ResponseCode = 400;
                response.Message = ex.Message;
                this.logger.LogError(ex.Message, ex);
            }
            return response;
        }

        public Task<List<CustomerModal>> Getabycode(string code)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CustomerModal>> Getall()
        {
            List<CustomerModal> _response = new List<CustomerModal>();
            var _data = await this.context.TblCustomers.ToListAsync();
            if (_data != null)
            {
                _response = this.mapper.Map<List<TblCustomer>, List<CustomerModal>>(_data);
            }
            return _response;
        }

        public async Task<CustomerModal> Getbycode(string code)
        {
            CustomerModal _response = new CustomerModal();
            var _data = await this.context.TblCustomers.FirstOrDefaultAsync(c => c.Code == code);
            if (_data != null)
            {
                _response = this.mapper.Map<TblCustomer, CustomerModal>(_data);
            }
            return _response;
        }

        public Task Getcode(string code)
        {
            throw new NotImplementedException();
        }

        public async Task<APIResponse> Remove(string code)
        {
            APIResponse response = new APIResponse();
            try
            {

                var _customer = await this.context.TblCustomers.FindAsync(code);
                if (_customer != null)
                {
                    this.context.TblCustomers.Remove(_customer);
                    await this.context.SaveChangesAsync();
                    response.ResponseCode = 200;
                    response.Result = code;
                }
                else
                {
                    response.ResponseCode = 404;
                    response.Message = "Data not found";
                }

            }
            catch (Exception ex)
            {
                response.ResponseCode = 400;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<APIResponse> Update(CustomerModal data, string code)
        {
            APIResponse response = new APIResponse();
            try
            {
                var _customer = await this.context.TblCustomers.FindAsync(code);
                if (_customer != null)
                {
                    _customer.Name = data.Name;
                    _customer.Email = data.Email;
                    _customer.Phone = data.Phone;
                    _customer.IsActive = data.IsActive;
                    _customer.Creditlimit = data.Creditlimit;
                    await this.context.SaveChangesAsync();
                    response.ResponseCode = 200;
                    response.Result = code;
                }
                else
                {
                    response.ResponseCode = 404;
                    response.Message = "Data not found";
                }

            }
            catch (Exception ex)
            {
                response.ResponseCode = 400;
                response.Message = ex.Message;
            }
            return response;
        }

     
    }
}
