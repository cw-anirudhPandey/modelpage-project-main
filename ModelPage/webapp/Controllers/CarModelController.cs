using Microsoft.AspNetCore.Mvc;
using AEPLCore.Logging;
using System;
using System.Threading.Tasks;
using ModelPage.Business;
using ModelPage.Mapper;
using Microsoft.AspNetCore.Http;

namespace webapp.Controllers
{
  public class CarModelController : ControllerBase
  {
    private readonly Logger _logger = LoggerFactory.GetLogger(typeof(CarModelController));
    private readonly IModelPageLogic _modelPageLogic;

    public CarModelController(IModelPageLogic modelPageLogic)
    {
      _modelPageLogic = modelPageLogic;
    }

    [HttpGet]
    [Route("api/model/{id}")]
    public async Task<IActionResult> GetModelPageData(int id)
    {
      try
      {
        if (id >= 0)
        {
          return Ok(ModelMapper.Convert(await _modelPageLogic.GetModelPageData(id)));
        }
        else
        {
          return BadRequest("Invalid ModelId Data Requested.");
        }
      }
      catch (Exception ex)
      {
        _logger.LogException(ex);
        return StatusCode(StatusCodes.Status500InternalServerError, ex);
      }
    }


    [HttpGet]
    [Route("api/price/{cityId}")]
    public async Task<IActionResult> GetPriceByCityId(int cityId)
    {
      try
      {
        if (cityId >= 0)
        {
          return Ok(ModelMapper.Convert(await _modelPageLogic.GetPriceListByCityId(cityId)));
        }
        else
        {
          return BadRequest("Invalid CityId Data Requested.");
        }
      }
      catch (Exception ex)
      {
        _logger.LogException(ex);
        return StatusCode(StatusCodes.Status500InternalServerError, ex);
      }
    }

  }
}

