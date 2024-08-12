using HotelManagement.Business.Implementations;
using HotelManagement.Business.Interfaces;
using HotelManagement.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HotelsController : ControllerBase
{
    private IHotelService _hotelService;
    public HotelsController(IHotelService hotelService)
    {
        _hotelService = hotelService;
    }

    /// <summary>
    /// Returns the supported HTTP methods for this controller.
    /// This method is useful for discovering the capabilities of the API endpoint.
    /// </summary>
    /// <returns></returns>
    [HttpOptions]
    public IActionResult Options()
    {
        Response.Headers.Add("Allow", "Head, Get, Post, Put, Delete");
        return Ok();
    }

    /// <summary>
    /// returns only the headers, without the body
    /// </summary>
    /// <returns></returns>
    [HttpHead]
    public IActionResult Head()
    {
        var getAll = _hotelService.GetAll();
        if (getAll == null || !getAll.Any())
            return NotFound();
        return Ok(getAll);
    }

    /// <summary>
    /// for Getting All Hotels
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    //[Route("[action]")]
    public IActionResult GetHotels()
    {
        var getAll = _hotelService.GetAll();
        if (getAll is null || !getAll.Any())
            return NotFound();
        return Ok(getAll);
    }

    /// <summary>
    /// for Getting A Hotel Which is with the Id you gave
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("[action]/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var hotel = await _hotelService.GetById(id);
            return Ok(hotel);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }

    }

    /*
    [HttpGet]
    [Route("[action]")]
    public IActionResult SearchIdandName(int id, string name)
    {
        return Ok(name);
    }*/

    /// <summary>
    /// for Getting Hotel(s) Which is with the Name you gave(both of a letter or whole of word)
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("[action]/{search}")]
    public IActionResult SearchByName(string search)
    {
        try
        {
            var hotels = _hotelService.SearchByName(search);
            return Ok(hotels);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }

    }

    /// <summary>
    /// Hotel(s) Which is according the Region you gave(Please Enter FullName of that)
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("[action]/{search}")]
    public IActionResult SearchByRegion(string search)
    {
        try
        {
            var hotels = _hotelService.SearchByRegion(search);
            return Ok(hotels);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    /// <summary>
    /// for Adding New Hotel
    /// </summary>
    /// <param name="hotel"></param>
    /// <returns></returns>
    [HttpPost]
    //[Route("[action]")]
    public async Task<IActionResult> Post([FromBody] Hotel hotel)
    {
        try
        {
            await _hotelService.Create(hotel);
            return Ok(hotel);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// for Updating Hotel
    /// </summary>
    /// <param name="hotel"></param>
    /// <returns></returns>
    [HttpPut]
    //[Route("[action]")]
    public async Task<IActionResult> Put([FromBody] Hotel hotel)
    {
        try
        {
            if ((await _hotelService.GetById(hotel.Id)) is null)
                return NotFound();
            await _hotelService.Update(hotel);
            return Ok(hotel);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// for Removing Hotel
    /// </summary>
    /// <param name="id"></param>
    [HttpDelete("{id}")]
    //[Route("[action]/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _hotelService.Delete(id);
            return Ok(id);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }
}