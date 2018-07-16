using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Neon.Elivelton.Application;
using Neon.Elivelton.Domain.ViewModel;
using Neon.Elivelton.Service.Interface;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Neon.Elivelton.Tests
{
    [TestClass]
    public class ListCurrencies
    {
        [TestMethod]
        public void GetAllCurrencies_success()
        {
            var _currencyLayerStub = new Mock<ICurrencyLayer>();
            var r = _currencyLayerStub.Setup(g => g.listCurrency()).Returns(Task.FromResult(Json.ListRequest.SuccessTrue));

            var _currency = new Application.App.Currency(_currencyLayerStub.Object);
            var response = _currency.GetAllCurrencies();
            
            Assert.AreEqual(true, response.Result.success);
        }

        [TestMethod]
        public void GetAllCurrencies_notSuccess()
        {
            var _currencyLayerFake = new Fakes.CurrencyLayerFake(Json.ListRequest.SuccessFalse);
            var _currency = new Application.App.Currency(_currencyLayerFake);

            var response = _currency.GetAllCurrencies();
            Assert.AreEqual(false, response.Result.success);
        }
    }
}