using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using ModelPage.Entities;
using Xunit;

namespace ModelPage.UnitTests.ModelPageLogic
{
  public class GetModelPageData : Base
  {
    private Review GetMockReview()
    {
      return new Review()
      {
        ModelId = 1,
        Rating = 3.5,
        Count = 12,
      };
    }
    private CarImage GetMockImage()
    {
      return new CarImage()
      {
        Id = 0,
        ModelId = 2,
        ImageUrl = "https://images.unsplash.com/photo-1553440569-bcc63803a83d?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=711&q=80"
      };
    }
    private List<CarCity> GetMockCityList()
    {
      return new List<CarCity>()
            {
              new CarCity
              {
                Id = 1,
                Name = "Mumbai"
              }
            };
    }
    private Make GetMockMake()
    {
      return new Make()
      {
        Id = 1,
        MakeName = "Mercedes-Benz"
      };
    }
    private Model GetMockModel()
    {
      return new Model()
      {
        Id = 2,
        ModelName = "AMG"
      };
    }
    private CarVersion GetMockVersion()
    {
      return new CarVersion()
      {
        Id = 1,
        ModelId = 4,
        Name = "GT"
      };
    }
    private List<CarVersion> GetMockVersionList()
    {
      return new List<CarVersion>()
            {
              new CarVersion
              {
                Id = 1,
                ModelId = 4,
                Name = "GT"
              }
            };
    }
    private CarPrice GetMockPrice()
    {
      return new CarPrice()
      {
        Id = 1,
        VersionId = 6,
        CityId = 12,
        Value = "530450"
      };
    }
    private List<CarPrice> GetMockPriceList()
    {
      return new List<CarPrice>()
            {
              new CarPrice
              {
                Id = 1,
                VersionId = 6,
                CityId = 12,
                Value = "530450"
              }
            };
    }
    private CarModelDetails GetMockCarDetails()
    {
      return new CarModelDetails()
      {
        MakeDetail = GetMockMake(),
        ModelDetail = GetMockModel(),
        ImageDetail = GetMockImage(),
        ReviewDetail = GetMockReview(),
        VersionSet = GetMockVersionList(),
        CitySet = GetMockCityList(),
        PriceDetailList = GetMockPriceList()
      };
    }

    [Fact]
    public async Task GetModelPageData_DataNotEmpty_ReturnNotEmpty()
    {
      var carDetailsItem = GetMockCarDetails();
      _mmvRepository.Setup(x => x.GetMake(It.IsAny<int>())).ReturnsAsync(GetMockMake());
      _mmvRepository.Setup(x => x.GetModel(It.IsAny<int>())).ReturnsAsync(GetMockModel());
      _mmvRepository.Setup(x => x.GetVersionList(It.IsAny<int>())).ReturnsAsync(GetMockVersionList());
      _mmvRepository.Setup(x => x.GetDefaultVersionByModelId(It.IsAny<int>())).ReturnsAsync(GetMockVersion());
      _imageRepository.Setup(x => x.GetImage(It.IsAny<int>())).ReturnsAsync(GetMockImage());
      _userReviewRepository.Setup(x => x.GetReviewDetails(It.IsAny<int>())).ReturnsAsync(GetMockReview());
      _locationRepository.Setup(x => x.GetAllCities()).ReturnsAsync(GetMockCityList());
      _priceRepository.Setup(x => x.GetPriceListByCityId(It.IsAny<int>())).ReturnsAsync(GetMockPriceList());
      _priceRepository.Setup(x => x.GetAvgPriceByVersionId(It.IsAny<int>())).ReturnsAsync(GetMockPrice());

      var result = await _modelPageLogic.GetModelPageData(4);
      Assert.NotNull(result);
      Assert.Equal(carDetailsItem.MakeDetail.MakeName, result.MakeDetail.MakeName);
      Assert.Equal(carDetailsItem.ModelDetail.ModelName, result.ModelDetail.ModelName);
      Assert.Equal(carDetailsItem.ImageDetail.ImageUrl, result.ImageDetail.ImageUrl);
      Assert.Equal(carDetailsItem.ReviewDetail.Rating, result.ReviewDetail.Rating);
      Assert.NotEmpty(result.CitySet);
      Assert.NotEmpty(result.VersionSet);
      Assert.NotEmpty(result.PriceDetailList);
    }

    [Fact]
    public async Task GetModelPageData_DataEmpty_ReturnEmpty()
    {
      var carDetailsItem = GetMockCarDetails();
      _mmvRepository.Setup(x => x.GetMake(It.IsAny<int>())).ReturnsAsync(new Make());
      _mmvRepository.Setup(x => x.GetModel(It.IsAny<int>())).ReturnsAsync(new Model());
      _mmvRepository.Setup(x => x.GetVersionList(It.IsAny<int>())).ReturnsAsync(new List<CarVersion>());
      _mmvRepository.Setup(x => x.GetDefaultVersionByModelId(It.IsAny<int>())).ReturnsAsync(new CarVersion());
      _imageRepository.Setup(x => x.GetImage(It.IsAny<int>())).ReturnsAsync(new CarImage());
      _userReviewRepository.Setup(x => x.GetReviewDetails(It.IsAny<int>())).ReturnsAsync(new Review());
      _locationRepository.Setup(x => x.GetAllCities()).ReturnsAsync(new List<CarCity>());
      _priceRepository.Setup(x => x.GetPriceListByCityId(It.IsAny<int>())).ReturnsAsync(new List<CarPrice>());
      _priceRepository.Setup(x => x.GetAvgPriceByVersionId(It.IsAny<int>())).ReturnsAsync(new CarPrice());

      var result = await _modelPageLogic.GetModelPageData(4);
      Assert.NotNull(result);
      Assert.Null(result.MakeDetail.MakeName);
      Assert.Null(result.ModelDetail.ModelName);
      Assert.Null(result.ImageDetail.ImageUrl);
      Assert.Equal(0, result.ReviewDetail.Rating);
      Assert.Empty(result.CitySet);
      Assert.Empty(result.VersionSet);
      Assert.Empty(result.PriceDetailList);
    }
  }
}