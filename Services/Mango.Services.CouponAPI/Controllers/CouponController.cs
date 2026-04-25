using Microsoft.AspNetCore.Mvc;
using Mango.Services.CouponAPI.Models;

namespace Mango.Services.CouponAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CouponController : ControllerBase
{
    // [HttpGet("{id}")]
    // public ActionResult<CouponDto> GetCoupon(int id)
    // {
    //     // TODO: Implement coupon retrieval logic
    //     return Ok(new CouponDto
    //     {
    //         CouponId = id,
    //         Code = "SAMPLE10",
    //         DiscountAmount = 10,
    //         MinAmount = 100
    //     });
    // }

    // [HttpPost]
    // public ActionResult<CouponDto> CreateCoupon(CouponDto couponDto)
    // {
    //     // TODO: Implement coupon creation logic
    //     return CreatedAtAction(nameof(GetCoupon), new { id = couponDto.CouponId }, couponDto);
    // }
}
