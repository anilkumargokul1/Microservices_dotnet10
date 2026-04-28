using AutoMapper;
using Mango.Services.CouponAPI.Data;
using Mango.Services.CouponAPI.Models;
using Mango.Services.CouponAPI.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.CouponAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponAPIController : ControllerBase
    {
        private readonly AppDBContext _db;
        private ResponseDto _response;
        private IMapper _mapper;
        public CouponAPIController(AppDBContext db, IMapper mapper)
        {
            _db=db;
            _response=new ResponseDto();
            _mapper=mapper;
        }
        [HttpGet]
        public ResponseDto get()
        {
            try
            {
                IEnumerable<Coupon> coupons=_db.Coupons.ToList();
                _response.Result=_mapper.Map<IEnumerable<CouponDto>>(coupons);
            }
            catch (Exception ex)
            {
                _response.IsSuccess=false;
                _response.Message=ex.Message;
            }
            return _response;
        }
        [HttpGet]
        [Route("{id:int}")]
        public ResponseDto get(int id)
        {
            try
            {
                Coupon coupon=_db.Coupons.FirstOrDefault(x=>x.CouponId==id);
                _response.Result=_mapper.Map<CouponDto>(coupon);
            }
            catch (Exception ex)
            {
                 _response.IsSuccess=false;
                _response.Message=ex.Message;
            }
            return _response;
        }
        [HttpGet]
        [Route("GetByCode{code}")]
        public ResponseDto getbyCode(string code)
        {
            try
            {
                Coupon coupon=_db.Coupons.First(x=>x.CouponCode.ToLower()==code.ToLower());
                _response.Result=_mapper.Map<CouponDto>(coupon);
            }
            catch (Exception ex)
            {
                 _response.IsSuccess=false;
                _response.Message=ex.Message;
            }
            return _response;
        }
        [HttpPost]
        public ResponseDto Post([FromBody] CouponDto couponDto)
        {
            try
            {
                Coupon coupon= _mapper.Map<Coupon>(couponDto);
                _db.Coupons.Add(coupon);
                _db.SaveChanges();
                _response.Result=_mapper.Map<CouponDto>(coupon);
            }
            catch (Exception ex)
            {
                 _response.IsSuccess=false;
                _response.Message=ex.Message+ex.InnerException.Message;
            }
            return _response;
        }
        [HttpPut]
        public ResponseDto Put([FromBody] CouponDto couponDto)
        {
            try
            {
                Coupon coupon= _mapper.Map<Coupon>(couponDto);
                _db.Coupons.Update(coupon);
                _db.SaveChanges();
                _response.Result=_mapper.Map<CouponDto>(coupon);
            }
            catch (Exception ex)
            {
                 _response.IsSuccess=false;
                _response.Message=ex.Message;
            }
            return _response;
        }
        [HttpDelete]
        [Route("{id:int}")]
        public ResponseDto Delete(int id)
        {
            try
            {
                Coupon coupon= _db.Coupons.First(x=>x.CouponId==id);
                _db.Coupons.Remove(coupon);
                _db.SaveChanges();
                _response.Result=_mapper.Map<CouponDto>(coupon);
            }
            catch (Exception ex)
            {
                 _response.IsSuccess=false;
                _response.Message=ex.Message+ex.InnerException.Message;
            }
            return _response;
        }
    }
}
