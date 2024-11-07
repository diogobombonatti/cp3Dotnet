using CP3.Data.AppData;
using CP3.Data.Repositories;
using CP3.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Xunit;

namespace CP3.Tests.Repositories
{
    public class BarcoRepositoryTests
    {
        private readonly ApplicationContext _context;
        private readonly BarcoRepository _repository;

        public BarcoRepositoryTests()
        {
            // Configuração do banco de dados em memória
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            _context = new ApplicationContext(options);
            _repository = new BarcoRepository(_context);
        }

        [Fact]
        public async Task AddAsync_ShouldAddBarco()
        {
            // Arrange
            var barco = new Barco { Id = 1, Nome = "Teste", Modelo = "ModeloA", Ano = 2020, Tamanho = 10.5 };

            // Act
            await _repository.AddAsync(barco);
            var result = await _repository.GetByIdAsync(barco.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Teste", result.Nome);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnBarco()
        {
            // Arrange
            var barco = new Barco { Id = 1, Nome = "Teste", Modelo = "ModeloA", Ano = 2020, Tamanho = 10.5 };
            await _context.Barcos.AddAsync(barco);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.GetByIdAsync(barco.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Teste", result.Nome);


