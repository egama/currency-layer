using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Neon.Elivelton.Domain.ViewModel;
using Neon.Elivelton.Service.Interface;
using Neon.Elivelton.Tests.Fakes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Neon.Elivelton.Tests
{
    [TestClass]
    public class LiveCurrencies
    {
        [TestMethod]
        public void GetAllCurrencies_success()
        {
            string from = "USD";
            string to = "BRL";

            var _currencyLayerStub = new Mock<ICurrencyLayer>();
            var r = _currencyLayerStub.Setup(g => g.liveCurrency()).Returns(Task.FromResult(Json.LiveRequest.SuccessTrue));

            var _currency = new Application.App.Currency(_currencyLayerStub.Object);
            var response = _currency.GetConvertion(from, to);

            Assert.AreEqual(true, response.Result.success);
        }

        [TestMethod]
        public void GetConvertion_notSuccess()
        {
            string from = "USD";
            string to = "BRL";
            
            var liveCurrencyFake = new CurrencyLayerFake(Json.LiveRequest.SuccessFalse);
            var _currency = new Application.App.Currency(liveCurrencyFake);

            var response = _currency.GetConvertion(from, to);

            Assert.AreEqual(false, response.Result.success);
        }

        [TestMethod]
        public void GetConvertion_value_1()
        {
            string from = "BRL";
            string to = "BRL";

            var liveCurrencyFake = new CurrencyLayerFake(Json.LiveRequest.SuccessTrue);
            var _currency = new Application.App.Currency(liveCurrencyFake);

            var response = _currency.GetConvertion(from, to);

            Assert.AreEqual(true, response.Result.success);
            Assert.AreEqual(1, ((ResponseConvertion)response.Result.data).value);
            Assert.AreEqual("1,00", ((ResponseConvertion)response.Result.data).valueFormatted2);
            Assert.AreEqual("1,000", ((ResponseConvertion)response.Result.data).valueFormatted3);
        }
    }
}
