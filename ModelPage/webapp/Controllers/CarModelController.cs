using Microsoft.AspNetCore.Mvc;
using AEPLCore.Logging;
using System;
using System.Threading.Tasks;
using ModelPage.Business;
using ModelPage.DTO;
using ModelPage.Entities;
using System.Collections;
using System.Collections.Generic;

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
    [Route("model/{id?}")]
    public async Task<CarModelDetails> Get(int id)
    {
      try
      {
        var details = await _modelPageLogic.GetModelPageData(id);
        return details;
      }
      catch (Exception ex)
      {
        _logger.LogException(ex);
        return new CarModelDetails();
      }
    }

    [HttpGet]
    [Route("/price/{cityId}")]
    public async Task<IEnumerable<CarPrice>> GetPriceByCityId(int cityId)
    {
      try
      {
        await _modelPageLogic.GetPriceListByCityId(cityId);
        IEnumerable<CarPrice> details = await _modelPageLogic.GetPriceListByCityId(cityId);
        return details;
      }
      catch (Exception ex)
      {
        _logger.LogException(ex);
        return new List<CarPrice>();
      }
    }
  }
}

