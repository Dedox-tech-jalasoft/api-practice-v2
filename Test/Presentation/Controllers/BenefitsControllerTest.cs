using InsuranceAPIv2.Application.Contracts;
using InsuranceAPIv2.Application.DTOs;
using InsuranceAPIv2.Presentation.Controllers;
using InsuranceAPIv2.Shared.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace InsuranceAPIv2.Test.Presentation.Controllers
{
    public class BenefitsControllerTest
    {
        [Fact]
        public async Task GetPatientBenefits_ReturnsBadRequest_OnInvalidResult()
        {
            Mock<IBenefitContext> benefitContext = new();

            Error error = new() { Code = Code.BadRequest, Message = "Invalid Carrier Id" };

            benefitContext.Setup(context => context.RetrievePatientBenefits(4,1).Result)
                .Returns(new Result<IEnumerable<DtoBenefit>> { Error = error});

            BenefitsController benefitsController = new(benefitContext.Object);

            IActionResult result = await benefitsController.GetPatientBenefits(4, 1);

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task GetPatientBenefits_ReturnsOk_OnValidResult()
        {
            Mock<IBenefitContext> benefitContext = new();

            benefitContext.Setup(context => context.RetrievePatientBenefits(1,1).Result)
                .Returns(new Result<IEnumerable<DtoBenefit>> { Data = new List<DtoBenefit>() });

            BenefitsController benefitsController = new(benefitContext.Object);

            IActionResult result = await benefitsController.GetPatientBenefits(1, 1);

            Assert.IsType<OkObjectResult>(result);
        }
    }
}
