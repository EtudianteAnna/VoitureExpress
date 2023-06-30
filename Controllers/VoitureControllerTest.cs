using Microsoft.AspNetCore.Mvc;
using Moq;
using VoitureExpress.Controllers;
using Xunit;

namespace VoitureExpress.Tests
{
    public class VoitureControllerTests
    {
        [Fact]
        public void Create_ValidVoiture_ReturnsRedirectToActionResult()
        {
            // Arrange
            var mockContext = new Mock<VoitureExpressContext>();
            var controller = new VoitureController(mockContext.Object);
            var voiture = new Models.Voiture { Id = 1, Marque = "Toyota", Modele = "Corolla" };

            // Act
            var result = controller.Create(voiture);

            // Assert
            Assert.IsType<RedirectToActionResult>(result);
        }

        [Fact]
        public void Delete_ExistingVoiture_ReturnsRedirectToActionResult()
        {
            // Arrange
            var mockContext = new Mock<VoitureExpressContext>();
            var controller = new VoitureController(mockContext.Object);
            var voitureId = 1;

            // Act
            var result = controller.Delete(voitureId);

            // Assert
            Assert.IsType<RedirectToActionResult>(result);
        }

        [Fact]
        public void Edit_ExistingVoiture_ReturnsViewResult()
        {
            // Arrange
            var mockContext = new Mock<VoitureExpressContext>();
            var controller = new VoitureController(mockContext.Object);
            var voitureId = 5;

            // Act
             var result = controller.Edit(voitureId);// Utilisez l'objet "voiture" au lieu de la classe "VoitureExpress.Models.Voiture"
           
            // Assert
            Assert.IsType<ViewResult>(result);
        }
    }
}
