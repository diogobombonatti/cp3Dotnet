using CP3.Data.AppData;
using CP3.Domain.Entities;
using CP3.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CP3.Data.Repositories
{
    public class BarcoRepository : IBarcoRepository
    {
        private readonly ApplicationContext _context;

        public BarcoRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Barco> GetByIdAsync(int id)
        {
            return await _context.Barcos.FindAsync(id);
        }

        public async Task<IEnumerable<Barco>> GetAllAsync()
        {
            return await _context.Barcos.ToListAsync();
        }

        public async Task AddAsync(Barco barco)
        {
            await _context.Barcos.AddAsync(barco);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Barco barco)
        {
            _context.Barcos.Update(barco);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var barco = await GetByIdAsync(id);
            if (barco != null)
            {
                _context.Barcos.Remove(barco);
                await _context.Sa
