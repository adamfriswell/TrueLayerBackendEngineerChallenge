using System;
using TrueLayerBackendEngineerChallenge.Services;
using Xunit;

namespace TrueLayerBackendEngineerChallenge.Tests {
    public class FunTranslationsApiServiceTests {
        [Fact]
        public async void FunTranslationsApiService_GetResponse_Success() {
            var funTranslationsApiService = new FunTranslationsApiService();

            var description = TestData.RubyVersionFlavourText;
            var result = await funTranslationsApiService.GetResponse(description);

            Assert.NotNull(result);
        }

        [Fact]
        public void FunTranslationsApiService_GetTranslation_Success() {
            var mockResponse = TestData.FunTranslationRubyDescriptionExpectedResult;
            var result = FunTranslationsApiService.GetTranslation(mockResponse);

            Assert.Equal(TestData.RubyVersionFlavourTextTranslated,result);
        }

        [Fact]
        public void FunTranslationsApiService_GetTranslation_Failure_NoContent() {
            var mockResponse = TestData.UnexpectedJson;

            Action act = () => FunTranslationsApiService.GetTranslation(mockResponse);

            Exception exception = Assert.Throws<Exception>(act);
            Assert.Equal("Cannot find 'content' node.", exception.Message);
        }

        [Fact]
        public void FunTranslationsApiService_GetTranslation_Failure_NoTranslation() {
            var mockResponse = TestData.FunTranslationResultWithNoTranslation;

            Action act = () => FunTranslationsApiService.GetTranslation(mockResponse);

            Exception exception = Assert.Throws<Exception>(act);
            Assert.Equal("Cannot find 'translated' node.", exception.Message);
        }
    }
}