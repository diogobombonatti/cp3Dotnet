using CP3.Application.Dtos;
using CP3.Application.Services;
using CP3.Domain.Entities;
using CP3.Domain.Interfaces.Repositories;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace CP3.Tests.Services
{
    public class BarcoServiceTests
    {
        private readonly BarcoService _service;
        private readonly Mock<IBarcoRepository> _repositoryMock;

        public BarcoServiceTests()
        {
            _repositoryMock = new Mock<IBarcoRepository>();
            _service = new BarcoService(_repositoryMock.Object);
        }

        [Fact]
        public async Task AddAsync_ShouldCallRepositoryAdd()
        {
            
            var barcoDto = new BarcoDto { Nome = "Teste", Modelo = "ModeloA", Ano = 2020, Tamanho = 10.5 };

            
            await _service.AddAsync(barcoDto);

            
            _repositoryMock.Verify(r => r.AddAsync(It.IsAny<Barco>()), Times.Once);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnBarcoDto()
        {
            
            var barco = new Barco { Id = 1, Nome = "Teste", Modelo = "ModeloA", Ano = 2020, Tamanho = 10.5 };
            _repositoryMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(barco);

            
            var result = await _service.GetByIdAsync(1);

            
            Assert.NotNull(result);
            Assert.Equal("Teste", result.Nome);
        }

        [Fact]
        public async Task UpdateAsync_ShouldCallRepositoryUpdate()
        {
            
            var barcoDto = new BarcoDto { Id = 1, Nome = "Atualizado", Modelo = "ModeloA", Ano = 2020, Tamanho = 10.5 };

            
            await _service.UpdateAsync(barcoDto);

            
            _repositoryMock.Verify(r => r.UpdateAsync(It.IsAny<Barco>()), Times.Once);
        }

        [Fact]
        public async Task DeleteAsync_ShouldCallRepositoryDelete()
        {
            
            await _service.DeleteAsync(1);

            
            _repositoryMock.Verify(r => r.DeleteAsync(1), Times.Once);
        }
    }
}
