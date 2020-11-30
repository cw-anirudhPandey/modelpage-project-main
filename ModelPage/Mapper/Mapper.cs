using AutoMapper;
using System.Collections.Generic;
using ModelPage.Entities;
using ModelPage.DTO;
using System.Linq;

namespace ModelPage.Mapper
{
  public class ModelMapper
  {
    public static CarDetailsDTO Convert(CarModelDetails details)
    {
      // var result = new CarDetailsDTO();
      var config = new MapperConfiguration(cfg =>
      {
        cfg.CreateMap<CarModelDetails, CarDetailsDTO>();
        cfg.CreateMap<Make, MakeDTO>();
        cfg.CreateMap<Model, ModelDTO>();
        cfg.CreateMap<CarImage, ImageDTO>();
        cfg.CreateMap<Review, ReviewDTO>();
        cfg.CreateMap<CarCity, CarCityDTO>();
        cfg.CreateMap<CarVersion, CarVersionDTO>();
        cfg.CreateMap<CarPrice, PriceDetailsDTO>();
      });
      IMapper iMapper = config.CreateMapper();
      var result = iMapper.Map<CarModelDetails, CarDetailsDTO>(details);
      var make = iMapper.Map<Make, MakeDTO>(details.MakeDetail);
      result.CarMake = make;
      var model = iMapper.Map<Model, ModelDTO>(details.ModelDetail);
      result.CarModel = model;
      var image = iMapper.Map<CarImage, ImageDTO>(details.ImageDetail);
      result.CarImage = image;
      var review = iMapper.Map<Review, ReviewDTO>(details.ReviewDetail);
      result.CarReview = review;
      var cityList = iMapper.Map<IEnumerable<CarCity>, IEnumerable<CarCityDTO>>(details.CitySet);
      result.CitySet = cityList;
      var versionList = iMapper.Map<IEnumerable<CarVersion>, IEnumerable<CarVersionDTO>>(details.VersionSet);
      result.VersionSet = versionList;
      var priceList = iMapper.Map<List<CarPrice>, List<PriceDetailsDTO>>(details.PriceDetailList.ToList());
      result.CarPriceDetails = priceList;
      return result;
    }

    public static IEnumerable<PriceDetailsDTO> Convert(IEnumerable<CarPrice> voucher)
    {
      var config = new MapperConfiguration(cfg =>
      {
        cfg.CreateMap<CarPrice, PriceDetailsDTO>();
      });
      IMapper iMapper = config.CreateMapper();
      return iMapper.Map<IEnumerable<CarPrice>, IEnumerable<PriceDetailsDTO>>(voucher);
    }
  }
}


